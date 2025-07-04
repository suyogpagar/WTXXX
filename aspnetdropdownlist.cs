<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DropDownExample.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Dropdown List Example</title>
</head>
<body>
    <form runat="server">
        <asp:DropDownList ID="ddlItems" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged">
        </asp:DropDownList>
        
        <asp:Label ID="lblSelectedItem" runat="server" ForeColor="Blue" />
    </form>
</body>
</html>
Default.aspx.cs
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> items = new List<string> { "Apple", "Banana", "Cherry", "Grapes", "Mango" };
            ddlItems.DataSource = items;
            ddlItems.DataBind();
        }
    }

    protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSelectedItem.Text = "You selected: " + ddlItems.SelectedItem.Text;
    }
}

