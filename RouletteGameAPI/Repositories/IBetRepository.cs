using RouletteGameAPI.Models;

namespace RouletteGameAPI.Repositories
{
    public interface IBetRepository
    {
        public Task<IEnumerable<PlaceBetResponse>> PlaceYourBet(List<PlaceBetRequests> placeBetRequests);
            
    }
}
