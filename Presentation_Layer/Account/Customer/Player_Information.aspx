<%@ Page Title="" Language="C#" MasterPageFile="~/Customer_Master.Master" AutoEventWireup="true" CodeBehind="Player_Information.aspx.cs" Inherits="Presentation_Layer.Account.Customer.Player_Information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br />
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

   
        <center>
   <div style="height:100%;" class="panel panel-default" >
       <div class="panel panel-info">
       <div class="panel-heading"> <h3>Player Info</h3></div></div>
   
    
       <div class="panel-body" >
       
           <div>
           
               <asp:Label Text="Search:" style="text-align:right" runat="server"></asp:Label>
               <asp:TextBox style="text-align:left" OnTextChanged="searchtxt1_TextChanged" runat="server" ID="searchtxt1" AutoPostBack="true" ></asp:TextBox><i class="fa fa-search"></i>
                 <button style="text-align:left" onclick="btnrefresh" class="btn btn-primary"><span class="glyphicon glyphicon-refresh"></span> Refresh</button>
           </div>
           <br /><br />
           <div style="width: 50%; height: 290px;" >
  <asp:Panel runat="server" ID="panel1">
                <asp:GridView ID="gvTeam" 
 runat="server" AllowPaging="True"  CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False"  DataSourceID="SqlDataSource2" AllowSorting="True">
           
                    <Columns>
                       
                        <asp:BoundField DataField="PlayerName"  HeaderText="PlayerName" SortExpression="PlayerName" />
                        <asp:BoundField DataField="Age"  HeaderText="Age" SortExpression="Age" />
                       
                        <asp:BoundField DataField="Role"  HeaderText="Role" SortExpression="Role" />
                        <asp:BoundField DataField="BattingStyle"  HeaderText="BattingStyle" SortExpression="BattingStyle" />
                        <asp:BoundField DataField="BowlingStyle"  HeaderText="BowlingStyle" SortExpression="BowlingStyle" />
                        <asp:BoundField DataField="BirthPlace"  HeaderText="BirthPlace" SortExpression="BirthPlace" />
                        <asp:BoundField DataField="TeamName"  HeaderText="TeamName" SortExpression="TeamName" />
                    </Columns>
           
       </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT PlayerName, Age, Role, BattingStyle, BowlingStyle, BirthPlace, TeamName FROM IPL_MGMT_SYSTEM.Player">

                </asp:SqlDataSource>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT TeamId, TeamName, HomeGround, Owners, LogoImage FROM IPL_MGMT_SYSTEM.Team"></asp:SqlDataSource>
   
      </asp:Panel>
               <asp:Panel runat="server" ID="panel2">
                  <asp:GridView ID="GridView1" runat="server" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" AllowPaging="True" AllowSorting="True">
                      <Columns>
                          <asp:BoundField DataField="PlayerName"  HeaderText="PlayerName" SortExpression="PlayerName" />
                          <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                          <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                          <asp:BoundField DataField="BattingStyle"  HeaderText="BattingStyle" SortExpression="BattingStyle" />
                          <asp:BoundField DataField="BowlingStyle" HeaderText="BowlingStyle" SortExpression="BowlingStyle" />
                          <asp:BoundField DataField="BirthPlace"  HeaderText="BirthPlace" SortExpression="BirthPlace" />
                          <asp:BoundField DataField="TeamName" HeaderText="TeamName" SortExpression="TeamName" />
                      </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT PlayerName, Age, Role, BattingStyle, BowlingStyle, BirthPlace, TeamName FROM IPL_MGMT_SYSTEM.Player WHERE (PlayerName = @PlayerName)">
                       <SelectParameters>
                           <asp:ControlParameter ControlID="searchtxt1" Name="PlayerName" PropertyName="Text" />
                       </SelectParameters>
                   </asp:SqlDataSource>
               </asp:Panel>
           </div>
    </div>
    </div>   

            </center>
</asp:Content>

