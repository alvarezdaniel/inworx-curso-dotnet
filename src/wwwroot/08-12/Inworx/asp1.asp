<!--#include file="inworx.inc"-->

<html>
<body>
<h1>test</h1>

<% 
Response.write "Primera tabla"
ShowTable 5, 3, True
Response.write "Segunda tabla"
ShowTable 20, 5, False
Response.write "Tercera tabla"
ShowTable 2, 10, True
%>

</body>
</html>