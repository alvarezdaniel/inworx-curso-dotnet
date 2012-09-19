<%@ Page language="c#" Codebehind="PresentationClass.aspx.cs" AutoEventWireup="false" Inherits="PresentationLayer.PresentationClass" %>
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
			<DIV style="DISPLAY: inline; WIDTH: 192px; HEIGHT: 16px" ms_positioning="FlowLayout">
				<P>Autores de la base</P>
				<P>&nbsp;</P>
			</DIV>
			<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
				BackColor="White" CellPadding="3" PageSize="5" Width="100%">
				<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
