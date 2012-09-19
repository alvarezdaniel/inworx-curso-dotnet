<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="ASPTest.WebForm1" %>
<%@ Register TagPrefix="cc1" Namespace="InworxControlsLib" Assembly="InworxControlsLib" %>
<%@ Register TagPrefix="uc1" TagName="Cabecera" Src="Cabecera.ascx" %>
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
			<uc1:Cabecera id="Cabecera1" runat="server" title="Felipito"></uc1:Cabecera>
			<cc1:SuperGrid id="SuperGrid1" runat="server" DESIGNTIMEDRAGDROP="387" Rows="5" Cols="3" Width="408px"
				Height="63px"></cc1:SuperGrid>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="409" border="1" style="WIDTH: 409px; HEIGHT: 96px">
				<TR>
					<TD style="HEIGHT: 28px"><INPUT type="text" id="Text1" name="Text1" runat="server"></TD>
					<TD style="HEIGHT: 28px"></TD>
					<TD style="HEIGHT: 28px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></TD>
					<TD>
						<asp:Button id="Button1" runat="server" Text="Click me"></asp:Button></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label1" runat="server">Label</asp:Label></TD>
					<TD></TD>
					<TD>
						<asp:Button id="Button2" runat="server" Text="Salir"></asp:Button></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label2" runat="server">Filas</asp:Label>
						<asp:TextBox id="CantFilas" runat="server"></asp:TextBox></TD>
					<TD>
						<asp:Label id="Label3" runat="server">Columnas</asp:Label>
						<asp:TextBox id="CantColumnas" runat="server"></asp:TextBox></TD>
					<TD>
						<asp:Button id="btnResize" runat="server" Text="Resize"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
