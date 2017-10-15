using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIC_Web
{
    public partial class CharacterSelect : System.Web.UI.Page
    {

        private String section = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            section = Request.QueryString["section"];

        }

        protected void PortraitClicked(object sender, CommandEventArgs e)
        {
            String chosenChar = e.CommandName;

            if (section != null ){
                if (section.Equals("framedata"))
                {
                    Response.Redirect("~/FrameData.aspx?character=" + chosenChar);
                }
                else if (section.Equals("charinfo"))
                {
                    Response.Redirect("~/Default");
                }
                else
                {

                    Console.WriteLine("Error, section does not exist!");
                }
            }



        }
    }
}