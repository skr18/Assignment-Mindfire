using System;
interface IFile
{
    void ReadFile();
    void WriteFile(string text);
}

class FileInfo : IFile
{
    void IFile.ReadFile()
    {
        Console.WriteLine("Reading File");
    }

    void IFile.WriteFile(string text)
    {
        Console.WriteLine("Writing to file");
    }

    public void Search(string text)
    {
        Console.WriteLine("Searching in file");
    }
}

internal class Interface
    {
        public static void Main()
        {
            IFile file1 = new FileInfo();
            FileInfo file2 = new FileInfo();

            file1.ReadFile();
            file1.WriteFile("content");
            //file1.Search("text to be searched")//compile-time error 

            file2.Search("text to be searched");
            //file2.ReadFile(); //compile-time error 
            //file2.WriteFile("content"); //compile-time error 
        }
    }

