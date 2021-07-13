<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ViewDetails.aspx.cs" Inherits="Product_Details" %>




    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
      <form id="form1" runat="server">
            
    <div>   
        <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" style="text-align: center" Width="1105px" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <style>@import url(https://cdnjs.cloudflare.com/ajax/libs/MaterialDesign-Webfont/5.3.45/css/materialdesignicons.min.css);</style>
<div class="min-w-screen min-h-screen bg-yellow-300 flex items-center p-5 lg:p-10 overflow-hidden relative">
    <div class="w-full max-w-6xl rounded bg-white shadow-xl p-10 lg:p-20 mx-auto text-gray-800 relative md:text-left">
        <div class="md:flex items-center -mx-10">
            <div class="w-full md:w-1/2 px-10 mb-10 md:mb-0">
                <div class="relative">
                   
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' CssClass="w-full relative z-10" alt="" />
                    <div class="border-4 border-yellow-200 absolute top-10 bottom-10 left-10 right-10 z-0"></div>
                </div>
            </div>
            <div class="w-full md:w-1/2 px-10">
                <div class="mb-10">
                    <h1 class="font-bold uppercase text-2xl mb-5"><%# Eval("Cabmodel") %> 
                         <br />
                         <br />
                    <p class="text-sm"> <%# Eval("Cardetails") %><a href="#" class="opacity-50 text-gray-900 hover:opacity-100 inline-block text-xs leading-none border-b border-gray-900">MORE <i class="mdi mdi-arrow-right"></i></a></p>
                </div>
                <div>
                    <div class="inline-block align-bottom mr-5">    
                        <span class="text-2xl leading-none align-baseline">Driver Name: <%# Eval("DriverName") %></span>
                        </div>

                <div>


                    <br />

                     <div class="inline-block align-bottom mr-5">    
                        <span class="text-2xl leading-none align-baseline">City :- <%# Eval("City") %></span>
                        
                    </div>
                    <br />
                     <br />
                   

                    
                    <div class="inline-block align-bottom mr-5">    
                        <span class="font-bold text-5xl leading-none align-baseline"> ₹ <%# Eval("rate") %></span>
                    </div>
                    <div class="inline-block align-bottom">
                         
                        <asp:Button ID="btnbook" CommandName="Book" CommandArgument='<%#Eval("id") %>' CssClass="auto-cols-fr" runat="server" Text="Book now" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- BUY ME A BEER AND HELP SUPPORT OPEN-SOURCE RESOURCES -->
<div class="flex items-end justify-end fixed bottom-0 right-0 mb-4 mr-4 z-10">
    <div>
        <a title="Buy me a beer" href="https://www.buymeacoffee.com/scottwindon" target="_blank" class="block w-16 h-16 rounded-full transition-all shadow hover:shadow-lg transform hover:scale-110 hover:rotate-12">
            <img class="object-cover object-center w-full h-full rounded-full" src="https://i.pinimg.com/originals/60/fd/e8/60fde811b6be57094e0abc69d9c2622a.jpg"/>
        </a>
    </div>
</div>
   
            </ItemTemplate>

        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Connection %>" SelectCommand="SELECT * FROM [drivers] WHERE ([Id] = @Id)">
            <SelectParameters>
                <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>

</asp:Content>











