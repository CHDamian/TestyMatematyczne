using TestyMatematyczne.Models;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Interfaces
{
    public interface IUserService
    {
        public List<PublishedTests> GetPublishedTests();
        public TestToSolve GetTestToSolve(int id);
        public List<Answer> PrepareListOfAnswers(int len);
        public DateTime SaveTestSolution(int id, string userId, List<Answer> answers);
        public TestRaport GetTestRaport(int contestId, string userId, DateTime date);
        public List<UserSolution> GetUserSolutions(string UserId);
    }
}
