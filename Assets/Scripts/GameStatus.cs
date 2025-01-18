using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts
{
    public class GameStatus
    {
        public MeowState CurrentState { get; set; }
        public int Step { get; set; }
    }
}
