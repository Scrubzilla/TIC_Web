using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TIC_Web.Database
{
    public class DatabaseManager
    {
        //Get all moves where a certain property matches the rquirements.
        public DataSet GetNumSearchMoves(String character, String property, String sortCondition, bool specFrame, String searchValue)
        {
            string sortBy = "";

            if (sortCondition.Equals("Ascending"))
            {
                sortBy = "ORDER BY " + property + " ASC";
            }
            else if (sortCondition.Equals("Descending"))
            {
                sortBy = "ORDER BY " + property + " DESC";
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();
            SqlDataAdapter adapter = null;
            
            if (specFrame == true){
                adapter = new SqlDataAdapter("SELECT * FROM moves WHERE CharacterName = '" + character + "' AND " + property + " = '" + searchValue + "' " + sortBy, conn);
            } else{
                int value = Int32.Parse(searchValue);

                if (value < 0){
                    adapter = new SqlDataAdapter("SELECT * FROM moves WHERE CharacterName = '" + character + "' AND " + property + " <= '" + searchValue + "' " + sortBy, conn);
                } else if (value >= 0){
                    adapter = new SqlDataAdapter("SELECT * FROM moves WHERE CharacterName = '" + character + "' AND " + property + " >= '" + searchValue + "' " + sortBy, conn);
                }
            }

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            return ds;
        }

        public DataSet TestMethod(String character, String property, String sortCondition, bool specFrame, String searchValue) {

            String command = "SELECT * FROM moves WHERE CharacterName = @charName";
            String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            using (SqlConnection conn = new SqlConnection(connectionString)){
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@charName", character);

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();

                return ds;

            }
        }

        public DataSet GetTextMoveSearch(String character, String property, String sortCondition, bool specFrame, String searchValue){
            string sortBy = "";

            if (sortCondition.Equals("Ascending")){
                sortBy = "ORDER BY " + property + " ASC";
            }
            else if (sortCondition.Equals("Descending")){
                sortBy = "ORDER BY " + property + " DESC";
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();
            SqlDataAdapter adapter = null;

            if (specFrame == true){
                adapter = new SqlDataAdapter("SELECT * FROM Moves WHERE CharacterName = '" + character + "' AND " + property + " = '" + searchValue + "' " + sortBy, conn);
            }
            else{
                adapter = new SqlDataAdapter("SELECT * FROM Moves WHERE CharacterName = '" + character + "' AND " + property + " LIKE '%" + searchValue + "%' " + sortBy, conn);
            }

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            return ds;
        }

        //Get all of the moves and the moves attributes for a character
        public DataSet GetAllMovesForCharacter(String character){
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Command, HitLevel, Damage, StartUpFrameDisplay, BlockFrameDisplay, HitFrameDisplay, CHFrameDisplay FROM Moves WHERE CharacterName='" + character + "'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            return ds;
        }

        //Get a single columns from the character table.
        public DataSet GetAttrForCharacter(String attribute, String character){
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT " + attribute + " FROM Characters WHERE CharacterName='" + character + "'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            return ds;
        }

        //Get multiple columns from the character table.
        public DataSet GetMultipleAttrForCharacter(String[] attributes, String character){

            System.Diagnostics.Debug.WriteLine("Test");
            String cmdAttributes = "";

            for (int i = 0; i < attributes.Length; i++){
                if (i == 0)
                {
                    cmdAttributes = attributes[i];
                }
                else
                {
                    cmdAttributes = cmdAttributes + ", " + attributes[i];
                }
            }

            System.Diagnostics.Debug.WriteLine(cmdAttributes);

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT " + cmdAttributes + " FROM Characters WHERE CharacterName='" + character + "'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            return ds;
        }

        public DataSet GetColumnsForTable(string tableName){
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + tableName + "'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            return ds;
        }

    }


}