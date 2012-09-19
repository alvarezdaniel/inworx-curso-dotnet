<%
	Sub ShowTable(n, m, b)
	if b then
		Response.Write "<table border='1'>"
	Else
		Response.Write "<table border='0'>"
	End if

	  for i = 1 to n
	    Response.Write "<tr>"
	    for j = 1 to m
	      Response.Write "<td>" & i & j & "</td>"
            next
            Response.Write "</tr>"
          next
	Response.Write "</table>"
	End Sub
%>
