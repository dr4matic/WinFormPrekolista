using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm.GameRules;

namespace GameEngine.GameRules
{
    public class Cell 
    {
        private readonly ICollection<Line> lines;

        public int x { get; set; }
        public int y { get; set; } 

        public GameElements? Value { get; private set; }
        public Cell(ICollection<Line> lines)
            : base()
        {
            this.lines = lines;
        }
        public GameElements AddValue(GameElements gameElement)
        {
            if(Value is not null)
            {
                return Value.Value;
            }
            Value= gameElement;
            foreach (var line in lines)
            {
                line.AddElement(gameElement);
            }
            return Value.Value;
        }
    }
}
