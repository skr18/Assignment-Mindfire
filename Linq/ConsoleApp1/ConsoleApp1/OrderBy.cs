using System;
using System.Linq;
using System.Collections.Generic;


public class OrderBy
{
    public static void Main()
    {
        // Student collection
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Bill" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

        var multiSortingResult = from s in studentList
                                 orderby s.StudentName, s.Age
                                 select s;


        foreach (var std in multiSortingResult)
            Console.WriteLine("Name: {0}, Age {1}", std.StudentName, std.Age);

        Console.ReadLine();

    }

}

public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }

}