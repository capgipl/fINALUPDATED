<%@ Page Title="" Language="C#" MasterPageFile="~/Admin1.Master" AutoEventWireup="true" CodeBehind="Employee Registration.aspx.cs" Inherits="Presentation_Layer.Account.Admin.Employee_Registration" %>
<%@ MasterType VirtualPath="~/Admin1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

   <div class="media">
    <div class="media-left media-middle">
     <%--<img src="Images\ipl3.jpg" alt="Chicago" style="width:100%;">--%>
    </div>
    <div class="media-body">     
        <center>
   <div style="height:100%" class="panel panel-default" >
       <div class="panel panel-info">
       <div class="panel-heading"> <h3>Employee Registration</h3></div></div>
   
    
       <div class="panel-body">
       <table style="text-align:center">
           <tr  style="height:100%;margin:10%">
         <td style="text-align:right"><asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">UserName:</asp:Label></td>
         <td><asp:TextBox runat="server" class="col-xs-3" ID="UserName" CssClass="form-control" ></asp:TextBox></td>
         <td> <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="The FirstName field is required." /></td>
     </tr>
     <tr  style="height:100%;margin:10%">
         <td style="text-align:right"><asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">FirstName:</asp:Label></td>
         <td><asp:TextBox runat="server" class="col-xs-3" ID="FirstName" CssClass="form-control" ></asp:TextBox></td>
         <td> <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The FirstName field is required." /></td>
     </tr>
     <tr style="height:100%;margin:10%">
         <td><asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">LastName:</asp:Label></td>
         <td><asp:TextBox runat="server"  class="col-xs-3" CssClass="form-control"  ID="LastName"></asp:TextBox></td>
         <td><asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-danger" ErrorMessage="The Last Name field is required." /></td>
     </tr>
     <tr style="height:100%;margin:10%">
         <td style="width:40%">      <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password:</asp:Label></td>
         <td><asp:TextBox runat="server" class="col-xs-3"  TextMode="Password" CssClass="form-control" ID="Password"></asp:TextBox></td>
         <td> <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." /></td>
     </tr>
   
     <tr><td><br /></td></tr>
     <tr>
       <td></td>
         <td style="margin:100%"><asp:Button runat="server" class="btn btn-primary" Text="Register" OnClick="Unnamed9_Click"/>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
             
         <asp:Button runat="server"   class="btn btn-primary" Text="Clear" OnClick="Unnamed10_Click" /></td>
     </tr>
 </table>
   </div>
    
    </div>
    

            </center>
          </div>
  </div>
</asp:Content>
