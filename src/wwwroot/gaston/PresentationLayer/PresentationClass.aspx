<%@ Page language="c#" Codebehind="PresentationClass.aspx.cs" AutoEventWireup="false" Inherits="PresentationLayer.PresentationClass" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PresentationClass</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				AllowPaging="True" PageSize="3" AllowSorting="True" CellPadding="2" BackColor="White" BorderWidth="1px"
				BorderStyle="Ridge" BorderColor="Navy" AutoGenerateColumns="False">
				<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="au_id" ReadOnly="True" HeaderText="ID">
						<ItemStyle BackColor="Blue"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="au_lname" HeaderText="Last Name">
						<ItemStyle BackColor="#FFFFCC"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="au_fname" HeaderText="First Name">
						<ItemStyle BackColor="Blue"></ItemStyle>
					</asp:BoundColumn>
					<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
