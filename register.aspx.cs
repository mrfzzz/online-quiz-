using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectdotnetquiz.Masterpage
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            string username = txtbox_username.Text;
            string id = txtbox_ic.Text;
            string password = textbox_password.Text;

            SqlConnection con = new SqlConnection
            ("Data Source =LAPTOP-QCRKBQ8S\\SQLEXPRESS; Initial Catalog = quizdatabase;   Integrated Security = True; Pooling = False");

            try
            {
                con.Open();

                SqlCommand cmmd = new SqlCommand("SELECT * FROM userdata WHERE id='" + id + "'", con);
                SqlDataReader reader = cmmd.ExecuteReader();

                if (reader.Read())
                {
                    lblStatus.Text = "Student ID already exists! Please type different Student ID";
                    reader.Close();
                    return;
                }

                reader.Close();
                SqlDataAdapter cmd = new SqlDataAdapter();// Create a object of SqlDataAdapter class
                cmd.InsertCommand = new SqlCommand("INSERT INTO userdata VALUES (@id,@username,@password) ", con); //Pass the connection object to cmd

                cmd.InsertCommand.Parameters.Add("@username", SqlDbType.Text).Value = username;
                cmd.InsertCommand.Parameters.Add("@id", SqlDbType.Text).Value = id;
                cmd.InsertCommand.Parameters.Add("@password", SqlDbType.Text).Value = password;

                cmd.InsertCommand.ExecuteNonQuery();  //to execute the SQL command

                lblStatus.Text = "New student info added successfully";
                txtbox_username.Text = "";
                txtbox_ic.Text = "";
                textbox_password.Text = "";
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
            // Add your cancellation logic here
            Response.Redirect("Studentinfo.aspx"); // Redirect to another page, for example
        }
    }
}