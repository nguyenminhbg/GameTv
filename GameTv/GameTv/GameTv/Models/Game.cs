using System;
using System.Collections.Generic;
using System.Text;

namespace GameTv.Models
{
   public class Game
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Type TargetType { get; set; }
        public bool Iswitch { get; set; }
    }
}
