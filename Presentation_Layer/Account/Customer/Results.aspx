<%@ Page Title="" Language="C#" MasterPageFile="~/Customer_Master.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="Presentation_Layer.Account.Customer.Results" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>


    <center>
    <div style="height:100%;" class="panel panel-default" >
       <div class="panel panel-info">
       <div class="panel-heading"> <h3>IPL Results</h3></div></div>
   
    
       <div class="panel-body" >
       
           <div>
           
               <asp:Label Text="Search:" style="text-align:right" runat="server"></asp:Label>
               <asp:TextBox style="text-align:left" OnTextChanged="searchtxt1_TextChanged"  runat="server" ID="searchtxt2" AutoPostBack="true" ></asp:TextBox><i class="fa fa-search"></i>
                 <button style="text-align:left" class="btn btn-primary" onclick="btnrefresh"><span class="glyphicon glyphicon-refresh"></span> Refresh</button>
           </div>
           <br /><br />
           <div style="width: 50%; height: 290px;" >
  <asp:Panel runat="server" ID="panel1">
             <asp:GridView ID="GridView2" runat="server" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" AllowPaging="True" AllowSorting="True">
                 <Columns>
                     <asp:BoundField DataField="TeamName" HeaderText="TeamName" SortExpression="TeamName" />
                     <asp:BoundField DataField="Played" HeaderText="Played" SortExpression="Played" />
                     <asp:BoundField DataField="Won" HeaderText="Won" SortExpression="Won" />
                     <asp:BoundField DataField="Lost" HeaderText="Lost" SortExpression="Lost" />
                     <asp:BoundField DataField="Tied" HeaderText="Tied" SortExpression="Tied" />
                     <asp:BoundField DataField="NR" HeaderText="NR" SortExpression="NR" />
                     <asp:BoundField DataField="NetRR" HeaderText="NetRR" SortExpression="NetRR" />
                     <asp:BoundField DataField="Pts" HeaderText="Pts" SortExpression="Pts" />
                     <asp:BoundField DataField="FromPoints" HeaderText="FromPoints" SortExpression="FromPoints" />
                 </Columns>
             </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT TeamName, Played, Won, Lost, Tied, NR, NetRR, Pts, FromPoints FROM IPL_MGMT_SYSTEM.Stat"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT StatId, TeamId, Played, Won, Lost, Tied, NR, NetRR, Pts, FromPoints, TeamName FROM IPL_MGMT_SYSTEM.Stat"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT PlayerName, Age, Role, BattingStyle, BowlingStyle, BirthPlace, TeamName FROM IPL_MGMT_SYSTEM.Player">

                </asp:SqlDataSource>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT TeamId, TeamName, HomeGround, Owners, LogoImage FROM IPL_MGMT_SYSTEM.Team"></asp:SqlDataSource>
   
      </asp:Panel>
               <asp:Panel runat="server" ID="panel2">
         <asp:GridView ID="GridView1" runat="server" CssClass= "table table-striped table-bordered table-condensed" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource5">
             <Columns>
                 <asp:BoundField DataField="TeamName" HeaderText="TeamName" SortExpression="TeamName" />
                 <asp:BoundField DataField="Played" HeaderText="Played" SortExpression="Played" />
                 <asp:BoundField DataField="Won" HeaderText="Won" SortExpression="Won" />
                 <asp:BoundField DataField="Lost" HeaderText="Lost" SortExpression="Lost" />
                 <asp:BoundField DataField="Tied" HeaderText="Tied" SortExpression="Tied" />
                 <asp:BoundField DataField="NR" HeaderText="NR" SortExpression="NR" />
                 <asp:BoundField DataField="NetRR" HeaderText="NetRR" SortExpression="NetRR" />
                 <asp:BoundField DataField="Pts" HeaderText="Pts" SortExpression="Pts" />
                 <asp:BoundField DataField="FromPoints" HeaderText="FromPoints" SortExpression="FromPoints" />
             </Columns>
                   </asp:GridView>
                 
                   <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT TeamName, Played, Won, Lost, Tied, NR, NetRR, Pts, FromPoints  FROM IPL_MGMT_SYSTEM.Stat WHERE (TeamName = @TeamName)">
                       <SelectParameters>
                           <asp:ControlParameter ControlID="searchtxt2" Name="TeamName" PropertyName="Text" />
                       </SelectParameters>
                   </asp:SqlDataSource>
                 
               </asp:Panel>
           </div>
    </div>
    </div>   

            </center>
</asp:Content>

