using System.Collections.Generic;

namespace RockPaperScissors.Business.Models
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public TypePlayer typePlayer { get; set; }        
    }
}
