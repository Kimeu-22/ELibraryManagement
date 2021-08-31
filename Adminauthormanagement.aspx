﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Adminauthormanagement.aspx.cs" Inherits="ELibraryManagement.Adminauthormanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--Inserting the command to enable easier interaction with data-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("thead").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card border-0">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author's Details</h4>
                                    <img style="width: 100px" src="images/writer.png" /><br />
                                    <br />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label class="form-label">Author ID</label>
                                <div class="input-group mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:Button class="btn btn-dark" ID="Button4" runat="server" Text="GO" OnClick="Button4_Click" />
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label class="form-label">Author Name</label>
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Author's Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success btn-block form-control" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                            </div>

                            <div class="col-4">
                                <asp:Button class="btn btn-primary btn-block form-control" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                            </div>

                            <div class="col-4">
                                <asp:Button class="btn btn-danger btn-block form-control" ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
                            </div>

                        </div>
                    </div>
                </div>
                <a href="Homepage.aspx"><< Back To Home</a>
            </div>

            <div class="col-1">
                <hr width="1" size="400" />
            </div>

            <div class="col-md-6">
                <div class="card border-0">

                    <div class="card-body">
                        <center>
                            <h3>Author List</h3>
                        </center>
                        <%--Assigning a data to grid view from a database 
                            by use of a SqlDatasource as it can get access to a database--%>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELibraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
