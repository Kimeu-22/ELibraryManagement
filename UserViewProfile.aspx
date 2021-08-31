<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserViewProfile.aspx.cs" Inherits="ELibraryManagement.UserViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img style="width: 150px" src="images/generaluser.png" />
                                    <h4>Your Profile</h4>
                                    <span>Account status - </span>
                                    <asp:Label class="badge rounded-pill bg-primary" ID="Label1" runat="server" Text="Status"></asp:Label>
                                </center>

                                <hr />                               
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label class="form-label">Full Name</label>
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="FullName"></asp:TextBox >
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">Date of Birth</label>
                                <asp:TextBox class="form-control" ID="TextBox2" runat="server" TextMode="Date" placeholder="DOB"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label class="form-label">Contact Number</label>
                                <asp:TextBox class="form-control" ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>

                             <div class="col-md-6">
                                <label class="form-label">Email ID</label>
                                 <asp:TextBox class="form-control" ID="TextBox4" runat="server" ReadOnly="True" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label class="form-label">State</label>
                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem Text="Select" Value="select" />
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-4">
                                <label class="form-label">City</label>
                                 <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Residential area"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <label class="form-label">Pin Code</label>
                                <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Residential area" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label class="form-label">Full Address</label>
                                <asp:TextBox class="form-control" ID="TextBox7" runat="server" Rows="2"
                                    TextMode="MultiLine" ReadOnly="True"></asp:TextBox><br />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><span class="badge rounded-pill bg-primary">Login Credentials</span></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label class="form-label">Member ID</label>
                                <asp:TextBox class="form-control" ID="TextBox8" runat="server" ReadOnly="True" placeholder="ID"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <label class="form-label">Old Password</label>
                                <asp:TextBox class="form-control" ID="TextBox9" runat="server" ReadOnly="True" placeholder="123"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <label class="form-label">New Password</label>
                                <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="123"></asp:TextBox><br />
                            </div>
                        </div>

                        <div class="row">
                            <div class="d-grid gap-2 col-8 mx-auto">                                
                                <asp:Button class="btn btn-primary btn-block" ÏD="Button1" runat="server" Text="Update" />                                                                                                                               
                            </div>
                        </div>

                    </div>
                </div>

            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img style="width: 100px" src="images/books1.png" />
                                <h4>Your Isssued books</h4>
                                <asp:Label class="badge rounded-pill bg-info text-dark" ID="Label2" runat="server"
                                    Text="Info about books due date"></asp:Label>
                                </center>
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" 
                                    ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
