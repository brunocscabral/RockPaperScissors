using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Business.Interfaces;
using RockPaperScissors.Business.Models;
using RockPaperScissors.UI.ViewModels;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace RockPaperScissors.UI.Controllers
{
    public class GameController : Controller
    {
        private readonly IMoveRepository _moveRepository;
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GameController(IMoveRepository moveRepository,
            IGameService gameService, 
            IMapper mapper)
        {
            _moveRepository = moveRepository;
            _gameService = gameService;
            _mapper = mapper;
        }

        public async Task<IActionResult> StartHumain()
        {
            var gamesViewModel = new GameViewModel() { Against = TypePlayer.Humain };
            gamesViewModel.Moves = _mapper.Map<IEnumerable<MoveViewModel>>(await _moveRepository.Get());
            
            return View("Index", gamesViewModel);
        }

        public async Task<IActionResult> StartBotBeatPreviousSelection()
        {
            var gamesViewModel = new GameViewModel() { Against = TypePlayer.BotBeatPreviousSelection };
            gamesViewModel.Moves = _mapper.Map<IEnumerable<MoveViewModel>>(await _moveRepository.Get());

            return View("Index", gamesViewModel);
        }

        public async Task<IActionResult> StartBotRandom()
        {
            var gamesViewModel = new GameViewModel() { Against = TypePlayer.BotRandon };
            gamesViewModel.Moves = _mapper.Map<IEnumerable<MoveViewModel>>(await _moveRepository.Get());

            return View("Index", gamesViewModel);
        }

        [HttpPost]
        public async Task<string> Play(int moveP1, int moveP2, TypePlayer against)
        {

            var validP1Move = await _moveRepository.Get(moveP1);
            var validP2Move = await _moveRepository.Get(moveP2);

            if (validP1Move == null || (against.Equals(TypePlayer.Humain) && validP2Move == null)) return "";

            return JsonSerializer.Serialize(await _gameService.Play(moveP1, moveP2, against));
        }
    }
}