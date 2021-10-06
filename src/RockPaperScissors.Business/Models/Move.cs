using System.Collections.Generic;

namespace RockPaperScissors.Business.Models
{
    public class Move : Entity
    {
        public string Name { get; set; }
        public string Beats { get; set; }        
    }
}
