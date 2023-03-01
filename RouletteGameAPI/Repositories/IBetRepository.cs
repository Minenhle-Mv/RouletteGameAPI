using RouletteGameAPI.Models;

namespace RouletteGameAPI.Repositories
{
    public interface IBetRepository
    {
        //   Task<PlaceBetResponse> PlaceYourBet(List<PlaceBetRequests> placeBetRequests);
        PlaceBetResponse PlaceYourBet(PlaceBetRequests placeBetRequests);

    }
}
