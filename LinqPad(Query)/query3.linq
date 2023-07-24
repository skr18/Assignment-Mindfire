<Query Kind="Statements">
  <Connection>
    <ID>baea7a46-3d23-437a-9824-c412f970c073</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>AdventureWorks2022</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

SalesOrderHeaders.GroupBy(r => r.CustomerID, y => y.Freight).Dump();
