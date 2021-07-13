<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ViewBookings.aspx.cs" Inherits="ViewBookings" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <%-- <link href="bootstrap.min.css" rel="stylesheet" />--%>
    <link href="tailwind.min.css" rel="stylesheet" />
    <form id="form1" runat="server">
        
        
    <div class="Design">
    
        <asp:GridView ID="GridView1" AutoGenerateColumns="False" DataKeyNames="id" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                       <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtname"  Text='<%#Eval("name") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

               <%--  <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblemail" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtemail"  Text='<%#Eval("email") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>--%>

                 <asp:TemplateField HeaderText="Place">
                    <ItemTemplate>
                        <asp:Label ID="lblplace" runat="server" Text='<%#Eval("place") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtplace"  Text='<%#Eval("place") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>


                 <asp:TemplateField HeaderText="amount">
                    <ItemTemplate>
                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtamount"  Text='<%#Eval("amount") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdate"  Text='<%#Eval("date") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>


                 <asp:TemplateField HeaderText="time">
                    <ItemTemplate>
                        <asp:Label ID="lbltime" runat="server" Text='<%#Eval("time") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txttime" Text='<%#Eval("time") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>



                   <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnedit" CommandName="Edit" runat="server" Text="Edit" />
                        <asp:Button ID="btncancel" CommandName="Delete" runat="server" Text="Cancel Booking" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btnupdate" CommandName="update" runat="server" Text="Update" />
                        <%-- <asp:Button ID="btncancel" CommandName="Cancel" runat="server" Text="back" />--%>
                    </EditItemTemplate>
                </asp:TemplateField>


            </Columns>
         
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
         
        </asp:GridView>
    </div>
    </form>
</asp:Content>

 