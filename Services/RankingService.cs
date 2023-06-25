using TestyMatematyczne.Interfaces;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Services
{
    public class RankingService : IRankingService
    {
        private readonly IUserRepository _userRepository;
        private readonly IContestRepository _contestRepository;
        private readonly ISolutionRepository _solutionRepository;

        public RankingService(IUserRepository userRepository, IContestRepository contestRepository, ISolutionRepository solutionRepository)
        {
            _userRepository = userRepository;
            _contestRepository = contestRepository;
            _solutionRepository = solutionRepository;
        }

        public List<RankedUser> GetRanking()
        {
            var ranking = new List<RankedUser>();
            var query = _solutionRepository.GetRanked();
            int i = 0;
            foreach (var item in query)
            {
                var rUser = new RankedUser();
                i++;
                rUser.Position = i;
                rUser.Points = item.Points;
                var user = _userRepository.GetUserById(item.UserId);
                rUser.UserName = user.UserName;
                ranking.Add(rUser);
            }

            return ranking;
        }
    }
}
