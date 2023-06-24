using TestyMatematyczne.Models;

namespace TestyMatematyczne.Interfaces
{
    public interface ISolutionRepository
    {
        public void SaveNewSolution(Solution solution);
        public IQueryable<Solution> GetSolution(int contestId, string userId, DateTime date);
    }
}
