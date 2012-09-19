<!--#include file="inworx.inc"-->
<html>
<head>
<title>Prueba</title>
</head>
<body>
<table>
 <%
	Sub ShowTable(n, m)
	  for i = 1 to n
	    Response.Write "<tr>"
	    for j = 1 to m
	      Response.Write "<td>" & i & j & "</td>"
            next
            Response.Write "</tr>"
          next
	End Sub
 %>
 <%  
	ShowTable 5, 2
	ShowTable 4, 4
	ShowTable 7, 2
 %>
</table>
</body>
</html>