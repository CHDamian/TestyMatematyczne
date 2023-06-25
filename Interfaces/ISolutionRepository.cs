using TestyMatematyczne.Models;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Interfaces
{
    public interface ISolutionRepository
    {
        public void SaveNewSolution(Solution solution);
        public IQueryable<Solution> GetSolution(int contestId, string userId, DateTime date);
        public IQueryable<Solution> GetUserSolutions(string UserId);
    }
}
