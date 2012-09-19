<%@ Page language="c#" Codebehind="Deposito.aspx.cs" AutoEventWireup="false" Inherits="BankServiceConsumer.Deposito" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Deposito</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
				<TR>
					<TD>
						<DIV style="DISPLAY: inline; WIDTH: 88px; HEIGHT: 16px" ms_positioning="FlowLayout">Nro. 
							Cuenta</DIV>
					</TD>
					<TD>
						<asp:TextBox id="txtNroCuenta" runat="server"></asp:TextBox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">
						<DIV style="DISPLAY: inline; WIDTH: 70px; HEIGHT: 15px" ms_positioning="FlowLayout">Monto</DIV>
					</TD>
					<TD style="HEIGHT: 23px">
						<asp:TextBox id="txtMonto" runat="server"></asp:TextBox></TD>
					<TD style="HEIGHT: 23px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Button id="btnDepositar" runat="server" Text="Depositar"></asp:Button></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblResult" runat="server">Label</asp:Label>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
