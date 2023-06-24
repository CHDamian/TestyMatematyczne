using Newtonsoft.Json;
using System;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Models;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IContestRepository _contestRepository;
        private readonly ISolutionRepository _solutionRepository;

        public UserService(IUserRepository userRepository, IContestRepository contestRepository,
            ISolutionRepository solutionRepository)
        {
            _userRepository = userRepository;
            _contestRepository = contestRepository;
            _solutionRepository = solutionRepository;
        }

        public List<PublishedTests> GetPublishedTests()
        {
            var list = new List<PublishedTests>();
            var query = _contestRepository.GetAllPublishedContests();

            foreach ( var contest in query )
            {
                var test = new PublishedTests();
                test.Id = contest.Id;
                test.Name = contest.Name;
                if (contest.Difficulty == 1)
                {
                    test.Difficulty = "Łatwy";
                }
                if (contest.Difficulty == 2)
                {
                    test.Difficulty = "Średni";
                }
                if (contest.Difficulty == 3)
                {
                    test.Difficulty = "Trudny";
                }

                list.Add(test);
            }

            return list;
        }

        public TestToSolve GetTestToSolve(int id)
        {
            var test = new TestToSolve();
            var contest = _contestRepository.GetContest(id);
            test.id = contest.Id;
            test.name = contest.Name;
            test.questions = JsonConvert.DeserializeObject<List<Question>>(contest.Questions);
            return test;
        }

        public List<Answer> PrepareListOfAnswers(int len)
        {
            var answers = new List<Answer>();
            for(int i=0; i<len; i++)
            {
                answers.Add(new Answer());
            }
            return answers;
        }

        public DateTime SaveTestSolution(int id, string userId, List<Answer> answers)
        {
            var user = _userRepository.GetUser(userId);
            var solutionTime = DateTime.Now;
            var contest = _contestRepository.GetContest(id);

            var solution = new Solution();
            solution.SolutionTime = solutionTime;
            solution.UserId = user.Id;
            solution.ContestId = contest.Id;

            var questions = JsonConvert.DeserializeObject<List<Question>>(contest.Questions);
            solution.Score = 0;

            for(int i=0; i<questions.Count; i++)
            {
                if (questions[i].answer == answers[i].userAnswer)
                {
                    solution.Score += 100;
                    answers[i].isCorrect = true;
                }
                else
                {
                    answers[i].isCorrect = false;
                }
            }

            solution.Answers = JsonConvert.SerializeObject(answers);
            _solutionRepository.SaveNewSolution(solution);

            return solutionTime;
        }

		private bool compareDates(DateTime lhs, DateTime rhs)
		{
			if (lhs.Year != rhs.Year) return false;
			if (lhs.Month != rhs.Month) return false;
			if (lhs.Day != rhs.Day) return false;
			if (lhs.Hour != rhs.Hour) return false;
			if (lhs.Minute != rhs.Minute) return false;
			if (lhs.Second != rhs.Second) return false;
			return true;
		}

		public TestRaport GetTestRaport(int contestId, string userId, DateTime date)
        {
			var user = _userRepository.GetUser(userId);
			var solutionQuerry = _solutionRepository.GetSolution(contestId, user.Id, date);
            var contest = _contestRepository.GetContest(contestId);

            var solution = new Solution();

            foreach(var item in solutionQuerry)
            {
                if(compareDates(item.SolutionTime, date))
                {
                    solution = item; break;
                }    
            }

            var raport = new TestRaport();
            raport.testName = contest.Name;
            raport.userName = user.UserName;
            raport.solutionDate = date;
            raport.answers = JsonConvert.DeserializeObject<List<Answer>>(solution.Answers);
            raport.score = solution.Score;

            return raport;
        }
    }
}
