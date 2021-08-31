<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="ELibraryManagement.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div class="container">
        <div class="row">
            <%--class="mx-auto" centers the contents--%>
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img style="width: 150px" src="images/generaluser.png"/>
                                    <h4>Member Login</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col"><hr/></div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label class="form-label">Member ID</label>
                                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Member ID" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label class="form-label">Password</label>
                                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Password" class="form-control" TextMode="Password"><</asp:TextBox><br />
                                </div>

                                <div class="form-group">
                                    <asp:Button class="btn btn-success form-control" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /><br /><br />
                                </div>

                                <div class="form-group">
                                     <a href="UserSignUp.aspx"><input class="btn btn-info form-control" id="Button2" type="button" value="Sign Up" /><br /></a>
                                </div>
                            </div>
                    </div>

                </div>
            </div>
                <a href="Homepage.aspx"><< Back to Home</a><br /><br />
        </div>              
    </div>
    </div>
</asp:Content>
