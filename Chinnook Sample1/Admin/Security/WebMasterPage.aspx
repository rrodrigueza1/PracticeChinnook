<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WebMasterPage.aspx.cs" Inherits="Admin_Security_WebMasterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row jumbotron">
        <h1>User and Role Administration</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- Set up Navigation Tabs-->
            <ul class="nav nav-tabs">
                <li class="active"><a href="#users" data-toggle="tab">Users</a></li>
                <li><a href="#roles" data-toggle="tab">Roles</a></li>
                <li><a href="#unregistered" data-toggle="tab">Unregistered Users</a></li>
            </ul>
            <!-- Tab Content Area -->
            <div class="tab-content">
                <!-- User Tab -->
                <div class="tab-pane fade in active" id="users">
                    <h1>Users</h1>
                </div>
                <div class="tab-pane fade" id="roles">
                    <!-- DataKeyNames contains the considered PK Field of the class that is being used Insert or Delete -->
                    <!-- RefreshAll will call a generic methid in my code behind that will cause the ODS sets to re-bind their data-->
                    <asp:ListView ID="RoleListView" runat="server"
                        DataSourceID="RoleListViewODS"
                        ItemType="Chinnook_System.Security.RoleProfile"
                        InsertItemPosition="LastItem"
                        DataKeyNames="RoleId"
                        OnItemInserted="RefreshAll"
                        OnItemDeleted="RefreshAll">
                        <EmptyDataTemplate>
                            <span>No Security Roles has been setup</span>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <div class="row biginfo">
                                <div class="col-sm-3 h4">Action</div>
                                <div class="col-sm-3 h4">RoleName</div>
                                <div class="col-sm-6 h4">Users</div>
                            </div>
                            <div id="itemPlaceholder" runat="server">
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:LinkButton ID="RemoveRole" CommandName="Delete" runat="server">Remove</asp:LinkButton>
                                </div>
                                <div class="col-sm-3">
                                    <%# Item.RoleName %>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Repeater ID="RoleUsers" runat="server" DataSource="<%# Item.Username %>" ItemType="System.String">
                                        <ItemTemplate>
                                            <%# Item %>
                                        </ItemTemplate>
                                        <SeparatorTemplate>, </SeparatorTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:LinkButton ID="InsertRole" CommandName="Insert" runat="server">Insert</asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="CancelRole" runat="server">Cancel</asp:LinkButton>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="NewRoleName" runat="server" Text='<%# BindItem.RoleName %>' Placeholder="Role Name"></asp:TextBox>
                                </div>
                            </div>
                        </InsertItemTemplate>
                    </asp:ListView>
                    <asp:ObjectDataSource ID="RoleListViewODS" runat="server"
                        DataObjectTypeName="Chinnook_System.Security.RoleProfile"
                        DeleteMethod="DeleteRole"
                        InsertMethod="AddRole"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="ListAllRoles"
                        TypeName="Chinnook_System.Security.RoleManager"></asp:ObjectDataSource>
                </div>
                <div class="tab-pane fade" id="unregistered">
                    <!-- Gridview handling Unregistered Users -->
                    <asp:GridView ID="UnregisteredUsersGridView" runat="server"
                        AutoGenerateColumns="False"
                        DataSourceID="UnregisteredUsersODS"
                        DataKeyNames="UserId"
                        ItemType="Chinnook_System.Security.UnregisteredUserProfile" OnSelectedIndexChanging="UnregisteredUsersGridView_SelectedIndexChanging">
                        <Columns>
                            <asp:CommandField SelectText="Register" ShowSelectButton="True"></asp:CommandField>
                            <asp:BoundField DataField="UserType" HeaderText="UserType" SortExpression="UserType"></asp:BoundField>
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
                            <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname"></asp:BoundField>
                            <asp:TemplateField HeaderText="AssignedUserName" SortExpression="AssignedUserName">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# Bind("UserName") %>'
                                        ID="AssignedUserName"></asp:TextBox>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AssignedEmail" SortExpression="AssignedEmail">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# Bind("EmailAddress") %>'
                                        ID="AssignedEmail"></asp:TextBox>
                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataTemplate>
                            No Unregistered User to Process
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="UnregisteredUsersODS" runat="server"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="ListAllUnRegisteredUsers"
                        TypeName="Chinnook_System.Security.UserManager"></asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

