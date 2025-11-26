using System;
using System.Collections.Concurrent;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;



// Задание 1


struct Color
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public Color(int R, int G, int B)
    {
        this.R = R;
        this.G = G;
        this.B = B;
    }

    public override string ToString()
    {
        return $"RGB({R},{G}, {B})";

    }
}


// Задание 2


class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }

}


// Задание 3


[Flags]
enum FileAccess
{
    None, Read, Write, Execute
}
struct File
{
    public  FileAccess Permissios {  get; set; }
    
    public bool CanRead()
        { return true; }
    public bool CanWrite()
    {  return true; }
}

//  Задание 4


struct Weather
{
    public string City { get; set; }
    public double? Temperature {  get; set; }

    public override string ToString()
    {
        if (Temperature == null)
            return $"{City} : Нет данных";
        else
            return $"{City} : {Temperature .ToString()}";
    }
}


// Задание 5

enum EmploymentStatus { Active, OnLeave, Terminated}
class Employee
{
    public string Name { get; set; }
    public DateTime? HireDate { get; set; }
    public EmploymentStatus Status { get; set; }

    public int GetYearsWorked()
    {
        if (HireDate == null)
        {
            return -1;
        }
        return DateTime.Now.Year - HireDate.Value.Year;
    }
    public override string ToString()
    {
        return $"Имя: {Name},Статус: {Status},Стаж: {HireDate?.ToString("dd.MM.yyyy") ?? "Не указан"}";
    }
}


internal class Program
{
    static void Main(string[] args)
    {
        // Задание 1
        var c1 = new Color(255, 128, 0);
        var c2 = c1;
        c2.R = 100;
        Console.WriteLine(c1);
        Console.WriteLine(c2);
        Console.WriteLine();


        // Задание 2
        var Order1 = new Order { Id = 1001, Total = 1500.50m };
        var Order2 = Order1;
        Order2.Total = 2000.00m;
        Console.WriteLine(Order1.Total);
        Console.WriteLine();


        // Задание 3
        var f = new File { Permissios = FileAccess.Read | FileAccess.Write };
        Console.WriteLine(f.CanRead());
        Console.WriteLine(f.CanWrite());
        Console.WriteLine();

        // Задание 4

        var w1 = new Weather { City = "Москва", Temperature = 22.5 };
        var w2 = new Weather { City = "Сочи", Temperature = null };
        Console.WriteLine(w1);
        Console.WriteLine(w2);
        Console.WriteLine(w2.Temperature ?? -999);
        Console.WriteLine();


        // Задание 5

        var emp = new Employee
        {
            Name = "Петр",
            HireDate = new DateTime(2020, 3, 15),
            Status = EmploymentStatus.Active
        };
        Console.WriteLine(emp.GetYearsWorked());
        emp.HireDate = null;
        Console.WriteLine(emp.GetYearsWorked());
        Console.WriteLine(emp);
    }
}
