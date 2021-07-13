<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Add Driver.aspx.cs" Inherits="Registration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
<div class="min-h-screen bg-gray-100 py-6 flex flex-col justify-center sm:py-12">
  <div class="relative py-3 sm:max-w-xl sm:mx-auto">
    <div class="relative px-4 py-10 bg-white mx-8 md:mx-0 shadow rounded-3xl sm:p-10">
      <div class="max-w-md mx-auto">
        <div class="flex items-center space-x-5">
          <div class="h-14 w-14 bg-yellow-200 rounded-full flex flex-shrink-0 justify-center items-center text-yellow-500 text-2xl font-mono">i</div>
          <div class="block pl-2 font-semibold text-xl self-start text-gray-700">
              <asp:Label ID="lblerror" runat="server"></asp:Label>
              <br />
            <h2 class="leading-relaxed">Add Cab Driver</h2>
            <p class="text-sm text-gray-500 font-normal leading-relaxed">Please Read all entries all fields are mandatory*</p>
          </div>
        </div>
        <div class="divide-y divide-gray-200">
          <div class="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">
            <div class="flex flex-col">
              <label class="leading-loose">Cab no.</label>
                <asp:TextBox ID="txtCabNo" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>
              
               <div class="flex flex-col">
              <label class="leading-loose">Car Model</label>
                <asp:TextBox ID="txtCarmodel" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>


               <div class="flex flex-col">
              <label class="leading-loose">Driver Name</label>
                <asp:TextBox ID="txtDriverName" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">City</label>
                <asp:TextBox ID="txtCity" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">Mobile Number</label>
                <asp:TextBox ID="TxtMobileNumber" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">Email</label>
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">Experiance</label>
                <asp:TextBox ID="txtExperiance" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">Rate</label>
                <asp:TextBox ID="txtRate" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">Description</label>
                <asp:TextBox ID="txtdesc" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" Height="100px"  ></asp:TextBox>
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

               <div class="flex flex-col">
                     <label class="leading-loose">File Upload</label>
              <asp:FileUpload ID="FileUpload1" runat="server" /> 
<br />
                    
    <div class="w-full text-center mx-auto">
         <asp:Button ID="btnadd" CssClass="border border-red-500 bg-red-500 text-white rounded-md px-4 py-2 m-2 transition duration-500 ease select-none hover:bg-red-600 focus:outline-none focus:shadow-outline" runat="server" Text="Add Driver" OnClick="btnadd_Click" />
                   <asp:Button ID="btnreset" CssClass="border border-red-500 bg-red-500 text-white rounded-md px-4 py-2 m-2 transition duration-500 ease select-none hover:bg-red-600 focus:outline-none focus:shadow-outline" runat="server" Text="Reset" OnClick="btnreset_Click" />
         </div>
  </div>
        
    </div>
  </div>
</div>
    </div>
  </div>
</div>

    </form>
</asp:Content>



