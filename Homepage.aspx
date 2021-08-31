<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="ELibraryManagement.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <section>
        <img src="images/home-bg.jpg" class="img-fluid"/>
    </section>

    <section>
        <div class="container">
            <div class="row">
                 <div class="col">
                     <center>
                         <h2>Our features</h2>
                         <p><b>Our 3 features</b></p>
                     </center>
                 </div>
            </div>

            <div class="row">
                 <div class="col-md-4">
                     <center>
                         <img style="width: 150px" src="images/digital-inventory.png"/>
                         <h4>Digital inventory</h4>
                         <p class="text-lg-start">This contains a list of all the books in the library at real time making it easy to monitor</p>
                     </center>
                 </div>

                <div class="col-md-4">
                    <center>
                         <img style="width: 150px" src="images/search-online.png" />
                         <h4>Search books</h4>
                         <p class="text-lg-start">Lets one search for a specific book in the library at real time making it easy to find its specific location in the library</p>
                     </center>
                </div>

                 <div class="col-md-4">
                    <center>
                         <img style="width: 150px" src="images/defaulters-list.png" />
                         <h4>Defaulters List</h4>
                         <p class="text-lg-start">Publicly list all the students who have lost books of the library</p>
                     </center>
                </div>

            </div>
        </div>
    </section>

    <section>
        <img src="images/in-homepage-banner.jpg" class="img-fluid"/>
    </section>

    <section>
        <div class="container">
            <div class="row">
                <center>
                    <h2>Our Process</h2>
                    <p><b>We have 3 simple process</b></p>
                </center>
            </div>
            
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img style="width: 150px" src="images/sign-up.png"/>
                        <h2>Sign Up</h2>
                        <p class="text-lg-start">This allows a new student to create a user in the E-library system</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img style="width: 150px" src="images/search-online.png"/>
                        <h2>Search books</h2>
                        <p class="text-lg-start">Lets one search for a specific book in the library at real time making it easy to find its specific location in the library</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img style="width: 150px" src="images/library.png"/>
                        <h2>Visit Us</h2>
                        <p class="text-lg-start">Visit us at our physical location to get educated and empower yourself</p>
                    </center>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
