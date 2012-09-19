<%@ Page language="c#" Codebehind="EmpleadosPorTerritorio.aspx.cs" AutoEventWireup="false" Inherits="WebCachingDataDemo.EmpleadosPorTerritorio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EmpleadosPorTerritorio</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>Empleado:
				<asp:DropDownList id="DropDownList1" runat="server" AutoPostBack="True"></asp:DropDownList></P>
			<P>&nbsp;</P>
			<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid>
		</form>
	</body>
</HTML>
