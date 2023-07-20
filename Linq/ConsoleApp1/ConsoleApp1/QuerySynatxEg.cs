using System;
using System.Linq;
using System.Collections.Generic;


    //public static void Main()
    //{
    //    // string collection
    //    IList<string> stringList = new List<string>() {
    //        "C# Tutorials",
    //        "VB.NET Tutorials",
    //        "Learn C++",
    //        "MVC Tutorials" ,
    //        "Java"
    //    };

    //    // LINQ Query Syntax
    //    var result = from s in stringList
    //                 where s.Contains("Tutorials")
    //                 select s;

    //    foreach (var str in result)
    //    {
    //        Console.WriteLine(str);
    //    }
    //}
    //}

    class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }
    }


    delegate bool FindStudent(Student std);

    class StudentExtension
    {
        public static Student[] where(Student[] stdArray, FindStudent del)
        {
            int i = 0;
            Student[] result = new Student[10];
            foreach (Student std in stdArray)
                if (del(std))
                {
                    result[i] = std;
                    i++;
                }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] studentArray = {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
            new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
            new Student() { StudentID = 7, StudentName = "Rob",Age = 19  } ,
        };

            Student[] students = StudentExtension.where(studentArray, delegate (Student std) {
                return std.Age > 12 && std.Age < 20;
            });
        }
    }
