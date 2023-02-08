using GameEngine.GameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm.GameRules;

namespace WinForm.Controls
{
    public class GameButton : Button
    {
        public Cell Cell { get; private set; }

        public GameButton(Cell gamecell)
            : base()
            {
            this.Cell = gamecell;
        }
    
    }
}
