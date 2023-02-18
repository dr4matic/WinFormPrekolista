using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm.GameRules;

namespace GameEngine.GameRules
{
    public class GameCrossZero
    {

        private int drawLines = 0;
        private bool xo = false;
        private List<Cell> buttons = new();
        private GameElements? winner;

        public delegate void GameWinner(GameElements gameElements);

        public event GameWinner OnWinner;
        public event GameWinner OnDraw;

        public IReadOnlyCollection<Cell> Buttons => buttons;
        public void CreateField()
        {
            var lines = Enumerable
                .Range(0, 8)
                .Select(x => {
                    var line = new Line();
                    line.OnWin += Line_OnWin; ;
                    line.OnDraw += Line_OnDraw; ;
                    return line;
                })
                .ToList();


            var dict = new Dictionary<int, int[]>
            {
                [0] = new int[] { 0, 3, 6 },
                [1] = new int[] { 0, 4 },
                [2] = new int[] { 0, 5, 7 },
                [3] = new int[] { 1, 3 },
                [4] = new int[] { 1, 4, 6, 7 },
                [5] = new int[] { 1, 5 },
                [6] = new int[] { 2, 3, 7 },
                [7] = new int[] { 2, 4 },
                [8] = new int[] { 5, 2, 6 }

            };

            var z = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    z++;

                    var buttonLines = dict[z]
                    .Select(x => lines[x])
                    .ToList();

                    var button = new Cell(buttonLines);

                    button.x = j;
                    button.y = i;

                    buttons.Add(button);
                }
            }
        }

        public async Task<GameElements> Move(Cell gamecell)
        {
            await Task.Yield();
            var value = xo
            ? GameElements.Cross
            : GameElements.Zero;
            var result = gamecell.AddValue(value);
            if (result == value)
            {
                xo = !xo;
            }
            return result;
        }

        private void Line_OnDraw(GameElements gameElements)
        {
            drawLines++;
            if (drawLines == 8)
            {
                OnDraw?.Invoke(gameElements);
            }
        }

        private void Line_OnWin(GameElements gameElements)
        {
            if(winner == null)
            {
                winner = gameElements;
                OnWinner?.Invoke(gameElements);
            }
            
        }
    }
}
