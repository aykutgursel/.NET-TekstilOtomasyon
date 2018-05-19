<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="EnCokSatilanUrunler.aspx.cs" Inherits="AdminPanel_EnCokSatilanUrunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>En çok satılan Ürünler</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <b> Hangisini Güncellemek istiorsunuz?</b><br /><hr /><br />

    <table class="auto-style1">
        <tr>
            <td width="30%" height="50px">Hangi Resmi güncellemek istiyorsun : </td>
            <td width="68%">
                <asp:dropdownlist ID="ddlEnCokSatilan" runat="server" Height="20px" Width="164px">
                    <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    <asp:ListItem Value="1">1.Resim</asp:ListItem>
                    <asp:ListItem Value="2">2.Resim</asp:ListItem>
                    <asp:ListItem Value="3">3.Resim</asp:ListItem>
                    <asp:ListItem Value="4">4.Resim</asp:ListItem>
                    <asp:ListItem Value="5">5.Resim</asp:ListItem>
                    <asp:ListItem Value="6">6.Resim</asp:ListItem>
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnGetir" runat="server" Height="17px" Text="Getir" Width="60px" OnClick="btnGetir_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp</td>
            <td>&nbsp</td>
        </tr>
         <tr>
         <td>Ürün Yolu : </td>
            <td>
                <asp:FileUpload ID="fuResimYukle" runat="server" />
            </td>
        </tr>
        <tr>
         <td>Ürün Adı :  </td>
            <td>
                <asp:textbox ID="txtUrunadi" runat="server" Width="437px"></asp:textbox>
            </td>
        </tr>
          <tr>
         <td>Ürün Aciklaması :  </td>
            <td>
                <asp:textbox ID="txtUrunAciklama" runat="server" Width="600px"></asp:textbox>
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
    </table>


</asp:Content>

