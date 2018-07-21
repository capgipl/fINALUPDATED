<%@ Page Title="" Language="C#" MasterPageFile="~/Customer_Master.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Presentation_Layer.Account.Customer.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br /><br />
      <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

   
        <center>
   <div style="height:100%;" class="panel panel-default" >
       <div class="panel panel-info">
       <div class="panel-heading"> <h3>News Info</h3></div></div>
   
    
       <div class="panel-body" >
       
           <div>
           
               <asp:Label Text="Search:" style="text-align:right" runat="server"></asp:Label>
               <asp:TextBox style="text-align:left" runat="server" ID="searchtxt" AutoPostBack="true" OnTextChanged="searchtxt_TextChanged"></asp:TextBox><i class="fa fa-search"></i>
                 <button style="text-align:left" class="btn btn-primary"><span class="glyphicon glyphicon-refresh"></span> Refresh</button>
           </div>
           <br /><br />
           <div style="width: 50%; height: 290px;" >
  <asp:Panel runat="server" ID="panel1">
                <asp:GridView ID="GridView2" runat="server" CssClass= "table table-striped table-bordered table-condensed" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource4">

                    <Columns>
                        <asp:BoundField DataField="MatchName" HeaderText="MatchName" SortExpression="MatchName" />
                        <asp:BoundField DataField="NewsDescription" HeaderText="NewsDescription" SortExpression="NewsDescription" />
                    </Columns>

                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT  MatchName, NewsDescription FROM IPL_MGMT_SYSTEM.News"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT Newsdate,  NewsDescription,  MatchName FROM IPL_MGMT_SYSTEM.News"></asp:SqlDataSource>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString5 %>" SelectCommand="SELECT TeamId, TeamName, HomeGround, Owners, LogoImage FROM IPL_MGMT_SYSTEM.Team"></asp:SqlDataSource>
   
      </asp:Panel>
               <asp:Panel runat="server" ID="panel2">
                  <asp:GridView ID="GridView1" runat="server" CssClass= "table table-striped table-bordered table-condensed" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">

                      <Columns>
                          <asp:BoundField DataField="MatchName" HeaderText="MatchName" SortExpression="MatchName" />
                          <asp:BoundField DataField="NewsDescription" HeaderText="NewsDescription" SortExpression="NewsDescription" />
                      </Columns>

                  </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT  MatchName,NewsDescription FROM IPL_MGMT_SYSTEM.News WHERE (MatchName = @MatchName)">
                       <SelectParameters>
                           <asp:ControlParameter ControlID="searchtxt" Name="MatchName" PropertyName="Text" />
                       </SelectParameters>
                   </asp:SqlDataSource>
               </asp:Panel>
           </div>
    </div>
    </div>   

            </center>
</asp:Content>

