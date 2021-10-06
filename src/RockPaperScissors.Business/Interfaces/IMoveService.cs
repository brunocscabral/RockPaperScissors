using RockPaperScissors.Business.Models;
using System;
using System.Threading.Tasks;

namespace RockPaperScissors.Business.Interfaces
{
    public interface IMoveService : IDisposable
    {
        Task Create(Move move);
        Task Update(Move move);
        Task Delete(int id);
        Task<bool> AddBeat(int moveId, int beatId);
        Task<bool> DelBeat(int moveId, int beatId);
    }
}
