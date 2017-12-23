using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIC_Web.Database;
using TIC_Web.Models;

namespace TIC_Web.Account
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Creates a new role and adds it to the database.
        protected void CreateRole(object sender, EventArgs e)
        {
            ApplicationDbContext dbcontext = new ApplicationDbContext();
            var role = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new Microsoft.AspNet.Identity.EntityFramework.RoleStore<IdentityRole>(dbcontext));

            String roleName = RoleNameBox.Text;
            var roleresult = role.Create(new IdentityRole(roleName));

            if (roleresult.Succeeded)
            {
                StatusLabel.Text = "Role " + roleName + " was successfully created!\nA container for the role was also created!";
            }
            else
            {
                StatusLabel.Text = "Unable to create the role " + roleName + " because it already exists!";
            }
        }

        //Changes a user's role to the selected one.
        protected void ChangeUserRole(object sender, EventArgs e)
        {
            ApplicationDbContext dbcontext = new ApplicationDbContext();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            String userId = DropDownList1.SelectedValue;
            String role = DropDownList2.SelectedValue;

            IList<String> roleArray = manager.GetRoles(userId);

            var removeResult = manager.RemoveFromRole(userId, roleArray.ElementAt(0));

            if (removeResult.Succeeded)
            {
                dbcontext.SaveChanges();
                var result = manager.AddToRole(userId, role);

                if (!result.Succeeded)
                {

                    StatusLabel2.Text = result.Errors.FirstOrDefault();

                }
                else
                {
                    dbcontext.SaveChanges();
                }
            }
            else
            {
                StatusLabel2.Text = removeResult.Errors.FirstOrDefault();
            }
        }

        protected void LoadDynContent(object sender, EventArgs e){
            DatabaseManager dbm = new DatabaseManager();
            string selectedTable = TableList.SelectedValue;
            DataSet ds = dbm.GetColumnsForTable(selectedTable);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            List<string> columns = new List<string>();

            foreach (DataRow drr in dt.Rows){
                columns.Add(drr["COLUMN_NAME"].ToString());
            }

            for (int i = 0; i < columns.Count; i++) {

                TextBox txt = new TextBox{
                    ID = "box" + columns.ElementAt(i),
                    CssClass = "form-control"
                };

                Label lab = new Label{
                    ID = "lab" + columns.ElementAt(i),
                    Text = columns.ElementAt(i),
                    AssociatedControlID = "box" + columns.ElementAt(i),
                    CssClass = "col-md-2 control-label"
                };

                Panel4.Controls.Add(new LiteralControl("<br />"));
                Panel4.Controls.Add(lab);
                Panel4.Controls.Add(txt);
                
                //UpdatePanel1.Update();
            }

        }

        private void AddMove()
        {

        }

        private void RemoveMove()
        {

        }

        private void ModifyMove()
        {

        }
    }
}