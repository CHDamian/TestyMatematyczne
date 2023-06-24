using Microsoft.AspNetCore.Mvc.Rendering;
using TestyMatematyczne.Forms;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Interfaces
{
    public interface ITeacherService
    {
        public List<SelectListItem> GetDifficultyList();
        public void CreateNewContest(CreateContestForm contestForm, string id);
        public List<TeacherTests> getTeacherTests(string id);
        public TestToModify GetTestToModify(int testId, string id);
        public void AddNewQuestionToTest(int testId, Question question);
        public int PublishTest(int testId, string id);
    }
}
