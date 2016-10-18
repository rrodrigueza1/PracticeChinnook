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
                    <h1>Roles</h1>
                </div>
                <div class="tab-pane fade" id="unregistered">
                    <h1>UnregisteredUsers</h1>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

