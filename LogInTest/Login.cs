using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInTest
{
    public partial class Login : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string connectionstring;
            connectionstring = @"Server=mssqlstud.fhict.local;Database=dbi487346;User Id=dbi487346;Password=YeetWithYeet@1;";
            cn = new SqlConnection(connectionstring);
            cn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != string.Empty || passwordTextBox.Text != string.Empty)
            {

                cmd = new SqlCommand("select * from Users where Name='" + nameTextBox.Text + "' and Password='" + passwordTextBox.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
