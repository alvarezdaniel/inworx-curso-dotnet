<%
  Sub ShowTable(n, m, b)  
    If b Then
      Response.Write "<table border='1'>"
    Else
      Response.Write "<table border='0'>"
    End If
    For i = 1 To n
      Response.Write "<tr>"
      For j = 1 To m
        Response.Write "<td>" & i & j & "</td>"
      Next
      Response.Write "</tr>"
    Next
    Response.Write "</table>"
  End Sub
%>