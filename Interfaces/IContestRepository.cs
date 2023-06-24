using TestyMatematyczne.Models;
using TestyMatematyczne.Services.Datapacks;

namespace TestyMatematyczne.Interfaces
{
    public interface IContestRepository
    {
        public void createNewContest(Contest contest);
        public IQueryable<Contest> GetAllTeacherContests(string id);
        public Contest GetContest(int id);
        public void UpdateContest(Contest contest);
        public IQueryable<Contest> GetAllPublishedContests();
    }
}
