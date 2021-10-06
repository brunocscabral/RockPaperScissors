using RockPaperScissors.Business.Interfaces;
using RockPaperScissors.Business.Models;
using RockPaperScissors.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Business.Services
{
    public class MoveService : BaseServices, IMoveService
    {
        private readonly IMoveRepository _moveRepository;

        public MoveService(IMoveRepository moveRepository) 
        {
            _moveRepository = moveRepository;
        }

        public async Task Create(Move move)
        {
            if (!ExecuteValidation(new MoveValidation(), move)) return; 

            await _moveRepository.Create(move);
        }

        public async Task Update(Move move)
        {
            if (!ExecuteValidation(new MoveValidation(), move)) return;

            await _moveRepository.Update(move);
        }

        public async Task Delete(int id)
        {
            await _moveRepository.Delete(id);
        }

        public async Task<bool> AddBeat(int moveId, int beatId)
        {
            var moveViewModel = await _moveRepository.Get(moveId);
            var beatViewModel = await _moveRepository.Get(beatId);

            if (moveViewModel == null || beatViewModel == null) return false;


            if (moveViewModel.Beats != null)
                moveViewModel.Beats = String.Join(",", moveViewModel.Beats.Split(",").Append(beatId.ToString()).Distinct());
            else
                moveViewModel.Beats = beatId.ToString();

            await _moveRepository.Update(moveViewModel);

            return true;
        }

        public async Task<bool> DelBeat(int moveId, int beatId)
        {
            var moveViewModel = await _moveRepository.Get(moveId);

            if (moveViewModel == null) return false;


            if (moveViewModel.Beats != null)
                moveViewModel.Beats = String.Join(",", moveViewModel.Beats.Split(",").Except(new string[] { beatId.ToString() }).Distinct());
            else
                moveViewModel.Beats = beatId.ToString();

            await _moveRepository.Update(moveViewModel);

            return true;
        }

        public void Dispose()
        {
            _moveRepository?.Dispose();
        }
    }
}
