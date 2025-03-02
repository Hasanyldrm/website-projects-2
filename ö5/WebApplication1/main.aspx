<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="WebApplication1.main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h1 class="text-center">Öğrenci ve Proje Listesi</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped table-bordered"
                DataKeyNames="OgrenciNo,ProjeAdi"
                OnRowEditing="GridView1_RowEditing" 
                OnRowUpdating="GridView1_RowUpdating"
                OnRowDataBound="GridView1_RowDataBound"
                OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="OgrenciNo" HeaderText="Öğrenci No" ReadOnly="True" />
                    <asp:BoundField DataField="AdSoyad" HeaderText="Ad Soyad" ReadOnly="True" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" />
                    <asp:BoundField DataField="ProjeAdi" HeaderText="Proje Adı" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Not Doküman">
                        <ItemTemplate>
                            <asp:Label ID="lblNotDokuman" runat="server" Text='<%# Eval("Not_Dokuman") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNotDokuman" runat="server" Text='<%# Bind("Not_Dokuman") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TÜBİTAK Proje Notu">
                        <ItemTemplate>
                            <asp:Label ID="lblNotTProje" runat="server" Text='<%# Eval("Not_TProje") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNotTProje" runat="server" Text='<%# Bind("Not_TProje") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teknofest Proje Notu">
                        <ItemTemplate>
                            <asp:Label ID="lblNotTFest" runat="server" Text='<%# Eval("Not_TFest") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNotTFest" runat="server" Text='<%# Bind("Not_TFest") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Konferans Sunum Notu">
                        <ItemTemplate>
                            <asp:Label ID="lblNotKonferans" runat="server" Text='<%# Eval("Not_Konferans") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNotKonferans" runat="server" Text='<%# Bind("Not_Konferans") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Resim">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlPdf" runat="server" Text="Projeyi İndir"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
    </div>
</asp:Content>
