using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Drawing.Printing;
using TestyMatematyczne.Forms;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Models;
using TestyMatematyczne.Pages;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IContestRepository _contestRepository;
        private readonly ISolutionRepository _solutionRepository;
        public TeacherService(UserManager<User> userManager, IUserRepository userRepository,
            IContestRepository contestRepository, ISolutionRepository solutionRepository) 
        {
            _userManager= userManager;
            _userRepository= userRepository;
            _contestRepository= contestRepository;
            _solutionRepository= solutionRepository;
        }

        public List<SelectListItem> GetDifficultyList() 
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "Łatwy", Text = "Łatwy" });
            list.Add(new SelectListItem { Value = "Średni", Text = "Sredni" });
            list.Add(new SelectListItem { Value = "Trudny", Text = "Trudny" });
            return list;
        }

        public async void CreateNewContest(CreateContestForm contestForm, string id)
        {
            var contest = new Contest();
            contest.Organizer = _userRepository.GetUser(id);
            contest.Name = contestForm.Name;
            contest.Published = false;
            contest.Questions = JsonConvert.SerializeObject(new List<Question>());
            if(contestForm.Difficulty == "Łatwy")
            {
                contest.Difficulty = 1;
            }
            if (contestForm.Difficulty == "Średni")
            {
                contest.Difficulty = 2;
            }
            if (contestForm.Difficulty == "Trudny")
            {
                contest.Difficulty = 3;
            }
            _contestRepository.createNewContest(contest);
        }

        public List<TeacherTests> getTeacherTests(string id)
        {
            var query = _contestRepository.GetAllTeacherContests(id);
            List<TeacherTests> tests= new List<TeacherTests>();
            foreach(Contest contest in query)
            {
                var test = new TeacherTests();
                test.Id = contest.Id;
                test.Name = contest.Name;
                if(contest.Difficulty == 1)
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
                test.Published = contest.Published;
                List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(contest.Questions);
                test.numberOfTests = questions.Count();
                tests.Add(test);
            }
            return tests;
        }

        public TestToModify GetTestToModify(int testId, string id)
        {
            var testView = new TestToModify();
            var test = _contestRepository.GetContest(testId);
            var user = _userRepository.GetUser(id);
            testView.IsSameUser = test.UserId == user.Id;
            testView.Id = test.Id;
            testView.Name = test.Name;
            if (test.Difficulty == 1)
            {
                testView.Difficulty = "Łatwy";
            }
            if (test.Difficulty == 2)
            {
                testView.Difficulty = "Średni";
            }
            if (test.Difficulty == 3)
            {
                testView.Difficulty = "Trudny";
            }
            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(test.Questions);
            testView.Questions = new List<string>();
            int num = 0;
            foreach(var i in questions)
            {
                num++;
                string que = "Pytanie " + num.ToString() + ":";
                que += i.task + "\n";
                que += "Podpowiedzi: " + i.hint + "\n";
                que += "Odpowiedź: " + i.answer.ToString();
                testView.Questions.Add(que);
            }
            return testView;
        }

    }
}
