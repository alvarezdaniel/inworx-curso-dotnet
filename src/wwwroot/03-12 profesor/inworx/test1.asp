<html>

<body>
<h1>Test</h1>
<%
  Response.Write "<table>"
  For i = 1 To 100
    Response.Write "<tr>"
    For j = 1 To 10
      Response.Write "<td>" & i & j & "</td>"
    Next
    Response.Write "</tr>"
  Next
  Response.Write "</table>"
%>
</body>

</html>