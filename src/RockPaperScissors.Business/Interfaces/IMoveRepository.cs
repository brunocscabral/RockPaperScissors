using RockPaperScissors.Business.Models;
using System.Threading.Tasks;

namespace RockPaperScissors.Business.Interfaces
{
    public interface IMoveRepository : IRepository<Move>
    {
        Task AddBeat(int moveId, int beatId);
    }
}
