using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectdotnetquiz.Masterpage
{
    public partial class quizgame : System.Web.UI.Page
    {
        private string connectionString = "quizdatabase"; // Update with your database connection string
        private int currentQuestionIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuizzes();
                LoadQuestion();
            }
        }

        private void LoadQuizzes()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT QuizId, QuizName FROM Quizzes", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    comboBoxQuiz.DataSource = reader;
                    comboBoxQuiz.DataTextField = "QuizName";
                    comboBoxQuiz.DataValueField = "QuizId";
                    comboBoxQuiz.DataBind();
                }
            }
        }

        private void LoadQuestion()
        {
            int quizId = Convert.ToInt32(comboBoxQuiz.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Questions WHERE QuizId = @quizId", con))
                {
                    cmd.Parameters.AddWithValue("@quizId", quizId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        labelQuestion.Text = reader["QuestionText"].ToString();

                        labelOption1.Text = reader["option1"].ToString();
                        labelOption2.Text = reader["option2"].ToString();
                        labelOption3.Text = reader["option3"].ToString();

                        radioButtonOption1.Checked = false;
                        radioButtonOption2.Checked = false;
                        radioButtonOption3.Checked = false;

                        currentQuestionIndex++;
                    }
                    else
                    {
                        // Handle when there are no more questions
                        labelQuestion.Text = "No more questions available for this quiz.";
                        labelOption1.Text = "";
                        labelOption2.Text = "";
                        labelOption3.Text = "";
                    }
                }
            }
        }

        protected void comboBoxQuiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentQuestionIndex = 0;
            LoadQuestion();
        }

        protected void buttonNext_Click(object sender, EventArgs e)
        {
            LoadQuestion();
        }
    }
}