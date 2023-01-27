<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterpage.Master" AutoEventWireup="true" CodeBehind="NFTEkle.aspx.cs" Inherits="H2o_Finance.AdminPanel.NFTEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ekleContainer">
        
        <div class="ekleTitle">
            <h2>NFT Ekle</h2>
        </div>
        <div class ="ekleContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false"> NFT Ekleme Başarılı</asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server" ></asp:Label>
        </asp:Panel>
            <asp:TextBox ID="tb_isim" runat="server" PlaceHolder="İsim giriniz" CssClass="TextBox" ></asp:TextBox>
             <asp:TextBox ID="tb_fiyat" runat="server" PlaceHolder="Fiyat giriniz"  CssClass="TextBox" ></asp:TextBox>
             <label>Resim Ekle</label> <br />    
            <asp:FileUpload ID="fu_resim" runat="server" CssClass="resimekle" ></asp:FileUpload>
            <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" >EKLE</asp:LinkButton>
</asp:Content>
