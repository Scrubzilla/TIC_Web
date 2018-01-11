<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TIC_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Tekken Information Centre - TIC</h2>
    <p>
        Welcome to Tekken Information Centre. This platform is made for the Tekken community to create a central hub for everything that is related to Tekken. All kinds of information regarding Tekken will be organized here, in one place, so that it all is easy to find. Several functions are planned as of now and you can read more about them
            here. The main purpose of this website is to make information more accessible and help players with improving their skill in the game. Lets start improving your game!
       
    </p>

    <div class="frontPageLeft">
        <asp:ImageButton runat="server" ImageUrl="~/Images/System/FrameDataOff.png" onmouseover="this.src='/Images/System/FrameDataOn.png'" onmouseout="this.src='/Images/System/FrameDataOff.png'" CssClass="frontPageBigImage"></asp:ImageButton>
    </div>

    <div class="frontPageRight">
        <asp:ImageButton runat="server" ImageUrl="~/Images/System/LearningOff.png" onmouseover="this.src='/Images/System/LearningOn.png'" onmouseout="this.src='/Images/System/LearningOff.png'" CssClass="frontPageSmallImage"></asp:ImageButton>
        <br />
        <asp:ImageButton runat="server" ImageUrl="~/Images/System/StatisticsOff.png" onmouseover="this.src='/Images/System/StatisticsOn.png'" onmouseout="this.src='/Images/System/StatisticsOff.png'" CssClass="frontPageSmallImage2"></asp:ImageButton>
    </div>

    <div class="frontPageText">
        <h3>Sections</h3>
        <p>
            This page provides several tools and sections to help our users find the information they need quickly, some of these tools are:

        </p>
        <hr />
        <h4>Frame Data</h4>
        <p>
            By using our Frame Data section, you can easily filter and search for what moves you want to see. You only want to see what moves are launch punishable on block? Then just search for -15 on block-frame. It provides an easy way to find the information about the moves that you want to see.
        </p>
        <br />
        <h4>Character Information</h4>
        <p>
            Our character information section is loaded with information about each character and information about what tools you can use to play them, while also providing a nice description of the character. You want to see all of Leo’s pokes? Just pick pokes in the menu and you will immediatly see all of them with information, as well as additional notes of the move. All of this information is reviewed by known Tekken players to make sure that the information is correct.

        </p>
        <br />
        <h4>Statistics</h4>
        <p>
            An upcoming feature if this platform. This section will allow our members to track their online records and provide theoretical answers to when a member will rank up or rank down with a character. The member will pick a character and then for each game that they play, they will fill in who their opponent was, what character was played, what rank they were and the match result. This tool will then calculate and provide a visual answer to how close to a promotion or a demtion that the user are. It will also display statistics agains that specific opponent, like win/loss ratio, top 5 characters and the opponents most played character against the member. 
          
            <br />
            <br />
            More sections are being developed right now and will be available in the future.

        </p>

    </div>

</asp:Content>

