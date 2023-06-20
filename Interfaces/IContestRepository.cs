using TestyMatematyczne.Models;

namespace TestyMatematyczne.Interfaces
{
    public interface IContestRepository
    {
        public void createNewContest(Contest contest);
        public IQueryable<Contest> GetAllTeacherContests(string id);
        public Contest GetContest(int id);
    }
}
