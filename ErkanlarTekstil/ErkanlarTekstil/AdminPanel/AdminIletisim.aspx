<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminIletisim.aspx.cs" Inherits="iletisim" %>

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
      <h2>İletişim</h2>  
    <table width="100%" align="center">
        <tr>
            <td width="40%">İl : </td>
            <td width="60%">
                <asp:TextBox ID="txtIl" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>İlçe :</td>
            <td>
                <asp:TextBox ID="txtIlce" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mahalle : </td>
            <td>
                <asp:TextBox ID="txtMahalle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Sokak : </td>
            <td>
                <asp:TextBox ID="txtSokak" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Firma Adı :</td>
            <td>
                <asp:TextBox ID="txtFirmaAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td>No :</td>
            <td>
                <asp:TextBox ID="txtNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Telefon :</td>
            <td>
                <asp:TextBox ID="txtTelNo" runat="server" onkeypress="return rakamKontrol(event)" MaxLength="10"/>
                
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Telefon 2 :</td>
            <td>
                <asp:TextBox ID="txtTelNo2" onkeypress="return rakamKontrol(event)" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td>Faks&nbsp; :</td>
            <td>
                <asp:TextBox ID="txtFaks" runat="server" onkeypress="return rakamKontrol(event)" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td>Mail Adresi :</td>
            <td>
                <asp:TextBox ID="txtMailAdresi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
      
        <tr>
            <td>
                <asp:Button ID="btnIletisimEkle" runat="server" Text="Yeni Adres Ekle" OnClick="btnIletisimEkle_Click" />
            </td>
               <td>
                <asp:Button ID="btnGuncelle" runat="server" Text="Adresi Güncelle" OnClick="btnGuncelle_Click"/>
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

