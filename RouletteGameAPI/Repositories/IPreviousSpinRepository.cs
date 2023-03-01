using System.Collections.Generic;
using System.Threading.Tasks;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Repositories
{
    public interface IPreviousSpinRepository
    {
        Task<IEnumerable<PreviousSpinResponse>> ShowPreviousSpins();

    }
}
