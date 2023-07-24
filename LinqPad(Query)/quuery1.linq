<Query Kind="Statements">
  <Connection>
    <ID>baea7a46-3d23-437a-9824-c412f970c073</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>TestDB</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var x=UserDetails.Where(i => i.Age == 18).Select(r=>r.FirstName);
x.Dump();

