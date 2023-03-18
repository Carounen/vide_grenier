<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="orgre.aspx.cs" Inherits="WebApplication1.orgre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

     <h2 class="title"><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <h4 class="title">Register as an organisation.</h4>
    <hr />


        <div class="b">


             <div class="mb-2 title" >
        <asp:Label runat="server"
            CssClass="form-label">Organisation Name</asp:Label>

        <asp:TextBox runat="server" ID="first"
            placeholder="Enter Name"
            CssClass="form-control" />


         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="true" ControlToValidate="first" runat="server" ForeColor="Red" ErrorMessage="First name is required"></asp:RequiredFieldValidator>
    </div>




             <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">Email Address</asp:Label>

        <asp:TextBox runat="server" ID="mail"
            placeholder="Enter Email Address"
            CssClass="form-control" />

         <asp:RequiredFieldValidator  Display="Dynamic" SetFocusOnError="true" ControlToValidate="mail" runat="server" ForeColor="Red" ErrorMessage="Email is required"></asp:RequiredFieldValidator>

    </div>




  <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">Password</asp:Label>

        <asp:TextBox runat="server" ID="txtpas"
            placeholder="Enter password"
             TextMode="Password"
            CssClass="form-control" />

        <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="txtpas" ForeColor="Red" ClientValidationFunction="validatePassword" ValidateEmptyText="true" ErrorMessage="Password must be between 7 to 12 characters"></asp:CustomValidator>

    </div>


    <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">confirm password</asp:Label>

        <asp:TextBox runat="server" ID="txtc"
            placeholder="confirm password"
             TextMode="Password"
            CssClass="form-control" />

        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtc" ControlToCompare="txtpas" Operator="Equal" initialValue="-1" ForeColor="Red" ErrorMessage="Password does not match"></asp:CompareValidator>

    </div>


             <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Profile Picture</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="picture" runat="server" CssClass="" />
                <asp:Image ID="images" runat="server" Visible="true" Width="75"
                    Height="100" />
            </div>
        </div> 

           



 <div class="mb-3">
       

     <asp:Button ID="lblMsg" runat="server" Text="Register" OnClick="Register_Click" CssClass="col-12 btn btn-outline-primary btn-lg" BackColor="Blue" ForeColor="White"/>

    </div>




        </div>




</asp:Content>
