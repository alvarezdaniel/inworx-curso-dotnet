<%
  Sub ShowTable(n, m, b)
    if b Then
      Response.write "<table border='1'>"
    Else
      Response.write "<table border='0'>"
    End If
    for i =1 to n 
     Response.write "<tr>"

     for j = 1 to m
       Response.write "<td> i =" & "<b>" & i & "</b> - j = <b>" & j & "</b></td>"
     Next

     Response.write "</tr>"
   Next
   Response.write "</table>" 
 End Sub
%>