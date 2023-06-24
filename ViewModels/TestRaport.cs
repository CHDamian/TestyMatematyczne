using TestyMatematyczne.Services.Datapacks;

namespace TestyMatematyczne.ViewModels
{
    public class TestRaport
    {
        public string testName { get; set; }
        public string userName { get; set; }
        public DateTime solutionDate { get; set; }
        public List<Answer> answers { get; set; }
        public int score { get; set; }
    }
}
