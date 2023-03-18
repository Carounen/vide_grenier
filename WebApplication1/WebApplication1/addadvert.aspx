<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="addadvert.aspx.cs" Inherits="WebApplication1.addadvert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bbox{
            background-color:cornflowerblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

     <div class="bbox">
        <h4>Request to add advertising</h4>
        <hr />
      <div>

         
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtadvertId" Visible="false"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Company
name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtadvertname"
                    CssClass="form-control" />
            </div>
        </div>
       
       
        </div>
       

        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Logo Brand</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="picture" runat="server" CssClass="" />
                <asp:Image ID="images" runat="server" Visible="true" Width="75"
                    Height="100" />
            </div>
        </div>



       
       
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <div class="form-check-inline">
                    <asp:CheckBox runat="server" ID="chkstatus"
                        CssClass="form-check-input" />
                    <asp:Label runat="server"
                        CssClass="form-check-label">Status</asp:Label>
                </div>
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <div class="offset-md-2 col-md-8">
                <asp:Button runat="server" ID="btnAdvert"  OnClick="btnAdvert_Click" Text="Add Advert"
                    CssClass="btn btn-block btn-outline-primary" />
               
              
               
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
      </div>
    
    <hr />

</asp:Content>
