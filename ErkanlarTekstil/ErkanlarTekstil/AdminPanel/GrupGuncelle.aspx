<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="GrupGuncelle.aspx.cs" Inherits="AdminPanel_GrupGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table align="center" class="auto-style1">
        <tr>
            <td width="30%">Grup Adı :</td>
            <td>
                <asp:TextBox ID="txtGrupAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="30%">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnGuncelle" runat="server" Height="26px" Text="Guncelle" Width="100px" OnClick="btnGuncelle_Click" />
            </td>
        </tr>
    </table>


</asp:Content>

