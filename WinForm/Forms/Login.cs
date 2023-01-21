using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.Engine;

namespace WinForm.Forms
{
    public partial class Login : Form
    {
        private readonly UIApplicationContext context;

        public Login()
        {
            InitializeComponent();
        }

        internal Login(UIApplicationContext context) : this()
        {
            this.context = context;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            context.UserName = LoginTextBox.Text;
            if (string.IsNullOrEmpty(context.UserName) )
            {
                MessageBox.Show("атата, напиши че нить");
                return;
            }
            var mainForm = new MainForm(context);
            mainForm.Show();
            context.MainForm = mainForm;
            this.Close();
        }

        private void LoginLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
