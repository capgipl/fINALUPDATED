<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Presentation_Layer.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--<h2><%: Title %>.</h2>--%>
    <h2></h2>
    <h1></h1>
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
       <div class="panel-heading"> <h3>Create New Account</h3></div></div>
   
    
       <div class="panel-body">
       <table>
     <tr  style="height:100%;margin:10%">
         <td><asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">FirstName:</asp:Label></td>
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
         <td><asp:TextBox runat="server" TextMode="Password" class="col-xs-3"  CssClass="form-control" ID="Password"></asp:TextBox></td>
         <td> <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." /></td>
     </tr>
     <tr style="margin:10%">
         <td>    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">ConfirmPassword:</asp:Label></td>
         <td><asp:TextBox runat="server" TextMode="Password" class="col-xs-3" CssClass="form-control" ID="ConfirmPassword"></asp:TextBox></td>
         <td>  <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." /></td>
     </tr>
     <tr><td><br /></td></tr>
     <tr>
       <td></td>
         <td style="margin:100%"><asp:Button runat="server" OnClick="CreateUser_Click" class="btn btn-primary" Text="Register"/>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
             
         <asp:Button runat="server"   class="btn btn-primary" Text="Clear" OnClick="Unnamed11_Click" /></td>
     </tr>
 </table>
   </div>
    
    </div>
    

            </center>
          </div>
  </div>
</asp:Content>
