using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TIC_Web.Database
{
    public class DatabaseManager
    {
        //Get all moves where a certain property matches the rquirements.
        public DataSet GetMovesForProperty(String character, String property, String searchValue)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Moves WHERE CharacterName = '" + character + "' AND " + property + " LIKE '%"  + searchValue + "%'", conn);
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
        public DataSet GetMultipleAttrForCharacter(String[] attributes, String character)
        {

            System.Diagnostics.Debug.WriteLine("Test");
            String cmdAttributes = "";

            for (int i = 0; i < attributes.Length; i++) {
                if (i == 0){
                    cmdAttributes = attributes[i];
                }else {
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

    }


}