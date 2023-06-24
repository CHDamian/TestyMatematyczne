using TestyMatematyczne.Services.Datapacks;

namespace TestyMatematyczne.ViewModels
{
    public class TestToSolve
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<Question> questions { get; set; }
    }
}
