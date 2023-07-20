﻿using System;
using System.Linq;
using System.Collections.Generic;


public class Program
{
    public static void Main()
    {
        IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
            new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
        };


        string commaSeparatedStudentNames = studentList.Aggregate<Student, string>(
                                            "Here we go :", // seed value
                                            (str, s) => str = str + s.StudentName + " " + s.Age + ",");// returns result using seed value, String.Empty goes to lambda expression as str


        Console.WriteLine(commaSeparatedStudentNames);
        Console.ReadLine();

    }
}

public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
}