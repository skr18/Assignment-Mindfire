<Query Kind="Statements">
  <Connection>
    <ID>baea7a46-3d23-437a-9824-c412f970c073</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>AdventureWorks2022</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

ProductInventories.GroupBy(r=>r.ProductID).Select(obj =>new { r = obj.Key , tot =  obj.Where(i=> i.Shelf=="A"|| i.Shelf=="C" || i.Shelf=="H").Sum(r=> r.Quantity)}).Where(i=> i.tot>=500).OrderBy(s => s.r).Dump();