<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Admin.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Admin
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="form1" runat="server">
<section class="text-gray-600 body-font">
  <div class="container mx-auto flex px-5 py-24 items-center justify-center flex-col">
    <img class="lg:w-2/6 md:w-3/6 w-5/6 mb-10 object-cover object-center rounded" alt="hero" src="https://source.unsplash.com/1600x900/?cab">
    <div class="text-center lg:w-2/3 w-full">
      <h1 class="title-font sm:text-4xl text-3xl mb-4 font-medium text-gray-900">Modules Overview and Functionality</h1>
      <p class="mb-8 leading-relaxed">Administrator or admin has total control over the application. They can add managers of any kind, set up their profiles, and add, delete, or modify manager records. They can have an overview of all managers from different locations and directly communicate with them. Admin is required to log in to the system with a unique user id consisting of username and password.</p>
      <div class="flex justify-center">

        <a  href="Add Driver.aspx" class="inline-flex text-white bg-indigo-500 border-0 py-2 px-6 focus:outline-none hover:bg-indigo-600 rounded text-lg">Add Driver</a>
         <a  href="Edit Driver.aspx" class="ml-4 inline-flex text-gray-700 bg-gray-100 border-0 py-2 px-6 focus:outline-none hover:bg-gray-200 rounded text-lg">Edit Driver</a> 
      </div>
    </div>
  </div>
</section>
    </form>

 </asp:Content>