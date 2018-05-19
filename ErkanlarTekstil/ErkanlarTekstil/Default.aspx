<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/lightbox.css" rel="stylesheet" />
    <script src="js/lightbox-plus-jquery.min.js"></script>
    <style>
        .temizle{clear:both;float:left}
        .auto-style1 {width: 200px;margin-left:8%}
        .ustResim{height:150px;border:2px Dashed black}
         tr td p{color:black;text-align:center}
        h3{margin-left:8%;margin-top:80px}
        table{float:left}
        .rptAnaUrunler{margin-left:50px}
        .container { width: 900px; margin: auto; padding-top: 1em; }
        .container .ism-slider { margin-left: auto; margin-right: auto; }
        #container2 { width: 900px; margin: auto; padding-top: 1em; }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="container2">
    <div>
        <div class="container">
        <div class="ism-slider" id="ErkanlarTekstil">
          <ol>
            <li>
              <img src="images/slider/beach-hut-237489_1280.jpg">
            </li>
            <li>
              <img src="images/slider/singapore-431421_1280.jpg">
            </li>
            <li>
              <img src="images/slider/summer-192179_1280.jpg">
            </li>
            <li>
              <img src="images/slider/city-690332_1280.jpg">
            </li>
            <li>
              <img src="images/slider/bora-bora-685303_1280.jpg">
            </li>
          </ol>
        </div>
        </div>
    </div>
    <br />
    <h3>En Çok Satılan Ürünler</h3>
        <br />
       
            <asp:Repeater ID="rptEnCokSatılan" runat="server">
                <ItemTemplate>
                     <table class="auto-style1">
                        <tr class="ustResim" style="float:left">
                        <td style="">
                            <a class="example-image-link" href="<%#Eval("ResimYol1") %>" data-lightbox="example-1">
                               <div style="Width:200px;Height:100px"><img src="<%#Eval("ResimYol1") %>" style="Width:200px;Height:100px;margin-top:25px;margin-bottom:0px;padding-left:10px;padding-right:10px"/></div>
                            </a>
                        </td>
                        </tr>
                        <tr>
                            <td>&nbsp</td> 
                        </tr>
                        <tr class="AnaAciklama">
                            <td><b><p><%# Eval("UrunAdi1") %></p></b></td>
                        </tr>
                        <tr>
                            <td><p><%# Eval("UrunAciklamasi1") %></p></td>
                        </tr>
                        <tr>
                            <td><p>&nbsp</p></td>
                        </tr>
                     </table>
                </ItemTemplate>
            </asp:Repeater>
    


           <%-- <table class="auto-style1">
                <tr class="ustResim">
                    <td class="auto-style2">
                        <a class="example-image-link" href="images/hakkimizdaResimler/20171022202612322.jpg" data-lightbox="example-1">
                            <asp:Image ID="Img1" runat="server" Width="200px" Height="100px"/>
                        </a>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td> 
                </tr>
                <tr class="AnaAciklama">
                    <td><b><p> <asp:Label ID="lblAnaAciklama1" runat="server" Text=""></asp:Label></p></b></td>
                </tr>
                <tr>
                    <td><p><asp:Label ID="lblUrunAciklama1" runat="server" Text=""></asp:Label></p></td>
                </tr>
                <tr>
                    <td><p>&nbsp</p></td>
                </tr>
            </table>



          <table class="auto-style1">
                <tr class="ustResim">
                    <td class="auto-style2">
                        <a class="example-image-link" href="images/enCokSatilan/5.jpg" data-lightbox="example-1">
                            <asp:Image ID="Image2" runat="server"  Width="200px" Height="100px"/>
                        </a>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td> 
                </tr>
                <tr class="AnaAciklama">
                    <td><b><p>
                        <asp:Label ID="lblAnaAciklama2" runat="server" Text=""></asp:Label>
                   </p></b></td>
                </tr>
                <tr>
                    <td><p><asp:Label ID="lblUrunAciklama2" runat="server" Text=""></asp:Label></p></td>
                </tr>
                <tr>
                    <td><p>&nbsp</p></td>
                </tr>
            </table>

          <table class="auto-style1">
                <tr class="ustResim">
                    <td class="auto-style2">
                        <a class="example-image-link" href="images/slider/beach-hut-237489_1280.jpg" data-lightbox="example-1">
                        <asp:Image ID="Image3" CssClass="example-image" runat="server" Width="200px" Height="100px" />
                         </a>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td> 
                </tr>
                <tr class="AnaAciklama">
                    <td><b><p> <asp:Label ID="lblAnaAciklama3" runat="server" Text=""></asp:Label></p></b></td>
                </tr>
                <tr>
                    <td><p><asp:Label ID="lblUrunAciklama3" runat="server" Text=""></asp:Label></p></td>
                </tr>
                <tr>
                    <td><p>&nbsp</p></td>
                </tr>
            </table>

          <table class="auto-style1">
                <tr class="ustResim">
                    <td class="auto-style2">
                         <a class="example-image-link" href="images/enCokSatilan/2.jpg" data-lightbox="example-1">
                            <asp:Image ID="Image4" runat="server" Width="200px" Height="100px" />
                        </a>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td> 
                </tr>
                <tr class="AnaAciklama">
                    <td><b><p> <asp:Label ID="lblAnaAciklama4" runat="server" Text=""></asp:Label></p></b></td>
                </tr>
                <tr>
                    <td><p> <asp:Label ID="lblUrunAciklama4" runat="server" Text=""></asp:Label></p></td>
                </tr>
                <tr>
                    <td><p>&nbsp</p></td>
                </tr>
            </table>

    
          <table class="auto-style1">
                <tr class="ustResim">
                    <td class="auto-style2">
                         <a class="example-image-link" href="images/enCokSatilan/3.jpg" data-lightbox="example-1">
                            <asp:Image ID="Image5" runat="server" Width="200px" Height="100px" />
                        </a>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td> 
                </tr>
                <tr class="AnaAciklama">
                    <td><b><p> <asp:Label ID="lblAnaAciklama5" runat="server" Text=""></asp:Label></p></b></td>
                </tr>
                <tr>
                    <td><p> <asp:Label ID="lblUrunAciklama5" runat="server" Text=""></asp:Label></p></td>
                </tr>
                <tr>
                    <td><p>&nbsp</p></td>
                </tr>
            </table>

        
          <table class="auto-style1">
                <tr class="ustResim">
                    <td class="auto-style2">
                         <a class="example-image-link" href="images/enCokSatilan/3.jpg" data-lightbox="example-1">
                            <asp:Image ID="Image6" runat="server" Width="200px" Height="100px" />
                          </a>                   
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td> 
                </tr>
                <tr class="AnaAciklama">
                    <td><b><p> <asp:Label ID="lblAnaAciklama6" runat="server" Text=""></asp:Label></p></b></td>
                </tr>
                <tr>
                    <td><p> <asp:Label ID="lblUrunAciklama6" runat="server" Text=""></asp:Label></p></td>
                </tr>
                <tr>
                    <td><p>&nbsp</p></td>
                </tr>
            </table>--%>
            





       


        </div>
</asp:Content>

