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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PortraitClicked(object sender, CommandEventArgs e)
        {
            String chosenChar = e.CommandName;
            Response.Redirect("~/FrameData.aspx?character=" + chosenChar);
        }
    }
}