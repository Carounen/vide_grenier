<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="approvereserve.aspx.cs" Inherits="WebApplication1.approvereserve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .b {
            background-color: white;
        }

        .vys{
            border-radius:50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="b">
        <h2>Approve / Reject: </h2>

        <div class="b">
            <h3>List of reserve product</h3>
          





            <asp:Repeater ID="Repeater1" runat="server">



               
            <ItemTemplate>

                <div class="card"
                    style="width: 200px; float: left; margin: 8px;">
                    <asp:Image runat="server"
                        ImageUrl='<%# Eval("pictures", "~/images/{0}")%>' ID="Image1"
                        class="card-img-top vys card bg-info" alt="Card image" Width="193px" Height="195px" />
                    <div class="card-body">
                        <h6 class="card-title"><%# Eval("product_name")%></h6>
                         <h6 class="card-title"><%# Eval("Status")%></h6>

                        <p class="card-text">
                           
                        <asp:HyperLink runat="server" NavigateUrl='<%#Eval("product_id","viewprod.aspx?id={0}")%>'>
                            <%#Eval("description").ToString() +": "+ Eval("product_name").ToString() %>
                        </asp:HyperLink>
                        </p>

                        <p class="card-text">
                            <span><strong>Price Bought:<br />
                            </strong></span><%# Eval("cost","{0:c}")%>
                        </p>
                       
                         <asp:HiddenField ID="hidmov" runat="server" Value='<%# Eval("product_id") %>' />
                 
                    <asp:LinkButton ID="lnkdeny" OnClick="lnkdeny_Click1"  CommandArgument='<%# Eval("user_id") %>' CssClass="btn btn-danger"
                        runat="server">
                        Deny Access</asp:LinkButton><br />
                    <br />

                    <asp:HiddenField ID="himov" runat="server" Value='<%# Eval("product_id") %>' />
                    <asp:LinkButton ID="lnkgrant" OnClick="lnkgrant_Click1"  CommandArgument='<%# Eval("user_id") %>' CssClass="btn btn-success"
                        runat="server">
                        Grant Access</asp:LinkButton>
                    </div>
                </div>


            </ItemTemplate>






            </asp:Repeater>






<%--<itemtemplate>
                  
                   
                </itemtemplate>--%>
               
       
        </div>

    </div>
</asp:Content>
