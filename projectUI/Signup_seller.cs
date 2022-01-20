using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace projectUI
{
    public partial class Signup_seller: KryptonForm
    {
        public Signup_seller()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //conect with Seller buyer 
            this.Hide();
            Signup_buyer signbuy = new Signup_buyer();
            signbuy.ShowDialog();
            this.Show();
        }

        private void buyer_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void buyer_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Button1_Click(object sender, EventArgs e)
        {

        }

        private void Signup_Button1_Click(object sender, EventArgs e)
        {

        }

        private void Signup_Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Login_Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void buyer_login_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
