<%@ Page Title="" Language="C#" MasterPageFile="~/Customer_Master.Master" AutoEventWireup="true" CodeBehind="ViewTicket.aspx.cs" Inherits="Presentation_Layer.Account.Customer.ViewTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br /><br />
     <table style="width:100%;text-align:center;">
        <tr>
            <td style="text-align:right;width:50%;">
               
               <asp:Label ID="lblMatchName" runat="server" Text="Match Name : "></asp:Label><br /><br />
                </td>
            <td style="text-align:left;">
                <asp:Label ID="lblMatchName2" runat="server"></asp:Label><br /><br />
            </td>
        </tr>
          <tr>
            <td style="text-align:right;width:50%;">
                <asp:Label ID="lblVenueName" runat="server" Text="Venue : "></asp:Label><br /><br />
                </td>
              <td style="text-align:left;">
               <asp:Label ID="lblVenueName2" runat="server"></asp:Label><br /><br /> 
            </td>
        </tr>
         <tr>
            <td style="text-align:right;width:50%;">
                <asp:Label ID="lblTicketCategory" runat="server" Text="Ticket Category : "></asp:Label><br /><br />
                </td>
             <td style="text-align:left;">
               <asp:Label ID="lblTicketCategory2" runat="server"></asp:Label><br /><br /> 
            </td>
        </tr>
        <tr>
            <td style="text-align:right;width:50%;">
                <asp:Label ID="lblNumberOfTickets" runat="server" Text="Number of Tickets : "></asp:Label><br /><br />
                </td>
            <td style="text-align:left;">
                <asp:Label ID="lblNumberOfTickets2" runat="server"></asp:Label><br /><br />
            </td>
        </tr>
         <tr>
            <td style="text-align:right;width:50%;">
               <asp:Label ID="lblPrice" runat="server" Text="Price : "></asp:Label><br /><br />
                </td>
             <td style="text-align:left;">
                <asp:Label ID="lblPrice2" runat="server"></asp:Label><br /><br />
            </td>
        </tr>
        
    </table>
</asp:Content>
