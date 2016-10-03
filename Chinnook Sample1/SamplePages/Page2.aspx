<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Page2.aspx.cs" Inherits="SamplePages_Page2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:DropDownList ID="EmployeeList" runat="server" DataSourceID="EmployeeListODS" DataTextField="Name" DataValueField="EmployeeId"></asp:DropDownList><br /><br />
    <asp:Button ID="Submit" runat="server" Text="Submit" />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AllowPaging="True" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State"></asp:BoundField>
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone"></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="CustomerRepresentative" TypeName="Chinnook_System.BLL.CustomerController">
        <SelectParameters>
            <asp:ControlParameter ControlID="EmployeeList" PropertyName="SelectedValue" Name="employeeid" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="EmployeeListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="EmployeeNameList_Get" TypeName="Chinnook_System.BLL.EmployeeController"></asp:ObjectDataSource>
</asp:Content>

