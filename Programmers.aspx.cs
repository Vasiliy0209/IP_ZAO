using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    enum State {Select, Insert, Update, Delete};
    public partial class Programmers : System.Web.UI.Page
    {
        static State st = State.Select;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            st = State.Insert;
            tb_ID.Text = "";
            tb_Name.Text = "";
            tb_Age.Text = "";
            tb_Email.Text = "";

            btn_OK.Enabled = true;
            btn_Cancel.Enabled = true;
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            st = State.Update;

            int si = GridView1.SelectedIndex;
            if (si < 0) return;

            tb_ID.Text = GridView1.Rows[si].Cells[1].Text;
            tb_Name.Text = GridView1.Rows[si].Cells[2].Text;
            tb_Age.Text = GridView1.Rows[si].Cells[3].Text;
            tb_Email.Text = GridView1.Rows[si].Cells[4].Text;

            btn_OK.Enabled = true;
            btn_Cancel.Enabled = true;
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            int si = GridView1.SelectedIndex;
            if (si < 0) return;

            tb_ID.Text = GridView1.Rows[si].Cells[1].Text;

            SqlDS_Programmers.Delete();

            ClearForm();
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            if (st == State.Insert) SqlDS_Programmers.Insert();
            if (st == State.Update) SqlDS_Programmers.Update();

            ClearForm();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            st = State.Update;

            int si = GridView1.SelectedIndex;
            if (si < 0) return;

            tb_ID.Text = GridView1.Rows[si].Cells[1].Text;
            tb_Name.Text = GridView1.Rows[si].Cells[2].Text;
            tb_Age.Text = GridView1.Rows[si].Cells[3].Text;
            tb_Email.Text = GridView1.Rows[si].Cells[4].Text;

            btn_OK.Enabled = true;
            btn_Cancel.Enabled = true;
        }

        private void ClearForm()
        {
            st = State.Select;
            tb_ID.Text = "";
            tb_Name.Text = "";
            tb_Age.Text = "";
            tb_Email.Text = "";
            btn_OK.Enabled = false;
            btn_Cancel.Enabled = false;
        }

        protected void GV_Languages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int si = GV_Languages.SelectedIndex;
            if (si < 0) return;

            tb_ProgrammerLanguageRowID.Text= GV_Languages.Rows[si].Cells[1].
            //ddl_ProgrammerLanguageID.SelectedValue= GV_Languages.Rows[si].Cells[3].Text;
        }
    }
}