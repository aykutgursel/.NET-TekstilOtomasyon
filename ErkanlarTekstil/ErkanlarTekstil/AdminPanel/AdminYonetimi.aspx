<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminYonetimi.aspx.cs" Inherits="AdminPanel_AdminYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 614px;
        }
        .auto-style3 {
            height: 22px;
        }
        .auto-style4 {
            height: 30px;
        }
        .auto-style5 {
            width: 54%;
        }
        .auto-style6 {
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table class="auto-style1">
        <tr>
            <td>
                <table align="left">
                    <tr>
                        <td class="auto-style6">Kullanıcı Adı :</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtAra" runat="server" placeHolder="Kullanıcı Ara"></asp:TextBox>
                        </td>
                        <td width="10%"> <asp:Button ID="btnAdminEkle" runat="server" Text="Admin Ekle" Width="100px" style="margin-left: 0px" PostBackUrl="~/AdminPanel/AdminEkle.aspx"/></td>
                    </tr>
                    <tr>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="btnAra" runat="server" Text="Ara" Width="93px" OnClick="btnAra_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="lblAramaBilgi" runat="server" Font-Bold="True" Visible="false" Font-Size="13pt" ForeColor="#CC0000" style="text-align: center" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="dlKullaniciAra" runat="server" Width="54%" CellPadding="4" ForeColor="#333333">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td width="20%">Kullanıcı Adı</td>
                                <td width="20%">Şifre</td>
                                <td width="20%">Ad Soyad</td>
                                <td width="20%">Görevi</td>
                                <td width="10%">Düzenle</td>
                                <td width="10%">Sil</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemStyle BackColor="#EFF3FB" />
                    <ItemTemplate>
                        <table class="auto-style1" style="font-size: 12px">
                            <tr>
                                <td width="20%"><%#Eval("KullaniciAdi") %></td>
                                 <td width="20%"><%#Eval("Sifre") %></td>
                                <td width="20%"><%#Eval("AdSoyad") %></td>
                                <td width="20%"><%#Eval("GrupAdi") %></td>
                                <td width="10%">
                                    <a href="KullaniciDuzenle.aspx?KullaniciId=<%#Eval("KullaniciId") %>"> <img src="images/Iconlar/kullaniciDuzenle.png" /></a>
                                </td>
                                <td width="10%">
                                    <a href="AdminYonetimi.aspx?KullaniciId=<%#Eval("KullaniciId") %>&islem=sil"><img src="images/Iconlar/kullaniciSil.png" /></a>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style4">
                            <asp:Button ID="btnYonetici" runat="server" Text="Yöneticiler" OnClick="btnYonetici_Click" Width="178px" />
                        </td>
                        <td class="auto-style4">
                            <asp:Button ID="btnYardimciYonetici" runat="server" Text="Yardımcı Yönetici" OnClick="btnYardimciYonetici_Click" Width="182px" />
                        </td>
                        <td class="auto-style4">
                            <asp:Button ID="btnKullanicilar" runat="server" Text="Kullanıcılar" OnClick="btnKullanicilar_Click" Width="158px" />
                        </td>
                        <td class="auto-style4">  <asp:Button ID="btnSonOnKayit" runat="server" Text="Son Eklenen 10 Kayıt" OnClick="btnSonOnKayit_Click" /></td>
                        <td class="auto-style4"></td>
                        <td class="auto-style4"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="datalistKullanicilar" runat="server" Width="100%" CellPadding="4" ForeColor="#333333">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td width="10%">Kullanıcı Adı</td>
                                <td width="10%">Şifre</td>
                                <td width="10%">Ad Soyad</td>
                                <td width="10%">Görevi</td>
                                <td width="10%">Kayıt Tarihi</td>
                                <td width="10%">Düzenle</td>
                                <td width="10%">Sil</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemStyle BackColor="#EFF3FB" />
                    <ItemTemplate>
                        <table class="auto-style1" style="font-size: 12px">
                            <tr>
                                <td width="10%"><%#Eval("KullaniciAdi") %></td>
                                <td width="10%"><%#Eval("Sifre") %></td>
                                <td width="10%"><%#Eval("AdSoyad") %></td>
                                <td width="10%"><%#Eval("GrupAdi") %></td>
                                <td width="10%"><%#Eval("OlusturmaTarihi") %></td>
                                <td width="10%">
                                    <a href="KullaniciDuzenle.aspx?KullaniciId=<%#Eval("KullaniciId") %>"> <img src="images/Iconlar/kullaniciDuzenle.png" /></a>
                                </td>
                                <td width="10%">
                                    <a href="AdminYonetimi.aspx?KullaniciId=<%#Eval("KullaniciId") %>&islem=sil"><img src="images/Iconlar/kullaniciSil.png" /></a>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>


</asp:Content>

