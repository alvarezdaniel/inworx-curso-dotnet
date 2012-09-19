<%@ Register TagPrefix="uc1" TagName="Cabecera" Src="Cabecera.ascx" %>
<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="ASPTest.WebForm1" %>
<%@ Register TagPrefix="cc1" Namespace="InworxControlsLib" Assembly="InworxControlsLib" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:cabecera id="Cabecera1" runat="server"></uc1:cabecera>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
				<TR>
					<TD><INPUT type="text"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:textbox id="TextBox1" runat="server"></asp:textbox></TD>
					<TD><asp:button id="Button1" runat="server" Text="Click me"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label1" runat="server">Label</asp:label></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<P><cc1:supergrid id="SuperGrid1" runat="server"></cc1:supergrid></P>
			<P>
				<asp:Button id="Button2" runat="server" Text="Button"></asp:Button></P>
		</form>
	</body>
</HTML>
