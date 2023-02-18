using Accessibility;
using System.Xml.Linq;
using WinForm.Engine;
using System.Drawing;
using System.Globalization;
using WinForm.GameRules;
using WinForm.Controls;
using GameEngine.GameRules;

namespace WinForm
{
    public partial class MainForm : Form
    {
        private GameCrossZero _game;
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
            _game= new GameCrossZero();
            _game.OnWinner += GameWin;
            _game.OnDraw+= GameDraw;
            _game.CreateField();

            foreach(var cell in _game.Buttons)
            {
                var x = 240 + cell.x * 100;
                var y = 50 + cell.y * 100;

                var button = new GameButton(cell);
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
            CreateField();
        }
        

        private async void GameWin(GameElements gameElements)
        {
            await Task.Yield();
            MessageBox.Show($"������� ����� {gameElements}");
            Restart();
        }



        private async void GameDraw(GameElements gameElements)
        {
            await Task.Yield();
            MessageBox.Show($"�����");
            Restart();  
          
        }
        private void ButtonClick(object? sender, EventArgs e)
        {
            if (sender is not GameButton button)
            {
                return;
            }

            var result = _game.Move(button.Cell);
            
            button.Text = result switch
            {
                GameElements.Zero => "O",
                GameElements.Cross => "X",
            };
            
            button.Click-= ButtonClick;
           
        }
    }
}