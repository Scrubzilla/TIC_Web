using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIC_Web.Database;

namespace TIC_Web
{
    public partial class FrameData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            //If if is the first time the page is loaded, force-bind the character list to the database to make sure it contains items. 
            if (!IsPostBack){
                string selectedCharacter = Request.QueryString["character"];
                characterList.DataBind();

                //Check if the selected character from the URL exists, if it does, select the correct character.
                if (characterList.Items.FindByText(selectedCharacter.ToString()) != null){
                    characterList.Items.FindByText(selectedCharacter.ToString()).Selected = true;
                }

                LoadAllMovesForCharacter(selectedCharacter);
            }
        }
        
        //Refresh the movelist with the moves that match the specified search requirements.
        protected void RefreshMoves(object sender, EventArgs e){
            if (Page.IsValid){
                string character = characterList.SelectedValue;
                string property = movePropertyList.SelectedValue;
                string sorting = sortingFilter.SelectedValue;
                bool isSpecific = specFrame.Checked;
                string searchText = searchField.Text;

                System.Diagnostics.Debug.WriteLine(searchText + " - length -" + searchText.Length);

                if (searchText.Length != 0){
                    if (property.Equals("Command") || property.Equals("HitLevel")){
                        DatabaseManager dbm = new DatabaseManager();
                        DataSet tableContent = dbm.GetTextMoveSearch(character, property, sorting, isSpecific, searchText);
                        MoveList.EmptyDataText = "No moves were found!";
                        MoveList.DataSource = tableContent;
                        MoveList.DataBind();
                    }
                    else{
                        bool inputIsNumber = int.TryParse(searchText, out int inputNum);

                        if (property.Equals("TotalDamage")){
                            DatabaseManager dbm = new DatabaseManager();
                            DataSet tableContent = dbm.GetNumSearchMoves(character, property, sorting, isSpecific, searchText);
                            MoveList.EmptyDataText = "No moves were found!";
                            MoveList.DataSource = tableContent;
                            MoveList.DataBind();
                        }
                        else {
                            if (inputIsNumber == true){
                                if (property.Equals("StartUpFrame")) {
                                    property = "StartUpFrameCalc";
                                } else if (property.Equals("BlockFrame")) {
                                    property = "BlockFrameCalc";
                                } else if(property.Equals("HitFrame")){
                                    property = "HitFrameCalc";
                                } else if(property.Equals("CHFrame")){
                                    property = "CHFrameCalc";
                                }

                                DatabaseManager dbm = new DatabaseManager();
                                DataSet tableContent = dbm.GetNumSearchMoves(character, property, sorting, isSpecific, searchText);
                                MoveList.EmptyDataText = "No moves were found!";
                                MoveList.DataSource = tableContent;
                                MoveList.DataBind();
                            }
                            else{
                                if (property.Equals("StartUpFrame")){
                                    property = "StartUpFrameDisplay";
                                }
                                else if (property.Equals("BlockFrame")){
                                    property = "BlockFrameDisplay";
                                }
                                else if (property.Equals("HitFrame")){
                                    property = "HitFrameDisplay";
                                }
                                else if (property.Equals("CHFrame")){
                                    property = "CHFrameDisplay";
                                }

                                DatabaseManager dbm = new DatabaseManager();
                                DataSet tableContent = dbm.GetTextMoveSearch(character, property, sorting, isSpecific, searchText);
                                MoveList.EmptyDataText = "No moves were found!";
                                MoveList.DataSource = tableContent;
                                MoveList.DataBind();
                            }
                        }
                    }
                }
                else{
                    Response.Redirect("~/FrameData.aspx?character=" + character);
                }
            }

        }

        //Fill the movelist with all of the moves for a specified character.
        private void LoadAllMovesForCharacter(String selectedCharacter){
            string character = selectedCharacter;

            DatabaseManager dbm = new DatabaseManager();
            DataSet tableContent = dbm.GetAllMovesForCharacter(character);
            MoveList.EmptyDataText = "No moves were found!";
            MoveList.DataSource = tableContent;
            MoveList.DataBind();
        }

        protected void ValidationOfSearch(object source, ServerValidateEventArgs args) {
            System.Diagnostics.Debug.WriteLine("1");
            if (movePropertyList.SelectedValue.Equals("TotalDamage")){
                //Only allow numbers and the max length is 3.
                System.Diagnostics.Debug.WriteLine("2");
                string strRegex = @"^([0-9]){0,3}$";
                CustomValidator1.ErrorMessage = "When searching for damage, remember to: \n*Only use numbers \n*Be below the character limit 3.";
                Regex regex = new Regex(strRegex);
                System.Diagnostics.Debug.WriteLine("3");
                args.IsValid = regex.IsMatch(args.Value);
                System.Diagnostics.Debug.WriteLine("4");
            }
            else {
                string strRegex = "";
                System.Diagnostics.Debug.WriteLine("5");
                //If the fields command or hitlevel are selected, max length is 15 otherwise length is 8.
                if (movePropertyList.SelectedValue.Equals("Command") || movePropertyList.SelectedValue.Equals("HitLevel")){
                    strRegex = @"^([A-Za-z0-9\,\.\-\+\~\(\)\[\]\!\*\?]){0,15}$";
                    CustomValidator1.ErrorMessage = "When searching, you can only use: \n*Letters, numbers and certain special characters. \n*Length must be 15 or below.";
                    System.Diagnostics.Debug.WriteLine("6");
                }
                else {
                    System.Diagnostics.Debug.WriteLine("7");
                    strRegex = @"^([A-Za-z0-9\,\.\-\+\~\(\)\[\]\!\*\?]){0,8}$";
                    CustomValidator1.ErrorMessage = "When searching, you can only use: \n*Letters, numbers and certain special characters. \n*Length must be 8 or below.";
                    System.Diagnostics.Debug.WriteLine("8");
                }
                System.Diagnostics.Debug.WriteLine("9");
                Regex regex = new Regex(strRegex);
                args.IsValid = regex.IsMatch(args.Value);
                System.Diagnostics.Debug.WriteLine("10");
            }
        }

    }
}

//Add tekken vocab for certain search conditions
//Add damage search
//add numbers to command/hitlevel search



/*
if (movePropertyList.SelectedValue.Equals("StartUpFrameCalc") || movePropertyList.SelectedValue.Equals("BlockFrameCalc") || movePropertyList.SelectedValue.Equals("HitFrameCalc") || movePropertyList.SelectedValue.Equals("CHFrameCalc")) {
string strRegex = @"^[\-,\+,0-9][0-9]*$";
CustomValidator1.ErrorMessage = "You can only use numbers and -/+ in the first space!";
Regex regex = new Regex(strRegex);
args.IsValid = regex.IsMatch(args.Value);
}
else {
string strRegex = @"([A-Za-z,])+";
CustomValidator1.ErrorMessage = "Only use letters please!";
Regex regex = new Regex(strRegex);
args.IsValid = regex.IsMatch(args.Value);
}

bool test = int.TryParse("", out int num);

if(test == true) {
Console.WriteLine(num);
}
*/
