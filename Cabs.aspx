<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Cabs.aspx.cs" Inherits="Details" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
          <form id="form1" runat="server" aria-checked="true" style="font-family: 'Arial Black'; font-size: large; background-color: #008000; border: thin groove #00FF00; padding: inherit; visibility: visible; list-style-type: circle; line-height: normal; vertical-align: middle; text-align: center; table-layout: inherit;" visible="True">

    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" DataKeyField="id" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" RepeatColumns="3" OnItemCommand="DataList1_ItemCommand">
            <AlternatingItemStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />

 <%--<ItemTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Id") %>'></asp:Literal>
                        </td>
                        <td style="float: right">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Height="400px" ImageAlign="Right" Width="500px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="background-color: #339966; font-family: 'Arial Black'; font-size: x-large; border-style: solid">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("rate") %>'></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #006600; float: right;">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Cabmodel") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Vdetails" runat="server" CommandName="Details" Text="View Details" CommandArgument= '<%#Eval("id") %>' OnClick="Vdetails_Click" />
<br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="BookNow" />
            </ItemTemplate>--%>




       <ItemTemplate>

<div class="w-full h-screen flex justify-center items-center">
   <div>
        <div class="w-96">  
            <div class="shadow hover:shadow-lg transition duration-300 ease-in-out xl:mb-0 lg:mb-0 md:mb-0 mb-6 cursor-pointer group">
                <div class="overflow-hidden relative">
                      <asp:Image ID="Image1" CssClass="w-full transition duration-700 ease-in-out group-hover:opacity-60" runat="server" ImageUrl='<%# Eval("image") %>' Height="400px" ImageAlign="Right" Width="500px" alt="image" />

               
            </div>
            <div class="px-4 py-3 bg-white">
                <a href="#" class=""><h1 class="text-gray-800 font-semibold text-lg hover:text-red-500 transition duration-300 ease-in-out"> <%# Eval("Cabmodel") %></h1></a>
                <div class="flex py-2">
                    <p class="mr-2 text-xs text-gray-600">Rate:- <%# Eval("rate") %></p>
                        
                </div>

                  <div class="px-4 py-3 bg-white">
              
                                            
<asp:Button ID="Vdetails" runat="server" CssClass="auto-style2" CommandName="Details" Text="View Details" CommandArgument= '<%#Eval("id") %>' OnClick="Vdetails_Click" />
                 
<br />
                <asp:Button ID="Button1" runat="server" CssClass="auto-style2" CommandName="Book" CommandArgument= '<%#Eval("id") %>' OnClick="Button1_Click" Text="BookNow" /> 
                </div>

                
               <%-- <div class="flex">
                    <div class="">
                        <i class="fas fa-star text-yellow-400 text-xs"></i>
                        <i class="fas fa-star text-yellow-400 text-xs"></i>
                        <i class="fas fa-star text-yellow-400 text-xs"></i>
                        <i class="fas fa-star text-yellow-400 text-xs"></i>
                        <i class="far fa-star text-gray-400 text-xs"></i>
                    </div>
                    
                </div>--%>
            </div>
            </div>
       </div>
   </div>
</div>

        </ItemTemplate>
       


        </asp:DataList>
              </form>

</asp:Content>




