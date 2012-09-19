<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="ASPTest.login" %>
<%@ Register TagPrefix="uc1" TagName="Cabecera" Src="Cabecera.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:Cabecera id="Cabecera1" runat="server"></uc1:Cabecera>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" align="center" border="0">
				<TR>
					<TD>
						<asp:Label id="Label1" runat="server">Quien sos?</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="Button1" runat="server" Text="Entrar"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
