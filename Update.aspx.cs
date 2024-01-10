using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectdotnetquiz.Masterpage
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                if (Session["quizid"] != null)
                {
                    txtbox_Id.Text = Session["quizid"].ToString();
                }

                if (Session["quizname"] != null)
                {
                    string courseValue = Session["quizname"].ToString();
                    ListItem listItem = Name_quiz.Items.FindByText(courseValue);

                    if (listItem != null)
                    {
                        listItem.Selected = true;
                    }
                    else
                    {
                        // Handle the case where the item is not found in the DropDownList.
                        // You might want to log or display an error message.
                    }
                }

                // Corrected typo in session variable name
                if (Session["question"] != null)
                {
                    txtbox_Qna.Text = Session["question"].ToString();
                }
                if (Session["answer"] != null)
                {
                    txtbox_Ans.Text = Session["answer"].ToString();
                }
                if (Session["option1"] != null)
                {
                    txtbox_Oa1.Text = Session["option1"].ToString();
                }
                if (Session["option2"] != null)
                {
                    txtbox_Oa2.Text = Session["option2"].ToString();
                }
                if (Session["option3"] != null)
                {
                    txtbox_Oa3.Text = Session["option3"].ToString();
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            // Enable controls before update
            EnableControls(true);
            Update_DB("update");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Enable controls before update
            EnableControls(true);
            // Restore values from session
            RestoreValuesFromSession();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            Update_DB("delete");
        }

        protected void Update_DB(string strAction)
        {
            string id = txtbox_Id.Text.Trim();
            string Answer = txtbox_Ans.Text;
            string Question = txtbox_Qna.Text;
            string OA1 = txtbox_Oa1.Text;
            string OA2 = txtbox_Oa2.Text;
            string OA3 = txtbox_Oa3.Text;
            string Namequiz = Name_quiz.SelectedItem.Text;

            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-QCRKBQ8S\\SQLEXPRESS; Initial Catalog=QuizDatabase; Integrated Security=True; Pooling=False"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;

                    if (strAction == "update")
                    {
                        cmd = new SqlCommand("UPDATE Quizzes SET QuizName = @quizname WHERE QuizId = @quizid; " +
                                             "UPDATE Questions SET QuestionText = @question, CorrectAnswer = @answer WHERE QuizId = @quizid; " +
                                             "UPDATE Options SET OptionText = @option1 WHERE QuestionId = @questionid; " +
                                             "UPDATE Options SET OptionText = @option2 WHERE QuestionId = @questionid; " +
                                             "UPDATE Options SET OptionText = @option3 WHERE QuestionId = @questionid;", con);

                        cmd.Parameters.AddWithValue("@quizid", id);
                        cmd.Parameters.AddWithValue("@quizname", Namequiz);
                        cmd.Parameters.AddWithValue("@question", Question);
                        cmd.Parameters.AddWithValue("@answer", Answer);
                        cmd.Parameters.AddWithValue("@option1", OA1);
                        cmd.Parameters.AddWithValue("@option2", OA2);
                        cmd.Parameters.AddWithValue("@option3", OA3);
                        cmd.Parameters.AddWithValue("@questionid", id);
                    }
                    else if (strAction == "delete")
                    {
                        cmd = new SqlCommand("DELETE FROM Options WHERE QuestionId = @questionid; " +
                                             "DELETE FROM Questions WHERE QuizId = @quizid; " +
                                             "DELETE FROM Quizzes WHERE QuizId = @quizid;", con);

                        cmd.Parameters.AddWithValue("@quizid", id);
                        cmd.Parameters.AddWithValue("@questionid", id);
                    }
                    else
                    {
                        // Handle other actions if needed
                        return;
                    }

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        lblStatus.Text = strAction == "update" ? "Quiz updated successfully" : "Quiz deleted successfully";
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
        }

        protected void EnableControls(bool enable)
        {
            txtbox_Qna.Enabled = enable;
            txtbox_Id.Enabled = enable;
            txtbox_Ans.Enabled = enable;
            txtbox_Oa1.Enabled = enable;
            txtbox_Oa2.Enabled = enable;
            txtbox_Oa3.Enabled = enable;
            Name_quiz.Enabled = enable;
            ButtonSave.Enabled = enable;
            ButtonDelete.Enabled = enable;
            ButtonCancel.Enabled = enable;
        }

        protected void RestoreValuesFromSession()
        {
            if (Session["quizid"] != null)
            {
                txtbox_Id.Text = Session["quizid"].ToString();
            }

            if (Session["quizname"] != null)
            {
                string courseValue = Session["quizname"].ToString();
                ListItem listItem = Name_quiz.Items.FindByText(courseValue);

                if (listItem != null)
                {
                    listItem.Selected = true;
                }
                else
                {
                    // Handle the case where the item is not found in the DropDownList.
                    // You might want to log or display an error message.
                }
            }

            if (Session["question"] != null)
            {
                txtbox_Qna.Text = Session["question"].ToString();
            }
            if (Session["answer"] != null)
            {
                txtbox_Ans.Text = Session["answer"].ToString();
            }
            if (Session["option1"] != null)
            {
                txtbox_Oa1.Text = Session["option1"].ToString();
            }
            if (Session["option2"] != null)
            {
                txtbox_Oa2.Text = Session["option2"].ToString();
            }
            if (Session["option3"] != null)
            {
                txtbox_Oa3.Text = Session["option3"].ToString();
            }
        }

        protected void txtbox_name_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
    }
}