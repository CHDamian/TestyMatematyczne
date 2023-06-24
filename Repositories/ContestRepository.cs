using TestyMatematyczne.Data;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Models;

namespace TestyMatematyczne.Repositories
{
    public class ContestRepository : IContestRepository
    {
        private readonly ApplicationDbContext _context;
        public ContestRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void createNewContest(Contest contest)
        {
            _context.Contest.Add(contest);
            _context.SaveChanges();
        }

        public IQueryable<Contest> GetAllTeacherContests(string id)
        {
            var user = _context.Users.Where(u => u.Email == id).First();
            return _context.Contest.Where(u => u.UserId == user.Id);

        }
        public Contest GetContest(int id)
        {
            return _context.Contest.Where(u => u.Id == id).First();
        }
        public void UpdateContest(Contest contest)
        {
            _context.SaveChanges();
        }

        public IQueryable<Contest> GetAllPublishedContests()
        {
            return _context.Contest.Where(u => u.Published);
        }
    }
}
