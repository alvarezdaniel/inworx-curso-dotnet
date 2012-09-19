<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="ASPTest.login" %>
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
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" align="center" border="1">
				<TR>
					<TD>
						<asp:Label id="Label1" runat="server">User</asp:Label></TD>
					<TD>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label2" runat="server">Pass</asp:Label></TD>
					<TD><INPUT type="password"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Button id="Button1" runat="server" Text="Button"></asp:Button></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
