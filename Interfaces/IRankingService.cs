using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Interfaces
{
    public interface IRankingService
    {
        public List<RankedUser> GetRanking();
    }
}
