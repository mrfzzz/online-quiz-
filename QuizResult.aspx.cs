using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectdotnetquiz.Masterpage
{
    public partial class QuizResult : System.Web.UI.Page
    {
        private string quizdatabase;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                quizddl.DataSource = getquiz();
                quizddl.DataTextField = "quizname";
                quizddl.DataValueField = "quizid";
                quizddl.DataBind();
            }
        }

        //DATABASE: dbConnectionString is the name in diff pc, change to your pc connection string name. check web.config and change <connection string> there.
        private DataTable getquiz()
        {

            //change to your db 
            string connectionString = "Data Source=LAPTOP-QCRKBQ8S\\SQLEXPRESS;Initial Catalog=quizdatabase;Integrated Security=True;Pooling=False";
            using (SqlConnection con = new SqlConnection(quizdatabase))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT quizid, quizname FROM quiz", con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                //DataTable dt = new DataTable();
            }
        }


        private DataTable getresult(int quizid)
        {
            //change to your db
            SqlConnection con = new SqlConnection("Data Source =LAPTOP-QCRKBQ8S\\SQLEXPRESS; Initial Catalog = quizdata;   Integrated Security = True; Pooling = False");
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT quiznum, youranswer, correctanswer, CASE WHEN youranswer = correctanswer THEN 'True' ELSE 'False' END AS iscorrect FROM quizresponse WHERE quizid = @quizid", con))
                {
                    _ = cmd.Parameters.AddWithValue("@quizid", quizid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    _ = adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // edit
        protected void quizddl_choose(object sender, EventArgs e)
        {
            int selectedquizid = Convert.ToInt32(quizddl.SelectedValue);
            DataTable quizresult = getresult(selectedquizid);

            //gv = gridview,  gridview id in quiz result in aspx
            gvquizresult.DataSource = quizresult;
            gvquizresult.DataBind();

            //calc marks
            int totalmark = calc_marks(quizresult);
            lblmark.Text = totalmark.ToString();
            int fullmark = calc_fullmarks(quizresult);
            lblfullmark.Text = fullmark.ToString();

            //start display marks label
            markinfo.Visible = true;

        }

        private int calc_marks(DataTable quizresult)
        {
            int totalmark = 0;
            foreach (DataRow row in quizresult.Rows)
            {
                if (row["iscorrect"].ToString() == "True")
                {
                    totalmark++;
                }
            }

            return totalmark;
        }

        private int calc_fullmarks(DataTable quizresult)
        {
            int fullmark = 0;
            foreach (DataRow rw in quizresult.Rows)
            {
                fullmark++;
            }

            return fullmark;
        }

    }
}