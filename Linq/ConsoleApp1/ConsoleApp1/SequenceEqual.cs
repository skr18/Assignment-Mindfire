using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        IList<Student> studentList1 = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John" },
            new Student() { StudentID = 2, StudentName = "Steve" },
            new Student() { StudentID = 3, StudentName = "Bill" },
            new Student() { StudentID = 4, StudentName = "Ram"  },
            new Student() { StudentID = 5, StudentName = "Ron" }
        };

        IList<Student> studentList2 = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John" },
            new Student() { StudentID = 2, StudentName = "Steve" },
            new Student() { StudentID = 3, StudentName = "Bill" },
            new Student() { StudentID = 4, StudentName = "Ram" },
            new Student() { StudentID = 5, StudentName = "Ron" }
        };

        bool isEqual = studentList1.SequenceEqual(studentList2, new StudentComparer());

        Console.WriteLine(isEqual);
        Console.ReadLine();

    }
}

public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
}

class StudentComparer : IEqualityComparer<Student>
{
    public bool Equals(Student x, Student y)
    {
        if (x.StudentID == y.StudentID && x.StudentName.ToLower() == y.StudentName.ToLower())
            return true;

        return false;
    }

    public int GetHashCode(Student obj)
    {
        return obj.GetHashCode();
    }
}