<html>
<head>
<title>Prueba</title>
</head>
<body>
<table>
 <% for i = 1 to 100
	Response.Write "<tr>"
	for j = 1 to 10
		Response.Write "<td>" & i & "</td>"
        next
        Response.Write "</tr>"
    next
 %>
</table>
</body>
</html>