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
    public partial class CharacterInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedCharacter = Request.QueryString["character"];
            GetDefaultInformation(selectedCharacter);
        }

        private void GetDefaultInformation(String inputCharacter) {
            String[] attributes = {"CharacterName", "Portrait", "Description"};
            String character = inputCharacter;

 
            DatabaseManager dbm = new DatabaseManager();
            DataSet ds = dbm.GetMultipleAttrForCharacter(attributes, character);
            DataTable dt = new DataTable();
            dt = ds.Tables["Characters"];

            string dataTest = "";
            DataRow dr = ds.Tables[0].Rows[0];

            System.Diagnostics.Debug.WriteLine(dr["CharacterName"]);
            System.Diagnostics.Debug.WriteLine(dr["Description"]);

            // foreach (DataRow dr in dt.Rows)
            //{
            // dataTest = dataTest + dr["CharacterName"].ToString();    
            //}

            //Set character portrait
            //Set character name
            //Set character description
        }
        
    }
}