using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Business.Interfaces;
using RockPaperScissors.Business.Models;
using RockPaperScissors.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.UI.Controllers
{
    public class MoveController : BaseController
    {
        private readonly IMoveRepository _moveRepository;
        private readonly IMoveService _moveService;
        private readonly IMapper _mapper;

        public MoveController(IMoveRepository moveRepository, 
            IMoveService moveService, 
            IMapper mapper) 
        {
            _moveRepository = moveRepository;
            _moveService = moveService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MoveViewModel>>(await _moveRepository.Get()));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MoveViewModel moveViewModel)
        {
            if (!ModelState.IsValid) return View(moveViewModel);

            await _moveService.Create(_mapper.Map<Move>(moveViewModel));
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var moveViewModel = _mapper.Map<MoveViewModel>(await _moveRepository.Get(id));
            
            if (moveViewModel == null) return NotFound();
            
            return View(moveViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MoveViewModel moveViewModel)
        {
            if (id != moveViewModel.Id) return NotFound();
            
            if (!ModelState.IsValid) return View(moveViewModel);

            await _moveService.Update(_mapper.Map<Move>(moveViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var moveViewModel = _mapper.Map<MoveViewModel>(await _moveRepository.Get(id));
            
            if (moveViewModel == null) return NotFound();
            
            return View(moveViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var move = await _moveRepository.Get(id);

            if (move == null) return NotFound();

            await _moveService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddBeat(int moveId, int beatId)
        {
            var moveViewModel = await _moveRepository.Get(moveId);
            var beatViewModel = await _moveRepository.Get(beatId);

            if (moveViewModel == null || beatViewModel == null) return NotFound();

            await _moveService.AddBeat(moveId, beatId);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DelBeat(int moveId, int beatId)
        {
            var moveViewModel = await _moveRepository.Get(moveId);

            if (moveViewModel == null) return NotFound();

            await _moveService.DelBeat(moveId, beatId);

            return Ok();
        }
    }
}
