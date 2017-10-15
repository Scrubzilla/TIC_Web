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
        public String GetMove(int id)
        {
            return "";
        }

        public ArrayList GetMovesForCharacter(String characterName)
        {
            ArrayList list = new ArrayList();
            return list;
        }

        public ArrayList GetAllMoves()
        {
            ArrayList list = new ArrayList();
            return list;
        }

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

        public DataSet GetAllMovesForCharacter(String character){
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Command, HitLevel, Damage, StartUpFrameDisplay, BlockFrameDisplay, HitFrameDisplay, CHFrameDisplay FROM Moves WHERE CharacterName='" + character + "'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            return ds;
        }

    }


}