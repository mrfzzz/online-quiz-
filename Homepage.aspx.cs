using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectdotnetquiz.Masterpage
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic
        }
        // Add your homepage logic here

        protected void btnStartQuiz_Click(object sender, EventArgs e)
        {
            // Logic to handle the "Start Quiz" button click
            Response.Redirect("addquiz.aspx");
        }

        protected void btnPlayQuiz_Click(object sender, EventArgs e)
        {
            // Logic to handle the "Play Quiz" button click
            Response.Redirect("quizFormb.aspx");
        }

        protected void btnCheckResult_Click(object sender, EventArgs e)
        {
            // Logic to handle the "Check Result" button click
            Response.Redirect("QuizResult.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Add your logout logic here
            // For example, you may clear the authentication cookie and redirect to the login page
            Session.Clear(); // Clear any session data
            Session.Abandon(); // Abandon the session
            FormsAuthentication.SignOut(); // Sign out the user

            // Redirect to the login page
            Response.Redirect("~/Login.aspx");
        }
    }

}