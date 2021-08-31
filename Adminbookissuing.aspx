<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Adminbookissuing.aspx.cs" Inherits="ELibraryManagement.Adminbookissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container-fluid">
        <div class="row">

            <div class="col-5">
                <div class="card border-0">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>
                                    <img style="width: 100px" src="images/books.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-6">
                                <label class="form-label">Member ID</label>
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                            </div>

                            <div class="col-6">
                                <label class="form-label">Book ID</label>
                                <div class="input-group mb-3">
                                    <input type="text" class="form-control" placeholder="ID" aria-label="ID"
                                        aria-describedby="button-addon1" />
                                    <asp:Button class="btn btn-dark" ID="Button3" runat="server" Text="GO" />
                            </div>
                        </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <label>Member Name</label>
                                <asp:TextBox class="form-control" ID="TextBox2" runat="server" 
                                    placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                            </div>

                            <div class="col-6">
                                <label>Book Name</label>
                                <asp:TextBox class="form-control" ID="TextBox3" runat="server" 
                                    placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <label>Start Date</label>
                                <asp:TextBox ID="TextBox4" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                            </div>  
                            
                            <div class="col-6">
                                <label>End Date</label>
                                <asp:TextBox ID="TextBox5" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                            </div> 
                        </div><br />

                        <div class="row">
                            <div class="col-6">
                                <asp:Button class="btn btn-primary form-control" ID="Button1" runat="server" Text="Issue" />
                            </div>

                            <div class="col-6">
                                <asp:Button class="btn btn-success form-control" ID="Button2" runat="server" Text="Return" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-7">
                <div class="card border-0">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
