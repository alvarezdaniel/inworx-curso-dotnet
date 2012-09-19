<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="AutoresLibros.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
<title>WebForm1</title>
<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" Content="C#">
<meta name="vs_defaultClientScript" content="JavaScript">
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
</HEAD>
<body>
<form id="Form1" method="post" runat="server">
<P><STRONG><FONT color="#3300cc" size="5">Autores:</FONT></STRONG></P>
<P>
<asp:DropDownList id="DropDownList1" runat="server" Width="264px" AutoPostBack="True"></asp:DropDownList>
<asp:Label id="Label2" runat="server"></asp:Label></P>
<P>&nbsp;</P>
<P><STRONG><FONT color="#3300cc" size="5">Libros:</FONT></STRONG></P>
<asp:DataGrid id="DataGrid1" runat="server" Width="100%" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" BackColor="White" CellPadding="4">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
</asp:DataGrid>
</form>
</body>
</HTML>
