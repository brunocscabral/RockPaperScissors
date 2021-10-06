using Microsoft.AspNetCore.Http;
using RockPaperScissors.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RockPaperScissors.UI.ViewModels
{
    public class GameViewModel
    {
        public TypePlayer Against { get; set; }
        public IEnumerable<MoveViewModel> Moves { get; set; }
    }
}
