using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TIC_Web.Database
{
    public class DatabaseManager
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        //Retrieve all moves from a search where numbers are compared and searched for.
        public DataSet GetNumSearchMoves(string character, string property, string sortCondition, bool isSpecific, string inputValue){
            string sortBy = "";
            string baseCommand = "";

            //Check how the user wants to sort the retrieved values, if null, leave blank and do not sort it.
            if (sortCondition.Equals("Ascending")){
                sortBy = "ORDER BY " + property + " ASC";
            }
            else if (sortCondition.Equals("Descending")){
                sortBy = "ORDER BY " + property + " DESC";
            }

            //If the user searches for a specific value, only retrieve values with that value.
            if (isSpecific == true){
                baseCommand = "SELECT * FROM Moves WHERE CharacterName = @character AND " + property + " = @searchValue " + sortBy;
            }
            else{
                //Convert search to int and check if it is negative or positive
                int value = Int32.Parse(inputValue);

                //Retrieve all values higher than search if the search is positive, if it is negative, retrieve all lesser values than the search.
                if (value < 0){
                    baseCommand = "SELECT * FROM Moves WHERE CharacterName = @character AND " + property + " <= @searchValue " + sortBy;
                }
                else if (value >= 0){
                    baseCommand = "SELECT * FROM Moves WHERE CharacterName = @character AND " + property + " >= @searchValue " + sortBy;
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString)){
                SqlCommand command = new SqlCommand(baseCommand, conn);
                command.Parameters.AddWithValue("@character", character);
                command.Parameters.AddWithValue("@searchValue", inputValue);

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();

                return ds;
            }
        }

        //Retrieve all moves from a search where text is mainly compared and searched for.
        public DataSet GetTextMoveSearch(string character, string property, string sortCondition, bool isSpecific, string inputValue)
        {
            string sortBy = "";
            string baseCommand = "";

            //Check how the user wants to sort the retrieved values, if null, leave blank and do not sort it.
            if (sortCondition.Equals("Ascending"))
            {
                sortBy = "ORDER BY " + property + " ASC";
            }
            else if (sortCondition.Equals("Descending"))
            {
                sortBy = "ORDER BY " + property + " DESC";
            }

            if (isSpecific == true) {
                baseCommand = "SELECT * FROM Moves WHERE CharacterName = @character AND " + property + " = @searchValue " + sortBy;

            } else {
                baseCommand = "SELECT * FROM Moves WHERE CharacterName = @character AND " + property + " LIKE '%' + @searchValue + '%' " + sortBy;
            }

            using (SqlConnection conn = new SqlConnection(connectionString)){
                SqlCommand command = new SqlCommand(baseCommand, conn);
                command.Parameters.AddWithValue("@character", character);
                command.Parameters.AddWithValue("@searchValue", inputValue);

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();

                return ds;
            }
            
        }

        //Get all of the moves and the moves attributes for a character
        public DataSet GetAllMovesForCharacter(String character)
        {
            string baseCommand = "SELECT Command, HitLevel, Damage, StartUpFrameDisplay, BlockFrameDisplay, HitFrameDisplay, CHFrameDisplay FROM Moves WHERE CharacterName = @character";

            using (SqlConnection conn = new SqlConnection(connectionString)){
                SqlCommand command = new SqlCommand(baseCommand, conn);
                command.Parameters.AddWithValue("@character", character);

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();

                return ds;
            }
        }

        //Get a single columns from the character table.
        public DataSet GetAttrForCharacter(String attribute, String character)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT " + attribute + " FROM Characters WHERE CharacterName='" + character + "'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            return ds;
        }

        //Get multiple columns from the character table.
        public DataSet GetMultipleAttrForCharacter(String[] attributes, String character)
        {

            System.Diagnostics.Debug.WriteLine("Test");
            String cmdAttributes = "";

            for (int i = 0; i < attributes.Length; i++)
            {
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

        public DataSet GetColumnsForTable(string tableName)
        {
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