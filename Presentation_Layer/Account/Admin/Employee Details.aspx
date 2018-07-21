<%@ Page Title="" Language="C#" MasterPageFile="~/Admin1.Master" AutoEventWireup="true" CodeBehind="Employee Details.aspx.cs" Inherits="Presentation_Layer.Account.Admin.Employee_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
















    <br />
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

   
        <center>
   <div style="height:100%;" class="panel panel-default" >
       <div class="panel panel-info">
       <div class="panel-heading"> <h3>Employee Info</h3></div></div>
   
    
       <div class="panel-body" >
      
           <br /><br />
           <div style="width: 50%; height: 290px;" >
 <a href="~/Account/Admin/Employee Registration.aspx"   runat="server">Register Employee</a>
    <asp:GridView ID="gvemp" runat="server"  CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="UserId" DataSourceID="SqlDataSource1">
        <Columns>
            
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString3 %>" SelectCommand="SELECT UserId, UserName, Pass, FirstName, LastName FROM IPL_MGMT_SYSTEM.Users WHERE (UserId IN (SELECT UserId FROM IPL_MGMT_SYSTEM.UserRoles WHERE (RoleId = 1)))"></asp:SqlDataSource>
           </div>
    </div>
    </div>   

            </center>

        
    </asp:Content>