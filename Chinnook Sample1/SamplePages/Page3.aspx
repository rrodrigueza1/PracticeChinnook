<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Page3.aspx.cs" Inherits="SamplePages_Page3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Year" runat="server" Text="Year: "></asp:Label>
    <asp:TextBox ID="txtboxYear" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Submit" runat="server" Text="Submit" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ArtistAlbums_Get" TypeName="Chinnook_System.BLL.ArtistController">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtboxYear" PropertyName="Text" Name="Year" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

