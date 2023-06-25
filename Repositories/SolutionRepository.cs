using TestyMatematyczne.Data;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Models;

namespace TestyMatematyczne.Repositories
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly ApplicationDbContext _context;
        public SolutionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SaveNewSolution(Solution solution)
        {
            _context.Solution.Add(solution);
            _context.SaveChanges();
        }

        public IQueryable<Solution> GetSolution(int contestId, string userId, DateTime date)
        {
            return _context.Solution.Where(u => u.UserId == userId)
                                    .Where(u => u.ContestId == contestId);
        }

        public IQueryable<Solution> GetUserSolutions(string UserId)
        {
            return _context.Solution.Where(u => u.UserId == UserId); 
        }
    }
}
