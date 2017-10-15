using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIC_Web.Database;

namespace TIC_Web
{
    public partial class FrameData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedCharacter = Request.QueryString["character"];

            if (!IsPostBack) {
                characterList.SelectedValue = selectedCharacter;
            }

            LoadAllMovesForCharacter(selectedCharacter);
        }

        protected void RefreshMoves(object sender, EventArgs e)
        {
            String character = characterList.SelectedValue;
            String property = movePropertyList.SelectedValue;
            String searchText = searchField.Text;

            DatabaseManager dbm = new DatabaseManager();
            DataSet tableContent = dbm.GetMovesForProperty(character, property, searchText);
            GridView1.EmptyDataText = "No moves were found!";
            GridView1.DataSource = tableContent;
            GridView1.DataBind();
        }

        private void LoadAllMovesForCharacter(String selectedCharacter)
        {
            String character = selectedCharacter;

            DatabaseManager dbm = new DatabaseManager();
            DataSet tableContent = dbm.GetAllMovesForCharacter(character);
            GridView1.EmptyDataText = "No moves were found!";
            GridView1.DataSource = tableContent;
            GridView1.DataBind();
        }


    }
}