using Accessibility;

namespace WinForm
{
    public partial class MainForm : Form
    {
        private string userName;

        public MainForm(string userName): this()
        {
            this.userName = userName;
            
        }
        public MainForm()
        {
            InitializeComponent();
        }
    }
}