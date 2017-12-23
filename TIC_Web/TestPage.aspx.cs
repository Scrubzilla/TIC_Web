using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIC_Web.Database;

namespace TIC_Web
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "Refreshed at " + DateTime.Now.ToString();
           

            TextBox txt = new TextBox
            {
                ID = "inputBox",
                CssClass = "form-control"
            };

            Panel1.Controls.Add(txt);
        }

        protected void LoadDynContent(object sender, EventArgs e)
        {
            DatabaseManager dbm = new DatabaseManager();
            string selectedTable = DropDownList5.SelectedValue;
            DataSet ds = dbm.GetColumnsForTable(selectedTable);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            List<string> columns = new List<string>();

            foreach (DataRow drr in dt.Rows)
            {
                columns.Add(drr["COLUMN_NAME"].ToString());
            }

            for (int i = 0; i < columns.Count; i++)
            {

                TextBox txt = new TextBox
                {
                    ID = "box" + columns.ElementAt(i),
                    CssClass = "form-control"
                };

                Label lab = new Label
                {
                    ID = "lab" + columns.ElementAt(i),
                    Text = columns.ElementAt(i),
                    AssociatedControlID = "box" + columns.ElementAt(i),
                    CssClass = "col-md-2 control-label"
                };

                Panel1.Controls.Add(lab);
                Panel1.Controls.Add(txt);
                Panel1.Controls.Add(new LiteralControl("<br />"));
                //UpdatePanel1.Update();
            }

        }
    }
}