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
    public partial class Registration : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            string connectionstring;
            connectionstring = @"Server=mssqlstud.fhict.local;Database=dbi487346;User Id=dbi487346;Password=YeetWithYeet@1;";
            cn = new SqlConnection(connectionstring);
            cn.Open();
        }

        private void GoToLoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text != string.Empty || passwordTextBox.Text != string.Empty || repeatPasswordTextBox.Text != string.Empty)
            {
                if(passwordTextBox.Text == repeatPasswordTextBox.Text)
                {
                    cmd = new SqlCommand("select * from Users where Name='" + nameTextBox.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("username already in use");
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into Users(Name, Password) values(@Name, @Password)", cn);
                        cmd.Parameters.AddWithValue("Name", nameTextBox.Text);
                        cmd.Parameters.AddWithValue("Password", passwordTextBox.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You exist :D", "Done", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
