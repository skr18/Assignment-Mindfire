using System;
using System.Linq;
using System.Collections.Generic;


public class Program
{
    public static void Main()
    {
        // Student collection
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

        var lookupResult = studentList.ToLookup(s => s.Age);

        var groupedResult = from s in studentList
                            group s by s.Age;

        foreach (var group in lookupResult)
        {
            Console.WriteLine("Age Group: {0}", group.Key);  //Each group has a key 

            foreach (Student s in group)  //Each group has a inner collection  
                Console.WriteLine("Student Name: {0}", s.StudentName);
        }
        Console.ReadLine();

    }

}

public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }

}