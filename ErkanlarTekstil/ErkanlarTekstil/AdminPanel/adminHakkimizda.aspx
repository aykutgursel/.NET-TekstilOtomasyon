<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="adminHakkimizda.aspx.cs" Inherits="AdminPanel_adminHakkimizda" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 208px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager runat="server"></asp:ToolkitScriptManager>

    <h1>Hakkımızdaki bilgileri güncelle</h1>
 <table class="auto-style1">
        <tr>
            <td width="15%" height="50px">    Alan Seçiniz : </td>
            <td width="83%">
                <asp:dropdownlist ID="ddlHakkimizda" runat="server" Height="20px" Width="164px" 
                    OnSelectedIndexChanged="ddlHakkimizda_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    <asp:ListItem Value="1">Üst Alan</asp:ListItem>
                    <asp:ListItem Value="2">Orta Alan</asp:ListItem>
                    <asp:ListItem Value="3">Alt Alan</asp:ListItem>
                    <asp:ListItem Value="4">Kapanış</asp:ListItem>
                </asp:dropdownlist>
            </td>
        </tr>
<%--        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnGetir" runat="server" Height="17px" Text="Getir" Width="60px" OnClick="btnGetir_Click" />
            </td>
        </tr>--%>
        <tr>
            <td>&nbsp</td>
            <td>&nbsp</td>
        </tr>
     <asp:Panel ID="pnlBilgiler" runat="server" Visible="false">
        <tr>
         <td>Hakkımızdaki Bilgiler : </td>
            <td>
               
                <cc1:Editor ID="Editor1" runat="server" />

                <!--<asp:textbox ID="txtHakkimizda" runat="server" Width="528px" Height="200px" TextMode="MultiLine"></asp:textbox>-->
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" Height="37px" Width="126px" OnClick="btnGuncelle_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblSonuc" runat="server" Font-Bold="True" Visible="false"></asp:Label>
            </td>
        </tr>
     </asp:Panel>
    </table>


</asp:Content>

