<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ELibraryManagement.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center> <img style="width: 150px" src="images/adminuser.png" />
                                <h3>Admin Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Username</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="name@example.com"></asp:TextBox ><br /> 
                            
                                <label>Password</label>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="password" TextMode="Password"></asp:TextBox><br />
                                </div>

                                <div class="form-group">
                                    <asp:Button class="btn btn-success form-control" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>
                       
                            </div>
                        </div>                  
                </div>
                <a href="Homepage.aspx"><< Back Home</a>
                <br />
            </div>
            
        </div>
        
    </div>
</asp:Content>
