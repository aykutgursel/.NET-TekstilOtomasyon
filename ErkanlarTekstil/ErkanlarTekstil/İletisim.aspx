<%@ Page Title="İletişim" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="İletisim.aspx.cs" Inherits="İletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>assa</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div width="80%" style="margin-left:10%;margin-right:10%;margin-top:2%">
        <h2>İletişim Adresimiz</h2>        
        <hr />
        <div style="clear:both"></div>
     
            <asp:repeater ID="rptIletisim" runat="server">
                <itemTemplate>
                <%#Eval("mahalle") %> Mahallesi,
                <%#Eval("sokak") %> Sokak,
                Numara : <%#Eval("No") %>
                  <br />
               <%#Eval("il") %>,
                <%#Eval("ilce") %>
              <br />   <br />    <h3><%#Eval("firmaAdi") %></h3>    <br />
                  <pre>Mail Adresi : <%#Eval("mailAdresi") %></pre> 
               <pre>Telefon : <%#Eval("tel") %></pre>
               <pre>Telefon 2 : <%#Eval("tel2") %></pre>
                 <pre>Faks : <%#Eval("faks") %></pre> 
          
            </itemTemplate>
        </asp:repeater>

       <iframe src="https://www.google.com/maps/embed?pb=!1m21!1m12!1m3!1d894.1810058691398!2d28.973739081834704!3d41.076546254411525!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m6!3e2!4m0!4m3!3m2!1d41.0769947!2d28.9735908!5e0!3m2!1str!2str!4v1509045798972" width="800" height="600" frameborder="0" style="border:0" allowfullscreen></iframe>

    </div>

</asp:Content>

