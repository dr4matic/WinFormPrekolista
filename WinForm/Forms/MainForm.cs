using Accessibility;
using System.Xml.Linq;
using WinForm.Engine;
using System.Drawing;
using System.Globalization;

namespace WinForm
{

    public partial class MainForm : Form
    {

        private bool xo = false;
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

            for (int i = 0, j = 0; i < 9; i++, j++)
            {
                if (j == 3)
                {
                    j = 0;
                }
                var x = 240 + j * 100;
                var y = 50 + (i / 3) * 100;

                var button = new Button();
                button.Location = new Point(x, y);
                button.Name = "button";
                button.Size = new Size(100, 100);
                button.TabIndex = 1;
                button.Text = "";
                button.Font = new Font(FontFamily.GenericMonospace, 30, GraphicsUnit.Point);
                button.ForeColor = Color.Black;
                button.UseVisualStyleBackColor = true;
                button.Click += ButtonClick;
                Controls.Add(button);
            }
        }

        private void ButtonClick(object? sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            button.Text = xo ? "X" : "O";
            xo = !xo;
        }
    }
}