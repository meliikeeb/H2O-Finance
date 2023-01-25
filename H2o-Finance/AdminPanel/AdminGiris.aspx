<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="H2o_Finance.AdminPanel.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Giriş</title>
    <link href="Style/MainCSS.css" rel="stylesheet" />
    <link href="Style/AdminGirisCSS.css" rel="stylesheet" />

    <link href="https://fonts.googleapis.com/css2?family=Unbounded&display=swap" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" style="height: 100%">
        <div class="giris">
            <div class="container silver">
                <div class="content">
                    <img src="images/H2oDamlaLogo.png" />
                    <asp:Panel ID="pnl_hata" runat="server"  Visible="false">
                        <asp:Label ID="lbl_hata" runat="server" ></asp:Label>
                    </asp:Panel>
                    <asp:TextBox ID="tb_mail" runat="server" placeholder="Mail Adresinizi Giriniz"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="tb_sifre" runat="server" placeholder="Şifrenizi Giriniz" TextMode="Password"></asp:TextBox>
                    <asp:LinkButton ID="lbtn_giris" runat="server" OnClick="lbtn_giris_Click" Text="Giriş" ></asp:LinkButton >
                    
                </div>

            </div>
        </div>



    </form>
</body>
</html>
