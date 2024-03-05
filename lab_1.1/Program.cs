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

    public void PrintStudents()
    {
        foreach (var student in _students)
        {
            Console.WriteLine($"{student.Id}: {student.Name}, {student.Age}");
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var database = new Database();

        // Додати тестових даних
        database.AddStudent(new Student(1, "Petlyura", 15));
        database.AddStudent(new Student(2, "Bandera", 16));
        database.AddStudent(new Student(3, "Valodya_Zhelexyakus", 17));

        // Вивести список студентів
        database.PrintStudents();
    }
}
