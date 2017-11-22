using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIC_Web{
    public partial class CharacterSelect : System.Web.UI.Page{

        private string section = "";        //Used to remember if the user pressed Frame Data or Character information in the menu


        protected void Page_Load(object sender, EventArgs e){
            section = Request.QueryString["section"];

        }

        protected void PortraitClicked(object sender, CommandEventArgs e){
            string chosenChar = e.CommandName;

            //Goes to the proper section depending on what the user has previously selected.
            if (section != null ){
                if (section.Equals("framedata")){
                    Response.Redirect("~/FrameData.aspx?character=" + chosenChar);
                }
                else if (section.Equals("charinfo")){
                    Response.Redirect("~/CharacterInformation.aspx?character=" + chosenChar);
                }
                else{
                    Console.WriteLine("Error, section does not exist!");
                }
            }
        }
    }
}