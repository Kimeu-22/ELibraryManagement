﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="ELibraryManagement.ViewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();

        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="row">
        <div class="col-md-7">
            <h2><center>Book Inventory list</center></h2>
    </div>
    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" />
            
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="row">
                                    <div class="col-12">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        Author-<asp:Label ID="Label2" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True"></asp:Label>
                                        &nbsp;| Genre-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                        &nbsp;| Language-<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">

                                        Publisher-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                        &nbsp;| Publisher Date-<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publisher_date") %>'></asp:Label>
                                        &nbsp;| Pages-<asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                        &nbsp;| Edition-<asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">

                                        Cost-<asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                        &nbsp;| Actual stock-<asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                        &nbsp;| Available-<asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">

                                        Description-<asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>

                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:TemplateField>
            
        </Columns>
        
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
        </div>
        
</asp:Content>
