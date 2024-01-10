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
    public partial class addquiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            string quizName = Name_quiz.SelectedItem.Text;
            string questionText = txtbox_Qna.Text;
            string correctAnswer = txtbox_Ans.Text;
            string option1 = txtbox_Oa1.Text;
            string option2 = txtbox_Oa2.Text;
            string option3 = txtbox_Oa3.Text;

            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-QCRKBQ8S\\SQLEXPRESS; Initial Catalog=QuizDatabase; Integrated Security=True; Pooling=False"))
            {
                try
                {
                    con.Open();

                    // Check if the quiz exists
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Quizzes WHERE QuizName = @quizName", con))
                    {
                        checkCmd.Parameters.Add("@quizName", SqlDbType.NVarChar, 50).Value = quizName;
                        int quizCount = (int)checkCmd.ExecuteScalar();

                        if (quizCount == 0)
                        {
                            lblStatus.Text = "Quiz does not exist! Please select a valid quiz.";
                            return;
                        }
                    }

                    // Insert the question and options
                    using (SqlCommand insertCmd = new SqlCommand("INSERT INTO Questions (QuizId, QuestionText, CorrectAnswer,option1,option2,option3) " +"VALUES ((SELECT QuizId FROM Quizzes WHERE QuizName = @quizName), @questionText, @correctAnswer,@option1,@option2,@option3); " , con))
                    {
                        insertCmd.Parameters.Add("@quizName", SqlDbType.NVarChar, 50).Value = quizName;
                        insertCmd.Parameters.Add("@questionText", SqlDbType.NVarChar, -1).Value = questionText;
                        insertCmd.Parameters.Add("@correctAnswer", SqlDbType.NVarChar, -1).Value = correctAnswer;
                        insertCmd.Parameters.Add("@option1", SqlDbType.NVarChar, -1).Value = option1;
                        insertCmd.Parameters.Add("@option2", SqlDbType.NVarChar, -1).Value = option2;
                        insertCmd.Parameters.Add("@option3", SqlDbType.NVarChar, -1).Value = option3;

                        insertCmd.ExecuteNonQuery();

                        lblStatus.Text = "New question added successfully";

                        ClearFormFields();
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception appropriately, e.g., log it or display a user-friendly message
                    lblStatus.Text = "An error occurred while adding the question. Please try again.";
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Add your cancellation logic here
            Response.Redirect("quizpoket.aspx"); // Redirect to another page, for example
        }

        private void ClearFormFields()
        {
            txtbox_Ans.Text = "";
            txtbox_Oa1.Text = "";
            txtbox_Oa2.Text = "";
            txtbox_Oa3.Text = "";
            txtbox_Qna.Text = "";
            Name_quiz.ClearSelection();
        }
    }
}