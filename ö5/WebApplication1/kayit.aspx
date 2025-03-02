<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="kayit.aspx.cs" Inherits="WebApplication1.kayit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <div class="alert alert-danger" style="text-align:center" role="alert">
                Otomasyon Sistemi İçin Kayıt Sitesi
            </div>
            <div class="center-container kayit">
                <div class="col-8">
                    <h1 style="text-align:center;">Kayıt Ol</h1>
                    <div class="mb-3">
                        <asp:Label ID="Label1" AssociatedControlID="kytisim" class="form-label" runat="server" Text="İsim"></asp:Label>
                        <asp:TextBox ID="kytisim" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label2" AssociatedControlID="kytsoyisim" class="form-label" runat="server" Text="Soy İsim"></asp:Label>
                        <asp:TextBox ID="kytsoyisim" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label4" AssociatedControlID="kytmail" class="form-label" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="kytmail" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label5" AssociatedControlID="kytsifre" class="form-label" runat="server" Text="Şifre"></asp:Label>
                        <asp:TextBox ID="kytsifre" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <asp:DropDownList ID="kullaniciTipi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="kullaniciTipi_SelectedIndexChanged">
                        <asp:ListItem Text="Kullanıcı Tipini Seçiniz" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Öğrenci" Value="Öğrenci"></asp:ListItem>
                        <asp:ListItem Text="Öğretmen" Value="Öğretmen"></asp:ListItem>
                    </asp:DropDownList>
                    <div class="mb-3">
                        <asp:TextBox ID="txtOgrenciNo" runat="server" class="form-control" Visible="False" placeholder="Öğrenci Numarası giriniz"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <div class="form-check">
                        <asp:Label ID="lblMessage1" runat="server" Text="" ForeColor="#0aff22" />
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" />
                        </div>
                    </div>
                    <asp:Button ID="kytbtn" CssClass="btn btn-warning" runat="server" Text="Kayıt Ol" OnClick="kytbtn_Click" />
                </div>
            </div>
        </div>
</asp:Content>
