<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="AdoNetTest.Web.MasterDetail.WebForm1" %>
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
			<TABLE id="Table1" style="WIDTH: 536px; HEIGHT: 336px" cellSpacing="1" cellPadding="1"
				width="536" border="1">
				<TR>
					<TD style="HEIGHT: 25px">
						<DIV style="DISPLAY: inline; WIDTH: 48px; HEIGHT: 19px" ms_positioning="FlowLayout">Autor</DIV>
					</TD>
					<TD style="HEIGHT: 25px">
						<asp:DropDownList id="AuthorsList" runat="server" Width="266px" AutoPostBack="True"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD colspan="2" style="HEIGHT: 21px" align="center">
						<DIV style="DISPLAY: inline; WIDTH: 129px; HEIGHT: 16px" ms_positioning="FlowLayout">Títulos 
							del Autor</DIV>
					</TD>
				</TR>
				<TR>
					<TD colspan="2" vAlign="top" align="center">
						<asp:DataGrid id="TitlesGrid" runat="server" Width="530px" Height="118px"></asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
