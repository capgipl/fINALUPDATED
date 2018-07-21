<%@ Page Title="" Language="C#" MasterPageFile="~/Customer_Master.Master" AutoEventWireup="true" CodeBehind="Team_Info.aspx.cs" Inherits="Presentation_Layer.Account.Customer.Team_Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <style>
        .st{
             width: 50%;
   border: 0px none;
    border-collapse: collapse;
        }
    </style>

      <br /><br />
     <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

   
        <center>
   <div style="height:100%;" class="panel panel-default" >
       <div class="panel panel-info">
       <div class="panel-heading"> <h3>TEAM INFO</h3></div></div>
   
    
       <div class="panel-body" >
       
           <div>
           
               <asp:Label Text="Search:" style="text-align:right" runat="server"></asp:Label>
               <asp:TextBox style="text-align:left" runat="server" ID="searchtxt" AutoPostBack="true" OnTextChanged="searchtxt_TextChanged"></asp:TextBox><i class="fa fa-search"></i>
                 <button style="text-align:left" class="btn btn-primary"><span class="glyphicon glyphicon-refresh"></span> Refresh</button>
           </div>
           <br /><br />
           <div style="width: 50%; height: 290px;" >
  <asp:Panel runat="server" ID="panel1">
                <asp:GridView ID="gvTeam" 
 runat="server" AllowPaging="True"  CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="TeamId" DataSourceID="SqlDataSource1" AllowSorting="True">
           <Columns>
               <asp:BoundField DataField="TeamName"  HeaderText="TeamName" SortExpression="TeamName" />
               <asp:BoundField DataField="HomeGround"   HeaderText="HomeGround" SortExpression="HomeGround" />
               <asp:BoundField DataField="Owners"  HeaderText="Owners" SortExpression="Owners" />
           </Columns>
       </asp:GridView>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT TeamId, TeamName, HomeGround, Owners, LogoImage FROM IPL_MGMT_SYSTEM.Team"></asp:SqlDataSource>
   
      </asp:Panel>
               <asp:Panel runat="server" ID="panel2">
                  <asp:GridView ID="GridView1" CssClass= "table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True">
                      <Columns>
                          <asp:BoundField DataField="TeamName" HeaderText="TeamName" SortExpression="TeamName" />
                          <asp:BoundField DataField="HomeGround"  HeaderText="HomeGround" SortExpression="HomeGround" />
                          <asp:BoundField DataField="Owners"  HeaderText="Owners" SortExpression="Owners" />
                      </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT TeamName, HomeGround, Owners FROM IPL_MGMT_SYSTEM.Team WHERE (TeamName = @TeamName)">
                       <SelectParameters>
                           <asp:ControlParameter ControlID="searchtxt" Name="TeamName" PropertyName="Text" />
                       </SelectParameters>
                   </asp:SqlDataSource>
               </asp:Panel>
           </div>
    </div>
    </div>   

            </center>
</asp:Content>
