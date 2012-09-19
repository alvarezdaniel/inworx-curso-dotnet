<%@ Page language="c#" Codebehind="Bankito.aspx.cs" AutoEventWireup="false" Inherits="BankServiceConsumer.Bankito" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Bankito</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="296" border="1" style="WIDTH: 296px; HEIGHT: 104px">
				<TR>
					<TD>
						<DIV style="DISPLAY: inline; WIDTH: 88px; HEIGHT: 16px" ms_positioning="FlowLayout">
							Cuenta</DIV>
					</TD>
					<TD style="WIDTH: 91px">
						<asp:TextBox id="txtCuenta" runat="server"></asp:TextBox></TD>
					<TD>
						<asp:LinkButton id="lbConsultarSaldo" runat="server" Width="128px">Consultar Saldo</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">
						<DIV style="DISPLAY: inline; WIDTH: 70px; HEIGHT: 15px" ms_positioning="FlowLayout">Saldo</DIV>
					</TD>
					<TD style="WIDTH: 91px; HEIGHT: 23px">
						<asp:TextBox id="txtSaldo" runat="server"></asp:TextBox></TD>
					<TD style="HEIGHT: 23px"></TD>
				</TR>
				<TR>
					<TD>
					</TD>
					<TD style="WIDTH: 91px"></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="1">
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<asp:LinkButton id="LinkButton1" runat="server">Depositar</asp:LinkButton></TD>
					<TD>
						<asp:LinkButton id="LinkButton2" runat="server">Extraer</asp:LinkButton></TD>
					<TD>
						<asp:LinkButton id="LinkButton3" runat="server">Transferir</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
