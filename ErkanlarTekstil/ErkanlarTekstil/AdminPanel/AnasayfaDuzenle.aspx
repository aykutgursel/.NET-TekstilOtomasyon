<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="AnasayfaDuzenle.aspx.cs" Inherits="AdminPanel_AnasayfaDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height:auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table class="auto-style1">
          <tr>
            <td width="30%" height="50px">    Düzenlenecek Alan Seçin :  </td>
            <td width="68%">
                <asp:dropdownlist ID="ddlAnasayfaAlanlari" runat="server" Height="20px" Width="164px" OnSelectedIndexChanged="ddlAnasayfaAlanlari_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    <asp:ListItem Value="1">İletişim Bilgileri</asp:ListItem>
                    <asp:ListItem Value="2">Bilgi</asp:ListItem>
                    <asp:ListItem Value="3">Kategori</asp:ListItem>
                    <asp:ListItem Value="4">Sosyal Medya</asp:ListItem>
                </asp:dropdownlist>
            </td>
        </tr>
      <%--  <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnGetir" runat="server" Height="17px" Text="Getir" Width="60px" OnClick="btnGetir_Click" />
            </td>
        </tr>--%>
        <tr>
            <td>&nbsp</td>
            <td>&nbsp</td>
        </tr>          
    </table>

           <asp:Panel ID="pnlBilgi" runat="server" Visible="false">
    
                <table>
                      <tr>
                         <td width="40%">Bilgi Adı : </td>
                        <td width="68%">
                            <asp:textbox ID="txtBilgiAdi" runat="server" Width="437px"></asp:textbox>
                        </td>
                    </tr>

                      <tr>
                     <td>Bilgi Adresi </td>
                        <td>
                            <asp:textbox ID="txtBilgiAdresi" runat="server" Width="437px"></asp:textbox>
                        </td>
                      
                    </tr>


                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnBilgiEkle" runat="server" Text="Ekle" Height="37px" Width="126px" OnClick="btnBilgiEkle_Click"/>
                        </td>
                    </tr>

                    <tr>
                        <td>&nbsp<br /></td>
                        <td>&nbsp</td>
                    </tr>
                    <tr>
                     <td>    Hangi Bilgiyi Silmek İstiyorsun:  </td>
                    <td>
                        <asp:dropdownlist ID="ddlBilgi" runat="server" Height="20px" Width="164px" AutoPostBack="True">
                        </asp:dropdownlist>
                    </td>
                      </tr>
                    <tr>
                           <td>&nbsp</td>
                          <td>
                            <asp:Button ID="btnBilgiSil" runat="server" Text="Bilgi Sil" OnClick="btnBilgiSil_Click"/>
                        </td>


                    </tr>

                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lblBilgiSonuc" runat="server" Font-Bold="True" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>

        <!-- İletisim Paneli Başlangıç -->
         <asp:Panel ID="pnlIletisim" runat="server" Visible="false">
    
                <table>
                      <tr>
                                    <td>İl - İlçe </td>
                        <td>
                            <asp:textbox ID="txtIl_ilce" runat="server" Width="437px"></asp:textbox>
                        </td>
                    </tr>

                      <tr>
                     <td>Mail Adresi </td>
                        <td>
                            <asp:textbox ID="txtMail" runat="server" Width="437px"></asp:textbox>
                        </td>
                    </tr>

                      <tr>
                     <td>Telefon </td>
                        <td>
                            <asp:textbox ID="txtTelefon" runat="server" Width="437px"></asp:textbox>
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
            </asp:Panel>
      <!-- İletisim Bitiş -->

         <!-- Kategori Paneli Başlangıç -->
         <asp:Panel ID="pnlKategoriler" runat="server" Visible="false">
             <table class="auto-style1">
                  <tr>
                    <td width="30%" height="50px">    Hangi Kategoriyi Düzenlemek İstiyorsun:  </td>
                    <td width="68%">
                        <asp:dropdownlist ID="ddlKategori" runat="server" Height="20px" Width="164px" OnSelectedIndexChanged="ddlKategori_SelectedIndexChanged" AutoPostBack="True">
                             
                        </asp:dropdownlist>
                    </td>
                        <td>
                            <asp:Button ID="btnKategoriSil" runat="server" Text="Kategoriyi Sil" OnClick="btnKategoriSil_Click"/>
                        </td>

                      <td>
                          <asp:Button ID="btnKategoriEkle" runat="server" Text="Kategori Ekle" OnClick="btnKategoriEkle_Click" />
                      </td>
                </tr>
            </table>
         </asp:Panel>

     <asp:Panel ID="pnlKategoriSil" runat="server" Visible="false">
         <table class="auto-style1">
                  <tr>
                    <td width="30%" height="50px">    Hangi Kategoriyi Silmek İstiyorsun:  </td>
                    <td width="68%">
                        <asp:dropdownlist ID="ddlKateogoriSil" runat="server" Height="20px" Width="164px" AutoPostBack="True">
                             
                        </asp:dropdownlist>
                    </td>
                      </tr>
             <tr>
                        <td>
                            <asp:Button ID="btnSil" runat="server" Text="Kategoriyi Sil" OnClick="btnSil_Click" /> 
                        </td>
                     </tr>
             <tr>
                   <td>
                            <asp:Label ID="lblKategoriSilDurum" runat="server" Text=""></asp:Label>
                        </td>
            </tr>
            </table>
    </asp:Panel>

    <asp:Panel ID="pnlKategoriEkle" runat="server" Visible="false">
           <table>
                      <tr>
                        <td width="30%" height="50px">    Kategori Adı :   </td>
                        <td width="68%">
                            <asp:TextBox ID="txtKategoriAdiEkle" runat="server"></asp:TextBox>
                        </td>
                      </tr>

                     <tr>
                        <td width="30%" height="50px">    Sayfa Adresi :   </td>
                        <td width="68%">
                            <asp:TextBox ID="txtKategoriAdresiEkle" runat="server"></asp:TextBox>
                        </td>
                      </tr>

                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnKategoriyiEkle" runat="server" Text="Kategoriyi Ekle" Height="37px" Width="156px" OnClick="btnKategoriyiEkle_Click"/>
                        </td>
                    </tr>

                      <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lblDurum" runat="server" Text=""></asp:Label>
                         </td>
                    </tr>
                    </table>

    </asp:Panel>

                 <asp:Panel ID="pnlKategorileriGoster" runat="server" Visible="false">
                     <table>
                      <tr>
                        <td width="30%" height="50px">    Kategori Adı :   </td>
                        <td width="68%">
                            <asp:TextBox ID="txtKategoriAdiGuncelle" runat="server"></asp:TextBox>
                        </td>
                      </tr>

                     <tr>
                        <td width="30%" height="50px">    Sayfa Adresi :   </td>
                        <td width="68%">
                            <asp:TextBox ID="txtKategoriAdresiGuncelle" runat="server"></asp:TextBox>
                        </td>
                      </tr>

                    <tr>
                        <td>&nbsp;</td>
                       
                        <td>
                            <asp:Button ID="btnKategoriGuncelle" runat="server" Text="Güncelle" Height="37px" Width="126px" OnClick="btnKategoriGuncelle_Click1"/>
                        </td>
                    </tr>

                      <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lblKategoriSonuc" runat="server" Text=""></asp:Label>
                         </td>
                    </tr>
                    </table>
                </asp:Panel>
          <!-- Kategori Bitiş -->

        
          <!-- SosyalMedya Paneli Başlangıç -->
           <asp:Panel ID="pnlSosyalMedya" runat="server" Visible="false">
                <b> Hangisini Güncellemek istiorsunuz?</b><br /><hr /><br />
                <table class="auto-style1">
                    <tr>
                        <td width="30%" height="50px">    Sosyal Medya seçiniz : </td>
                        <td width="68%">
                            <asp:dropdownlist ID="ddlSosyalMedyaHesaplari" runat="server" Height="20px" Width="164px">
                                <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                                <asp:ListItem Value="1">Facebook</asp:ListItem>
                                <asp:ListItem Value="2">Twitter</asp:ListItem>
                                <asp:ListItem Value="3">Google Plus</asp:ListItem>
                            </asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnGetir" runat="server" Height="17px" Text="Getir" Width="60px" OnClick="btnGetir_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp</td>
                        <td>&nbsp</td>
                    </tr>
                    <tr>
                     <td>Sosyal Medya Linki : </td>
                        <td>
                            <asp:textbox ID="txtSosyalMedyaLinki" runat="server" Width="437px"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnSosyalMedyaGuncelle" runat="server" Text="Güncelle" Height="37px" Width="126px" OnClick="btnSosyalMedyaGuncelle_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lblSosyalDurum" runat="server" Font-Bold="True" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>

           </asp:Panel>
          <!-- Kategori Bitiş -->
</asp:Content>

