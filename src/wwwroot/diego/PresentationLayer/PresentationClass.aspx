<%@ Page language="c#" Codebehind="PresentationClass.aspx.cs" AutoEventWireup="false" Inherits="PresentationLayer.PresentationClass" %>
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
<DIV style="DISPLAY: inline; WIDTH: 192px; HEIGHT: 16px" ms_positioning="FlowLayout">
<P>Autores de la base</P>
<P>&nbsp;</P>
</DIV>
<asp:datagrid id="DataGrid1" runat="server" Width="100%" PageSize="5" CellPadding="3" BackColor="White"
                BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" AutoGenerateColumns="False">
<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
<ItemStyle ForeColor="#000066"></ItemStyle>
<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
<Columns>
<asp:BoundColumn DataField="au_id" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
<asp:BoundColumn DataField="au_lname" HeaderText="Last Name"></asp:BoundColumn>
<asp:BoundColumn DataField="au_lname" HeaderText="First Name"></asp:BoundColumn>
<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
</Columns>
<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White"></PagerStyle>
</asp:datagrid></form>
</body>
</HTML>
