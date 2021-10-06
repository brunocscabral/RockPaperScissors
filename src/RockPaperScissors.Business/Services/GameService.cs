using RockPaperScissors.Business.Interfaces;
using RockPaperScissors.Business.Models;
using RockPaperScissors.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Business.Services
{
    public class GameService : BaseServices, IGameService
    {
        private readonly IMoveRepository _moveRepository;

        public GameService(IMoveRepository moveRepository) 
        {
            _moveRepository = moveRepository;
        }

        public async Task<object> Play(int moveP1, int moveP2, TypePlayer against)
        {
            var moves = await _moveRepository.Get();

            if (against == TypePlayer.BotBeatPreviousSelection)
                moveP2 = await StartBotBeatPreviousSelection(moveP2);
            else if (against == TypePlayer.BotRandon)
                moveP2 = await BotRandomMove();

            var choiceP1 = moves.Find(m => m.Id == moveP1);
            var choiceP2 = moves.Find(m => m.Id == moveP2);

            var moveP1Beats = (choiceP1.Beats ?? "").Split(",").Contains(moveP2.ToString());
            var moveP2Beats = (choiceP2.Beats ?? "").Split(",").Contains(moveP1.ToString());

            var win = "Draw";

            if (moveP1Beats != moveP2Beats)
                win = moveP1Beats ? "P1" : "P2";

            return new
            {
                win = win,
                moveP1 = choiceP1.Name,
                moveP2 = choiceP2.Name,
                moveP2LastId = choiceP2.Id,
            };
        }

        public async Task<int> StartBotBeatPreviousSelection(int lastChoice = 0)
        {
            if(lastChoice == 0) return await BotRandomMove();

            var moves = await _moveRepository.Get();

            var move = moves.Find(m => m.Beats.Split(",").Contains(lastChoice.ToString()));

            if(move != null) return move.Id;
            else return await BotRandomMove();
        }

        private async Task<int> BotRandomMove()
        {
            var moves = await _moveRepository.Get();

            return moves.OrderBy(m => new Random().Next()).Take(1).ToArray()[0].Id;
        }

        public void Dispose()
        {
            _moveRepository?.Dispose();
        }

        public Task<string> Play(int moveP1, int moveP2)
        {
            throw new NotImplementedException();
        }
    }
}
