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
            if (movePropertyList.SelectedValue.Equals("TotalDamage")){
                //Only allow numbers and the max length is 3.
                string strRegex = @"^([0-9]){0,3}$";
                searchValidator.ErrorMessage = "When searching for damage, remember to: <br>*Only use numbers <br>*Be below the character limit 3.";
                Regex regex = new Regex(strRegex);
                args.IsValid = regex.IsMatch(args.Value);
            }
            else {
                string strRegex = "";
                string property = movePropertyList.SelectedValue;

                //If the fields command or hitlevel are selected, max length is 15 otherwise length is 8.
                if (property.Equals("Command") || property.Equals("HitLevel")){
                    strRegex = @"^([A-Za-z0-9\,\.\-\+\~\(\)\[\]\!\*\?\s]){0,15}$";
                    searchValidator.ErrorMessage = "When searching, you can only use: <br>*Letters, numbers and certain special characters. <br>*Length must be 15 or below.";
                }
                else {
                    strRegex = @"^([A-Za-z0-9\,\.\-\+\~\(\)\[\]\!\*\?\s]){0,8}$";
                    searchValidator.ErrorMessage = "When searching, you can only use: <br>*Letters, numbers and certain special characters. <br>*Length must be 8 or below.";
                }

                Regex regex = new Regex(strRegex);
                args.IsValid = regex.IsMatch(args.Value);
            }
        }

    }
}