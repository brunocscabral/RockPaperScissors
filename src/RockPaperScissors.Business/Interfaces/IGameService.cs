using RockPaperScissors.Business.Models;
using System;
using System.Threading.Tasks;

namespace RockPaperScissors.Business.Interfaces
{
    public interface IGameService : IDisposable
    {
        Task<object> Play(int moveP1, int moveP2, TypePlayer against);
    }
}
