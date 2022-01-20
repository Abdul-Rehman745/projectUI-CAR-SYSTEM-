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
    public partial class Login : KryptonForm
    {
        //connect with sql buyer_signup
        static SqlConnection con = new SqlConnection("Data Source=DESKTOP-2CIATK8;Initial Catalog=LOGIN_D;Integrated Security=True");
        static SqlCommand bcmd;

        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //conect with Seller Login 
            this.Hide();
            Login_seller loginsel = new Login_seller();
            loginsel.ShowDialog();
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
            //conect with buyer signup
            this.Hide();
            Signup_buyer sb = new Signup_buyer();
            sb.ShowDialog();
            this.Show();
        }

        private void Login_Button1_Click_1(object sender, EventArgs e)
        {
            bool userok = false, passok = false;

            if (!Authenticate())
            {
                MessageBox.Show("Please Insert Your All Details");
                return;
            }

            string query = "SELECT * FROM REGIST WHERE EMAIL=@EMAIL";
            con.Open();
            bcmd = new SqlCommand(query, con);

            //Adding parameters
            bcmd.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            bcmd.Parameters["@EMAIL"].Value = buyer_login.Text;

            //check given input match database
            SqlDataReader sda = bcmd.ExecuteReader();
            if (sda.HasRows)
            {
                userok = true;
            }
            con.Close();

            con.Open();
            query = "SELECT * FROM REGIST WHERE EMAIL=@EMAIL AND PASSCODE=@PASSCODE";
            bcmd = new SqlCommand(query, con);

            bcmd.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            bcmd.Parameters["@EMAIL"].Value = buyer_login.Text;

            bcmd.Parameters.Add("@PASSCODE", SqlDbType.VarChar);
            bcmd.Parameters["@PASSCODE"].Value = buyer_pass.Text;

            sda = bcmd.ExecuteReader();
            
            if (sda.HasRows)
            {
                passok = true;
            }

            //CONDITION CHECK EMAIL OR PASS IS OK OR NOT
            if (userok == false)
            {
                MessageBox.Show("Invalid Email ID.");
            }
            else if (userok == true && passok == false)
            {
                MessageBox.Show("Wrong Password!");
            }
            else
            {
                //show buyer page
                this.Hide();
                BuyerPage bup = new BuyerPage();
                bup.ShowDialog();
                this.Show();
            }
            con.Close();
        }
        //check buyer lofin field not empty
        bool Authenticate()
        {
            if (buyer_login.Text == "Enter Your Email Address" ||
                buyer_pass.Text == "Password")
                return false;
            else return true;
        }
        private void buyer_login_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buyer_login_Enter(object sender, EventArgs e)
        {
            if (buyer_login.Text == "Enter Your Email Address")
            {
                buyer_login.Text = "";
                buyer_login.ForeColor = Color.DarkGray;
            }
        }

        private void buyer_login_Leave(object sender, EventArgs e)
        {
            if (buyer_login.Text == "")
            {
                buyer_login.Text = "Enter Your Email Address";
                buyer_login.ForeColor = Color.Gray;
            }
        }

        private void buyer_pass_Enter(object sender, EventArgs e)
        {
            if (buyer_pass.Text == "Password")
            {
                buyer_pass.Text = "";
                buyer_pass.ForeColor = Color.DarkGray;
            }
        }

        private void buyer_pass_Leave(object sender, EventArgs e)
        {
            if (buyer_pass.Text == "")
            {
                buyer_pass.Text = "Password";
                buyer_pass.ForeColor = Color.Gray;
            }

        }
    }
}
