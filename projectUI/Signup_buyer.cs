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
using System.Data.SqlClient;

namespace projectUI
{
    public partial class Signup_buyer: KryptonForm
    {
        //connect with sql buyer_signup
        static SqlConnection con = new SqlConnection("Data Source=DESKTOP-2CIATK8;Initial Catalog=LOGIN_D;Integrated Security=True");
        static SqlCommand bcmd;
 

        public Signup_buyer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //conect with Seller seller 
            this.Hide();
            Signup_seller signnsel = new Signup_seller();
            signnsel.ShowDialog();
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

        private void Buyer_createbutton_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Please Insert Your All Details");
                return;
            }
            else
            {
                MessageBox.Show("Account Create Sucessfully.");
            }
            string query = "INSERT INTO REGIST VALUES(@USERNAME,@EMAIL,@PASSCODE)";
            con.Open();
            bcmd = new SqlCommand(query, con);

            //Adding parameters
            bcmd.Parameters.Add("@USERNAME",SqlDbType.VarChar);
            bcmd.Parameters["@USERNAME"].Value = username_tBox1.Text;

            bcmd.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            bcmd.Parameters["@EMAIL"].Value = buyer_email_signup.Text;
            
            bcmd.Parameters.Add("@PASSCODE", SqlDbType.VarChar);
            bcmd.Parameters["@PASSCODE"].Value = buyer_sigpass.Text;

            bcmd.ExecuteNonQuery();
            con.Close();
        }
        //check buyer signup field not empty
        bool Authenticate()
        {
            if (username_tBox1.Text == "Enter Your Name" ||
                buyer_email_signup.Text == "Enter Your Email Address" ||
                buyer_sigpass.Text == "Password"
                )
                return false;
            else return true;
        }
       
        private void buyer_sigpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void buyer_email_signup_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_tBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_tBox1_Enter(object sender, EventArgs e)
        {
            if (username_tBox1.Text == "Enter Your Name")
            {
                username_tBox1.Text = "";
                username_tBox1.ForeColor = Color.DarkGray;
            }
        }

        private void username_tBox1_Leave(object sender, EventArgs e)
        {
            if (username_tBox1.Text == "")
            {
                username_tBox1.Text = "Enter Your Name";
                username_tBox1.ForeColor = Color.Gray;
            }
        }

        private void buyer_email_signup_Enter(object sender, EventArgs e)
        {
            if (buyer_email_signup.Text == "Enter Your Email Address")
            {
                buyer_email_signup.Text = "";
                buyer_email_signup.ForeColor = Color.DarkGray;
            }

        }

        private void buyer_email_signup_Leave(object sender, EventArgs e)
        {
            if (buyer_email_signup.Text == "")
            {
                buyer_email_signup.Text = "Enter Your Email Address";
                buyer_email_signup.ForeColor = Color.Gray;
            }
        }

        private void buyer_sigpass_Enter(object sender, EventArgs e)
        {
            if (buyer_sigpass.Text == "Password")
            {
                buyer_sigpass.Text = "";
                buyer_sigpass.ForeColor = Color.DarkGray;
            }
        }

        private void buyer_sigpass_Leave(object sender, EventArgs e)
        {
            if (buyer_sigpass.Text == "")
            {
                buyer_sigpass.Text = "Password";
                buyer_sigpass.ForeColor = Color.Gray;
            }

        }
        
    }
}
