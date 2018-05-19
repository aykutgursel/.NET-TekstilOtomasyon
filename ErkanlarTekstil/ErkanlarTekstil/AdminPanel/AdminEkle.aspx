<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminEkle.aspx.cs" Inherits="AdminEkle" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
    </style>
    <script>
    function rakamKontrol(olay){
	var tusKodu;
	if(window.event){ // IE
		tusKodu = olay.keyCode
	}else if(olay.which){ // Netscape/Firefox/Opera
		tusKodu = olay.which;
	}
	//alert(tusKodu)
	if(tusKodu == 8){ // backspace tuşuna da izin vermek istiyorsak 
		return true;
	}
	if (tusKodu < 48 || tusKodu > 57){
	    tusKodu.keyCode = 0;
	    return  false;
	}
	else{
	    return true;
	}
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table width="100%" align="center">
        <tr>
            <td width="40%">Kullanıcı Adı : </td>
            <td width="60%">
                <asp:TextBox ID="txtKulAdi" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Şifre : </td>
            <td>
                <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Görevi : </td>
            <td>
                 <telerik:RadComboBox ID="ddlGorevi" Runat="server" AutoPostBack="True">
                </telerik:RadComboBox></td>
        </tr>
        <tr>
            <td>İl : </td>
            <td>
                 <telerik:RadComboBox ID="cbx_il" Runat="server" OnSelectedIndexChanged="cbx_il_SelectedIndexChanged" AutoPostBack="True">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>İlçe :  </td>
            <td>
                <telerik:RadComboBox ID="cbx_ilce" Runat="server" OnSelectedIndexChanged="cbx_ilce_SelectedIndexChanged" AutoPostBack="True">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>Mahalle : </td>
            <td>
                <telerik:RadComboBox ID="cbx_mahalle" Runat="server" AutoPostBack="True">
                </telerik:RadComboBox>
            </td>
        </tr>
      
        <tr>
            <td>Semt : </td>
            <td>
                 <telerik:RadComboBox ID="cbx_semt" Runat="server" AutoPostBack="True">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>Adres : </td>
            <td>
                <asp:TextBox ID="txtAdres" runat="server" Height="83px" TextMode="MultiLine" Width="274px"/>
                
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ad Soyad : </td>
            <td>
                <asp:TextBox ID="txtAdSoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td>Telefon :</td>
            <td>
                <asp:TextBox ID="txtTelefon" runat="server" onkeypress="return rakamKontrol(event)" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td>Mail Adresi :</td>
            <td>
                <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDurumId" runat="server" Visible="False" Font-Bold="True" Font-Size="10pt"></asp:Label></td>
            <td>
                <asp:Label ID="lblDurumText" runat="server" Visible="False" Font-Bold="True" Font-Size="9pt" ForeColor="Blue"></asp:Label></td>
        </tr>
      
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnKullaniciEkle" runat="server" Text="Kullanıcı Ekle" OnClick="btnKullaniciEkle_Click"/>
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


      
    </table>
   



</asp:Content>

