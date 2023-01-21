using Accessibility;
using System.Xml.Linq;
using WinForm.Engine;

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
        }

        private void ButtonClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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