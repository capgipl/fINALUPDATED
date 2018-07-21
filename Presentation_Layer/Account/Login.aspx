<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentation_Layer.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--<h2><%: Title %>.</h2>--%>

 <br />
    <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
             </asp:PlaceHolder>
   <div class="media">
    <div class="media-left media-middle">
     <%--<img src="Images\ipl3.jpg" alt="Chicago" style="width:100%;">--%>
    </div>
    <div class="media-body">     
        <center>
   <div style="height:100%" class="panel panel-default" >
       <div class="panel panel-info">
       <div class="panel-heading"> <h3>Sign In</h3></div></div>
   
    
       <div class="panel-body">
       <table>
     <tr  style="height:100%;margin:10%">
         <td><asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">UserName</asp:Label></td>
         <td><asp:TextBox runat="server" class="col-xs-3" ID="UserName" CssClass="form-control"></asp:TextBox></td>
         <td>     <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The UserName field is required." />
     </tr>
     <tr style="height:100%;margin:10%">
         <td> <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label></td>
         <td><asp:TextBox runat="server"  class="col-xs-3" CssClass="form-control"  ID="Password" TextMode="Password"></asp:TextBox></td>
         <td><asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The Password field is required." /></td>
     </tr>
     <tr style="height:100%;margin:10%">
         <td style="width:40%">     </td>
         <td> <asp:CheckBox runat="server" ID="RememberMe" />
             <asp:Label runat="server" AssociatedControlID="RememberMe">Remember Me?</asp:Label></td>
         
     </tr>
    
     
     <tr>
       <td></td>
         <td style="margin:100%"><asp:Button runat="server" class="btn btn-primary"  Text="Log In" OnClick="Unnamed6_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
             
         <asp:Button runat="server"   class="btn btn-primary" Text="Clear" OnClick="Unnamed_Click" /></td>
     </tr>
           <tr>
               <td> <br /> <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">
                        <a href="Register.aspx">Register as a new user</a>
                    </asp:HyperLink>
                </p></td>              
           </tr>
 </table>
   </div>
    
    </div>
    

            </center>
          </div>
  </div>
</asp:Content>
