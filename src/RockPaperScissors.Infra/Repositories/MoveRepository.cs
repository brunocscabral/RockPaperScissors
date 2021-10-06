using RockPaperScissors.Business.Interfaces;
using RockPaperScissors.Business.Models;
using RockPaperScissors.Infra.Context;
using System;
using System.Threading.Tasks;

namespace RockPaperScissors.Infra.Repositories
{
    public class MoveRepository : Repository<Move>, IMoveRepository
    {
        public MoveRepository(GameDbContext context) : base(context) { }

        public async Task AddBeat(int moveId, int beatId)
        {
            var move = await _gameDbContext.Moves.FindAsync(moveId); 

           // _gameDbContext.Attach(beat);
            await SaveChanges();
        }
    }
}
