<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Hakkimizda.aspx.cs" Inherits="Hakkimizda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
    .hakkimizda{margin-left:30px;margin-right-30px}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div width="80%" style="margin-left:10%;margin-right:10%;margin-top:2%;background-color:transparent;">
        <h2>Hakkımızda</h2>        
        <hr />
        <div style="clear:both"></div>

        <div>
            <img src="images/hakkimizda/hakkimizda.jpg" width="360px" style="margin-left:50px;float:right;border:1px solid black"/>
           <p>
               <asp:Label ID="lblHakkimizda" runat="server" CssClass="hakkimizda"></asp:Label>
           </p> </div>

</div>
</asp:Content>

