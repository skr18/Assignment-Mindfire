<Query Kind="Statements">
  <Connection>
    <ID>baea7a46-3d23-437a-9824-c412f970c073</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>AdventureWorks2022</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

 var salary = from sp in EmployeePayHistories
                                    join emp in Employees on sp.BusinessEntityID equals emp.BusinessEntityID
                                    where emp.BusinessEntityID == 1
                                    select sp.Rate;
//salary.Dump();

var str = from s in Departments
           	join st in EmployeeDepartmentHistories
                                on s.DepartmentID equals st.DepartmentID
                                join emp in Employees on st.BusinessEntityID equals emp.BusinessEntityID
                                where emp.BusinessEntityID == 1
                                select new
                                { // result selector 
                                    s = s,
                                    JobTitle = emp.JobTitle,
                                    salary = from sal in EmployeePayHistories
                                             where sal.BusinessEntityID == 1 select sal.Rate

                                };
//str.Dump();

var str2 = Employees.OrderBy(r => r.JobTitle);
//str2.Dump();


    var item = Persons.Select(i => new { empId = i.BusinessEntityID,FirstName=i.FirstName,LastName=i.LastName}).OrderBy(i=>i.LastName);
//	item.Dump();
	
	
	 var gt = from s in Employees
               group s by s.JobTitle;
										
	//gt.Dump();
	
	Employees.OrderBy(r=> r.JobTitle).Select(r=> r.JobTitle).Distinct().Dump();