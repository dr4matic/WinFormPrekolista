using Accessibility;
using System.Xml.Linq;
using WinForm.Engine;
using System.Drawing;
using System.Globalization;
using WinForm.GameRules;
using WinForm.Controls;

namespace WinForm
{
    public partial class MainForm : Form
    {
        private int drawLines = 0;
        private bool xo = false;
        private List<GameButton> buttons = new();
        internal MainForm(UIApplicationContext context) : this()
        {
            UserNameLabel.Text = context.UserName;
        }
        public MainForm()
        {
            InitializeComponent();
            CreateField();
        }



        private void CreateField()
        {
            var lines = Enumerable
                .Range(0,8)
                .Select(x => {
                    var line = new Line();
                    line.OnWin += GameWin;
                    line.OnDraw += GameDraw;
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
                [8] = new int[] {5, 2, 6}

            };

            for (int i = 0, j = 0; i < 9; i++, j++)
            {
                if (j == 3)
                {
                    j = 0;
                }
                var x = 240 + j * 100;
                var y = 50 + (i / 3) * 100;
                
                var buttonLines = dict[i]
                    .Select(x => lines[x])
                    .ToList();
                var button = new GameButton(buttonLines);
                button.Location = new Point(x, y);
                button.Name = "button";
                button.Size = new Size(100, 100);
                button.TabIndex = 1;
                button.Text = "";
                button.Font = new Font(FontFamily.GenericMonospace, 12, GraphicsUnit.Point);
                button.ForeColor = Color.Black;
                button.UseVisualStyleBackColor = true;
                button.Click += ButtonClick;
                buttons.Add(button);
                Controls.Add(button);
            }
        }

        private void Restart()
        {
            foreach (var button in buttons)
            {
                Controls.Remove(button);
            }
            drawLines = 0;
            xo = false;
            buttons.Clear();
            CreateField();
        }
        

        private void GameWin(GameElements gameElements)
        {
            MessageBox.Show($"Победил игрок {gameElements}");
            Restart();
        }



        private void GameDraw(GameElements gameElements)
        {
            drawLines += 1;
            if(drawLines == 8)
            {
                MessageBox.Show($"Ничья");
                Restart();  
            }
            
        }
        private void ButtonClick(object? sender, EventArgs e)
        {
            if (sender is not GameButton button)
            {
                return;
            }
            var value = xo 
                ? GameElements.Cross 
                : GameElements.Zero;
            button.Text = xo ? "X" : "O";
            xo = !xo;
            button.Click-= ButtonClick;
            button.AddValue(value);
        }
    }
}