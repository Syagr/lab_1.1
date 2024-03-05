using System;
using System.Collections.Generic;
using System.Linq;

public class Database
{
    private readonly List<Student> _students;

    public Database()
    {
        _students = new List<Student>();
    }

    public void AddStudent(Student student) => _students.Add(student);

    public IEnumerable<Student> GetStudents() => _students;

    public void PrintStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id}: {student.Name}, {student.Age}, {student.City}, {student.AverageScore}");
        }
    }

    public IEnumerable<Student> GetStudentsByAge(int minAge, int maxAge)
    {
        return _students.Where(s => s.Age >= minAge && s.Age <= maxAge);
    }

    public IEnumerable<Student> GetStudentsByCity(string city)
    {
        return _students.Where(s => s.City == city);
        _students.FirstOrDefault(x=>x.Age>18)
    }

    public IEnumerable<Student> GetStudentsByAverageScore(double minScore)
    {
        return _students.Where(s => s.AverageScore >= minScore);
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public double AverageScore { get; set; }

    public Student(int id, string name, int age, string city, double averageScore)
    {
        Id = id;
        Name = name;
        Age = age;
        City = city;
        AverageScore = averageScore;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var database = new Database();

        database.AddStudent(new Student(1, "Petlyura", 15, "Kyiv", 4.5));
        database.AddStudent(new Student(2, "Bandera", 16, "Lviv", 4.8));
        database.AddStudent(new Student(3, "Valodya_Zhelexyakus", 17, "Kharkiv", 4.2));
        database.AddStudent(new Student(4, "Taras_Bulba", 18, "Chernihiv", 4.0));
        database.AddStudent(new Student(5, "Ivan_Franko", 19, "Ternopil", 4.9));

        database.PrintStudents(database.GetStudents());


        Console.WriteLine("\nStudents over the age of 18:");
        database.PrintStudents(database.GetStudentsByAge(18, 18));

        Console.WriteLine("\nStudents from the city of Kyiv:");
        database.PrintStudents(database.GetStudentsByCity("Kyiv"));

        Console.WriteLine("\nStudents with a grade point average above 4.5:");
        database.PrintStudents(database.GetStudentsByAverageScore(4.5));
    }
}
