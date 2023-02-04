using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.GameRules
{
    public class Line
    {
        public delegate void LineEvent(GameElements gameElements);

        private List<GameElements> _elements = new();

        public event LineEvent OnWin;
        public event LineEvent OnDraw;

        public bool AddElement(GameElements gameElements)
        {
            if (_elements.Count == 3)
            {
                return false;
            }
            _elements.Add(gameElements);
            CheckAllSame();
            return true;
        }
        private void CheckAllSame()
        {
            var result = _elements
                .Distinct()
                .Count() == 1;

            if (result && _elements.Count == 3)
            {
                OnWin?.Invoke(_elements[0]);
            }
            else if (_elements.Count == 3)
            {
                OnDraw?.Invoke(_elements[0]);
            }

        }
    }
}
