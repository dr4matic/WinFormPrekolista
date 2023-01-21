using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm(LoginTextBox.Text);
            mainForm.Show();
            this.Close();
        }

        private void LoginLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
