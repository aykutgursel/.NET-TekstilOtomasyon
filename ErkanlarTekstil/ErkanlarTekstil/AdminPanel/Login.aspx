<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 36px;
        }
        .auto-style4 {
            height: 23px;
            text-align: left;
        }
        .auto-style5 {
            width: 45%;
        }
        .auto-style7 {
            height: 23px;
            text-align: right;
            width: 45%;
        }
       
        .auto-style9 {
            text-align: left;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td style="text-align: center" class="auto-style3">
                    <asp:Label ID="lblSirketAdi" runat="server" Text="Erkanlar Tekstil" Font-Bold="True" Font-Names="Adobe Garamond Pro" Font-Size="22pt" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <table class="auto-style1">
                        <tr>
                            <td width="30%"></td>
                            <td width="70%"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style12">Kullanıcı Adı : </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="txt_LoginKullaniciAdi" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">Şifre :</td>
                            <td class="auto-style4">
                                <asp:TextBox ID="txt_LoginSifre" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td style="text-align: left">
                                <asp:Button ID="btnGirisYap" runat="server" Text="Giriş Yap " Width="107px" OnClick="btnGirisYap_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                <asp:Label ID="lblDurum" runat="server" style="float:right" Text="Durum :" Visible="False" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDurumSonuc" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
