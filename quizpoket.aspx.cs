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
    public partial class quizpoket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string connectionString = "Data Source=LAPTOP-QCRKBQ8S\\SQLEXPRESS;Initial Catalog=quizdatabase;Integrated Security=True;Pooling=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Use a JOIN statement to retrieve quiz data along with questions and options
                    SqlCommand cmd = new SqlCommand("SELECT Q.QuizId, Q.QuizName, QS.QuestionId, QS.QuestionText, QS.CorrectAnswer, QS.option1, QS.option2, QS.option3 " +"FROM Quizzes Q INNER JOIN Questions QS ON Q.QuizId = QS.QuizId", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    // Log the exception or redirect to an error page
                    Response.Redirect("errorpage.aspx");
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView1.SelectedRow;

            if (selectedRow != null)
            {
                string quizId = selectedRow.Cells[0].Text;
                string quizName = selectedRow.Cells[1].Text;
                string questionId = selectedRow.Cells[2].Text;
                string questionText = selectedRow.Cells[3].Text;
                string option1 = selectedRow.Cells[4].Text;
                string option2 = selectedRow.Cells[5].Text;
                string option3 = selectedRow.Cells[6].Text;
                string correctAnswer = selectedRow.Cells[7].Text;

                // You can use these values as needed
                // For example, store them in session or redirect to another page

                // Redirect to the Update.aspx page
                Response.Redirect("Update.aspx");
            }
        }

        protected void ButtonAddNew_Click(object sender, EventArgs e)
        {
            // Redirect to the AddQuiz.aspx page
            Response.Redirect("addquiz.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}