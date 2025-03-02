<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="odevYukle.aspx.cs" Inherits="WebApplication1.odevYukle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Proje Yükleme</h2>
            <div class="mb-3">
                <asp:FileUpload ID="fileUploadResim" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label ID="Label1" AssociatedControlID="txtproje" class="form-label" runat="server" Text="Proje Adı"></asp:Label>
                <asp:TextBox ID="txtproje" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnResimYukle" runat="server" Text="Proje Yükle" OnClick="btnResimYukle_Click" />
            </div>
    </div>
</asp:Content>
