<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="GrupYonetimi.aspx.cs" Inherits="AdminPanel_GrupYonetimi" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
        .auto-style2 {
            height: 22px;
        }
        .auto-style3 {
            width: 600px;
        }
        .auto-style4 {
            width: 32px;
            height: 32px;
        }


        .girisKutusu2 {
            display: inline-block;
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
            margin: 3px;
            padding: 10px 20px;
            border: 1px solid #000000;
            -webkit-border-radius: 20px;
            border-radius: 20px;
            font: normal normal bold 12px/normal Arial, Helvetica, sans-serif;
            color: rgba(0,142,198,1);
            -o-text-overflow: clip;
            text-overflow: clip;
            background: rgba(247,222,222,1);
            -webkit-transform: rotateX(12.032113697747288deg) rotateY(-0.5729577951308232deg);
            transform: rotateX(12.032113697747288deg) rotateY(-0.5729577951308232deg);
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table align="center" class="auto-style1">
        <tr>
            <td width="30%" class="auto-style2">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="30%" class="auto-style2">Grup Adı :</td>
            <td class="auto-style2">
                <asp:TextBox ID="tx_GrupAdi" runat="server" CssClass="girisKutusu2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="30%">&nbsp;</td>
            <td>
                <asp:Button ID="btn_Ekle" runat="server" Height="26px" OnClick="btn_Ekle_Click" Text="Ekle" Width="107px" />
            </td>
        </tr>
     
         <asp:Panel ID="pnlDurum" runat="server" Visible="false" Width="100%">
            <tr>
               <td>
                    <asp:Label ID="lblDurum" runat="server" Text="Durum :"></asp:Label> 
                </td>
               <td>
                     <asp:Label ID="lblDurumAciklama" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </asp:Panel>
            
        <tr>
            <td width="30%"></td>
            <td>&nbsp;</td>
        </tr>
    </table>




    <table align="center" class="auto-style3">
        <asp:Repeater ID="rptGruplar" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("GrupAdi") %>
                    </td>
                    <td width="20%">
                        <a href="GrupGuncelle.aspx?GrupId=<%#Eval("GrupId")%>"> <img class="auto-style4" src="images/Iconlar/kullaniciDuzenle.png" /></a></td>
                    <td width="20%">
                        <a href="GrupYonetimi.aspx?GrupId=<%#Eval("GrupId")%>&islem=sil"><img class="auto-style4" src="images/Iconlar/kullaniciSil.png" /></a> 
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>




</asp:Content>

