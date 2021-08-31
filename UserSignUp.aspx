<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="ELibraryManagement.UserSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img style="width: 150px" src="images/generaluser.png" />
                                    <h4>User Registration</h4>
                                </center>
                            </div>
                        <hr />

                        <div class="row">
                            <div class="col-md-6">
                                <label class="form-label">Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                             <div class="col-md-6">
                                 <label class="form-label">Contact Number</label>
                                 <div class="form-group">
                                     <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact Number"></asp:TextBox>
                                 </div>
                             </div>

                             <div class="col-md-6">
                                 <label class="form-label">Email ID</label>
                                 <div class="form-group">
                                     <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email Id" TextMode="Email"></asp:TextBox>
                                 </div>
                             </div>
                         </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label class="form-label">State</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="state"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label class="form-label">City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label class="form-label">Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Pin Code" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                            <div class="row">
                                <div class="col">
                                    <label class="form-label">Full Address</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox5" runat="server" TextMode="MultiLine" placeholder="Full Address" Rows="2"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center><span class="badge rounded-pill bg-info text-dark">Login Credentails</span></center>                                 
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label">Member ID</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="User ID"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <label class="form-label">Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox><br />
                                    </div>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col">
                                    <asp:Button class="btn btn-success form-control" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
