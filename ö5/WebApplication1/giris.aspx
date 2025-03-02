<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="WebApplication1.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="center-container giris">
            <div class="col-8">
                <h1 style="text-align:center;">Giriş Yapınız</h1>
                <div class="mb-3">
                    <asp:Label ID="Label1" AssociatedControlID="girismail" class="form-label" runat="server" Text="Kullanıcı Adı"></asp:Label>
                    <asp:TextBox ID="girismail" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label2" AssociatedControlID="girissifre" class="form-label" runat="server" Text="Şifre"></asp:Label>
                    <asp:TextBox ID="girissifre" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="girisbtn" CssClass="btn btn-primary" runat="server" Text="Giriş" OnClick="girisbtn_Click" />
                <asp:Button ID="kytbtn" CssClass="btn btn-warning" runat="server" Text="Kayıt Ol" OnClick="kytbtn_Click" /><br />
                <asp:Label ID="lblMessage1" runat="server" Text="" ForeColor="#0aff22" />
                <asp:Label ID="lblMessage2" runat="server" Text="" ForeColor="Red" />
                <br />
            </div>
        </div>
</asp:Content>
