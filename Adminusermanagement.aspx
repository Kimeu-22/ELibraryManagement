<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Adminusermanagement.aspx.cs" Inherits="ELibraryManagement.Adminusermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-5">

                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Member Details</h4>
                            <img style="width: 100px" src="images/generaluser.png" />
                        </center>
                    </div>
                </div>

                <div class="row">
                    <div class="col-3">
                        <label>Member ID</label>
                        <div class="input-group mb-3">
                            <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server"></asp:TextBox>
                            <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="GO" OnClick="Button1_Click" />
                    </div>
                    </div>

                    <div class="col-4">
                        <label>Full Name</label>
                        <asp:TextBox class="form-control" placeholder="Full Name" ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>

                    <div class="col-5">
                        <label>Account status</label>
                        <div class="input-group mb-3">
                            <asp:TextBox class="form-control me-1" ID="TextBox2" runat="server" placeholder="status" aria-label="ID"></asp:TextBox>
                            <asp:LinkButton class="btn btn-success me-1" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                            <asp:LinkButton class="btn btn-warning me-1" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                            <asp:LinkButton class="btn btn-danger me-1" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="far fa-times-circle"></i></asp:LinkButton>
                          
                    </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-3">
                        <label>DOB</label>
                        <asp:TextBox class="form-control" ID="TextBox6" ReadOnly="True" TextMode="Date" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-4">
                        <label>Contact No</label>
                        <asp:TextBox class="form-control" ID="TextBox4" ReadOnly="True" TextMode="Number" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-5">
                        <label>Email</label>
                        <asp:TextBox class="form-control" ID="TextBox3" ReadOnly="True" TextMode="Email" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-4">
                        <label>State</label>
                        <asp:TextBox class="form-control" ID="TextBoxState" ReadOnly="True" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-4">
                        <label>City</label>
                        <asp:TextBox class="form-control" ID="TextBox7" ReadOnly="True" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-4">
                        <label>Pin Code</label>
                        <asp:TextBox class="form-control" ID="TextBox8" ReadOnly="True" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <label>Full Postal Address</label>
                        <asp:TextBox class="form-control" ID="TextBox9" runat="server" Rows="2" TextMode="MultiLine" placeholder="My Home" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="d-grid gap-2 col-8 mx-auto">
                        <asp:Button class="btn btn-danger mt-2 mb-2" ID="Button2" runat="server" Text="Delete User Permanently" OnClick="Button2_Click" />
                    </div>
                </div>
            </div>

            <div class="col-7">
                <div class="row">
                    <div class="col">
                        <center><h4>Member List<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            </h4></center>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                <asp:BoundField DataField="account_status" HeaderText="Account_status" SortExpression="account_status" />
                                <asp:BoundField DataField="contact_no" HeaderText="Contact_no" SortExpression="contact_no" />
                                <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" ReadOnly="True" />
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
