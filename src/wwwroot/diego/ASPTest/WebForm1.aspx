<%@ Register TagPrefix="cc1" Namespace="InworxControlsLib" Assembly="InworxControlsLib" %>
<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="ASPTest.WebForm1" %>
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
			<uc1:Cabecera id="Cabecera1" runat="server" DESIGNTIMEDRAGDROP="32"></uc1:Cabecera>
			<TABLE id="Table1" style="WIDTH: 632px; HEIGHT: 82px" cellSpacing="1" cellPadding="1" width="632"
				border="1">
				<TR>
					<TD style="WIDTH: 249px"><INPUT style="WIDTH: 184px; HEIGHT: 22px" type="text" size="25" id="Text1" name="Text1"
							runat="server"></TD>
					<TD style="WIDTH: 212px"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 249px">
						<asp:Button id="Button3" runat="server" Text="AddRow"></asp:Button>
						<asp:Button id="Button4" runat="server" Text="DeleteRow"></asp:Button></TD>
					<TD style="WIDTH: 212px">
						<asp:TextBox id="TextBox1" runat="server" Width="184px" Height="24px"></asp:TextBox></TD>
					<TD>
						<asp:Button id="Button1" runat="server" Text="Haceme Click"></asp:Button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 249px">
						<asp:Label id="Label1" runat="server">Label</asp:Label></TD>
					<TD style="WIDTH: 212px">
						<asp:Label id="Label2" runat="server">Label</asp:Label></TD>
					<TD>
						<asp:Button id="Button2" runat="server" Text="Chau papa"></asp:Button></TD>
				</TR>
			</TABLE>
			<cc1:SuperGrid id="SuperGrid1" runat="server" Rows="2"></cc1:SuperGrid>
		</form>
	</body>
</HTML>
