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
        private readonly ICollection<Line> lines;

        public GameButton(ICollection<Line> lines)
            : base()
            {
            this.lines = lines;
        }
    public void AddValue(GameElements gameElement)
        {
            foreach(var line in lines)
            {
                line.AddElement(gameElement);
            }
        }
    }
}
