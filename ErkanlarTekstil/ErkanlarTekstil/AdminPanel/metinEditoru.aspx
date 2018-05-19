<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="metinEditoru.aspx.cs" Inherits="AdminPanel_metinEditoru" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server"></asp:LoginView>
    <asp:FileUpload ID="FileUpload1" runat="server" />

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />

</asp:Content>

