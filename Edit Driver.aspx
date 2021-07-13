<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit Driver.aspx.cs" Inherits="Edit_Driver" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    
<body>
    <form id="form1" runat="server">
    
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="400px" HorizontalAlign="Justify" Width="200px" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="DriverName" HeaderText="DriverName" SortExpression="DriverName" />
                <asp:BoundField DataField="Cabmodel" HeaderText="Cabmodel" SortExpression="Cabmodel" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="mobilenumber" HeaderText="mobilenumber" SortExpression="mobilenumber" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="experiance" HeaderText="experiance" SortExpression="experiance" />
                <asp:BoundField DataField="rate" HeaderText="rate" SortExpression="rate" />
                <asp:TemplateField HeaderText="Details">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtcardetails" TextMode="MultiLine" Text='<%#Eval("Cardetails") %>' Height="100px" Width="200px" runat="server"></asp:TextBox>
                        
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <EditItemTemplate>
            <asp:FileUpload ID="fuPhoto" runat="server" ToolTip="select Category Photo"/>
            <asp:RegularExpressionValidator ID="revfuPhoto" runat="server" Text="Please select image file only" ToolTip="Image formate only" ControlToValidate="fuPhoto" ValidationExpression="[a-zA-Z0_9].*\b(.jpeg|.JPEG|.jpg|.JPG|.jpe|.JPE|.png|.PNG|.mpp|.MPP|.gif|.GIF)\b"></asp:RegularExpressionValidator>
            </EditItemTemplate>
                </asp:TemplateField>
                <asp:ImageField DataImageUrlField="image">
                    <ControlStyle Height="100px" Width="100px" />
                </asp:ImageField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Connection %>" DeleteCommand="DELETE FROM [drivers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [drivers] ([Id], [DriverName], [Password], [Cabmodel], [Address], [City], [mobilenumber], [email], [experiance], [rate], [image]) VALUES (@Id, @DriverName, @Password, @Cabmodel, @Address, @City, @mobilenumber, @email, @experiance, @rate, @image)" SelectCommand="SELECT * FROM [drivers]" UpdateCommand="UPDATE [drivers] SET [DriverName] = @DriverName, [Password] = @Password, [Cabmodel] = @Cabmodel, [Address] = @Address, [City] = @City, [mobilenumber] = @mobilenumber, [email] = @email, [experiance] = @experiance, [rate] = @rate, [image] = @image WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="DriverName" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Cabmodel" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="mobilenumber" Type="Int64" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="experiance" Type="String" />
                <asp:Parameter Name="rate" Type="String" />
                <asp:Parameter Name="image" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="DriverName" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Cabmodel" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="mobilenumber" Type="Int64" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="experiance" Type="String" />
                <asp:Parameter Name="rate" Type="String" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
