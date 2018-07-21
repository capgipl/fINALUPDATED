<%@ Page Title="" Language="C#" MasterPageFile="~/Customer_Master.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Presentation_Layer.Account.Customer.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>


    <center>
    <div style="height:100%;" class="panel panel-default" >
       <div class="panel panel-info">
       <div class="panel-heading"> <h3>IPL Schedule</h3></div></div>
   
    
       <div class="panel-body" >
       
           <div>
           
               <asp:Label Text="Search:" style="text-align:right" runat="server"></asp:Label>
               <asp:TextBox style="text-align:left" OnTextChanged="searchtxt1_TextChanged"  runat="server" ID="searchtxt1" AutoPostBack="true" ></asp:TextBox><i class="fa fa-search"></i>
                 <button style="text-align:left" class="btn btn-primary" onclick="btnrefresh"><span class="glyphicon glyphicon-refresh"></span> Refresh</button>
           </div>
           <br /><br />
           <div style="width: 50%; height: 290px;" >
  <asp:Panel runat="server" ID="panel1">
               <asp:GridView ID="Gridvw" runat="server"  CssClass= "table table-striped table-bordered table-condensed" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                   <Columns>
                       <asp:BoundField DataField="MatchName" HeaderText="MatchName" SortExpression="MatchName" />
                       <asp:BoundField DataField="VenueName" HeaderText="VenueName" SortExpression="VenueName" />
                       <asp:BoundField DataField="ScheduleDate" HeaderText="ScheduleDate" SortExpression="ScheduleDate" />
                       <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" />
                       <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" />
                   </Columns>
               </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT  MatchName, VenueName, ScheduleDate, StartTime, EndTime FROM IPL_MGMT_SYSTEM.Schedule"></asp:SqlDataSource>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT MatchName, VenueName, ScheduleDate, StartTime, EndTime FROM IPL_MGMT_SYSTEM.Schedule"></asp:SqlDataSource>
                
      </asp:Panel>
               <asp:Panel runat="server" ID="panel2">
                <asp:GridView ID="GridView1" runat="server"  CssClass= "table table-striped table-bordered table-condensed" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                    <Columns>
                        <asp:BoundField DataField="MatchName" HeaderText="MatchName" SortExpression="MatchName" />
                        <asp:BoundField DataField="VenueName" HeaderText="VenueName" SortExpression="VenueName" />
                        <asp:BoundField DataField="ScheduleDate" HeaderText="ScheduleDate" SortExpression="ScheduleDate" />
                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" />
                        <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" />
                    </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT MatchName, VenueName, ScheduleDate, StartTime, EndTime  FROM IPL_MGMT_SYSTEM.Schedule WHERE (MatchName = @MatchName)">
                       <SelectParameters>
                           <asp:ControlParameter ControlID="searchtxt1" Name="MatchName" PropertyName="Text" />
                       </SelectParameters>
                   </asp:SqlDataSource>
               </asp:Panel>
           </div>
    </div>
    </div>   

            </center>
</asp:Content>