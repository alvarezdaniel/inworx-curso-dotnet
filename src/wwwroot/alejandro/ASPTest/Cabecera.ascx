<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Cabecera.ascx.cs" Inherits="ASPTest.Cabecera" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" bgColor="lightgoldenrodyellow"
	border="0">
	<TR>
		<TD>
			<asp:Label id="UserLabel" runat="server"></asp:Label></TD>
		<TD></TD>
		<TD align="right">
			<asp:Label id="DateLabel" runat="server"></asp:Label></TD>
	</TR>
	<TR>
		<TD></TD>
		<TD align="center">
			<asp:Label id="TitleLabel" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label></TD>
		<TD></TD>
	</TR>
</TABLE>
