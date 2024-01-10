using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectdotnetquiz.Masterpage
{
    public partial class login : System.Web.UI.Page
    {
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = txtbox_username.Text;
            string password = textbox_password.Text;

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-QCRKBQ8S\\SQLEXPRESS; Initial Catalog=quizdatabase; Integrated Security=True; Pooling=False");

            try
            {
                con.Open();

                // Use a SELECT statement to check if the username and password exist in the database
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM userdata WHERE username = @username AND password = @password", con);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    // Login successful, redirect to the homepage
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    // Display an error message or perform other actions for unsuccessful login
                    Response.Write("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Clear the textboxes and any other necessary cleanup
            txtbox_username.Text = "";
            textbox_password.Text = "";

            // Optionally, you can redirect to another page or perform other actions
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
    }
}