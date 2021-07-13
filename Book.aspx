<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Book.aspx.cs" Inherits="Book" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

   
 <form id="form1" runat="server">
     
     <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-66840886-1');
    </script>


      <script>
        !function (f, b, e, v, n, t, s) {
            if (f.fbq) return; n = f.fbq = function () {
                n.callMethod ?
  n.callMethod.apply(n, arguments) : n.queue.push(arguments)
            };
            if (!f._fbq) f._fbq = n; n.push = n; n.loaded = !0; n.version = '2.0';
            n.queue = []; t = b.createElement(e); t.async = !0;
            t.src = v; s = b.getElementsByTagName(e)[0];
            s.parentNode.insertBefore(t, s)
        } (window, document, 'script',
  'https://connect.facebook.net/en_US/fbevents.js');
        fbq('init', '164454367525488');
        fbq('track', 'PageView');
    </script>


         <script type="text/javascript">
        function allowOnlyNumber(evt) {
            alert('Please Select Date');
            return false;
        }

    </script>
      <asp:ScriptManager ID="Scriptmanager1" runat="server">

      </asp:ScriptManager>
  <div class="relative py-3 sm:max-w-xl sm:mx-auto">
    <div class="relative px-4 py-10 bg-white mx-8 md:mx-0 shadow rounded-3xl sm:p-10">
      <div class="max-w-md mx-auto">
        <div class="flex items-center space-x-5">
          <div class="h-14 w-14 bg-yellow-200 rounded-full flex flex-shrink-0 justify-center items-center text-yellow-500 text-2xl font-mono">i</div>
          <div class="block pl-2 font-semibold text-xl self-start text-gray-700">
              <asp:Label ID="lblerror" runat="server"></asp:Label>
            <h2 class="leading-relaxed">Book Cab</h2>
            <p class="text-sm text-gray-500 font-normal leading-relaxed">Please Read all entries all fields are mandatory*</p>
          </div>
        </div>
        <div class="divide-y divide-gray-200">
          <div class="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">

            <div class="flex flex-col">
             
                  <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Id" DataValueField="Id" AutoPostBack="True">
        </asp:DropDownList>
                <br />
                <asp:Button ID="btncheck" runat="server" OnClick="Button2_Click" Text="Check Availability" CausesValidation="False" />
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">Name*</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

                <div class="flex flex-col">
              <label class="leading-loose">Email*</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

              <div class="flex flex-col">
              <label class="leading-loose">Place*</label>
                <asp:TextBox ID="txtPlace" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

               <div class="flex flex-col">
              <label class="leading-loose">Date*</label>
                <asp:TextBox ID="txtdate" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                    <ajax:CalendarExtender ID="calendar" targetControlID="txtdate" Format="MM/dd/yyyy"  runat="server" ></ajax:CalendarExtender>
            </div>

               <div class="flex flex-row">
              <label class="leading-loose">Time* :- </label> &nbsp; &nbsp; &nbsp;
                     <asp:DropDownList ID="ddltime" CssClass="px-2 outline-none appearance-none bg-transparent" runat="server" AutoPostBack="True"></asp:DropDownList>

                       <asp:DropDownList ID="ddlt" CssClass="px-2 outline-none appearance-none bg-transparent" runat="server" AutoPostBack="True">
                   </asp:DropDownList>
                   <asp:DropDownList ID="ddlt1" runat="server">
                       <asp:ListItem>AM</asp:ListItem>
                       <asp:ListItem>PM</asp:ListItem>
                   </asp:DropDownList>           
            </div>
                <div class="flex flex-col">
                  
              <label class="leading-loose">Amount*</label>
                <asp:TextBox ID="txtAmount" runat="server" CssClass="px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" ></asp:TextBox>
            </div>

              <div class="w-full text-center mx-auto">
         <asp:Button ID="btnbook" CssClass="border border-red-500 bg-red-500 text-white rounded-md px-4 py-2 m-2 transition duration-500 ease select-none hover:bg-red-600 focus:outline-none focus:shadow-outline" runat="server" Text="Book" OnClick="btnbook_Click"  />
                   <asp:Button ID="btnreset" CssClass="border border-red-500 bg-red-500 text-white rounded-md px-4 py-2 m-2 transition duration-500 ease select-none hover:bg-red-600 focus:outline-none focus:shadow-outline" runat="server" Text="Reset" OnClick="btnreset_Click" />
         </div>
                  </div>
                  </div>
    </form>
</asp:Content>




