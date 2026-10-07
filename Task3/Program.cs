//1
using System;
using System.Collections.Generic;
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }

    private bool isAvailable;
    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        isAvailable = true;
    }
    public void BorrowBook()
    {
        if (isAvailable)
        {
            isAvailable = false;
            Console.WriteLine($"'{Title}' kitabi goturuldu.");
        }
        else
        {
            Console.WriteLine($"'{Title}' kitabi artiq goturulub!");
        }
    }
    public void ReturnBook()
    {
        if (!isAvailable)
        {
            isAvailable = true;
            Console.WriteLine($"'{Title}' kitabi qaytarildi.");
        }
        else
        {
            Console.WriteLine($"'{Title}' kitabi artiq kitabxanadadir.");
        }
    }

    public void DisplayInfo()
    {
        string status = isAvailable ? "Movcuddur" : "Goturulub";
        Console.WriteLine($"Kitab: {Title} | Muellif: {Author} | ISBN: {ISBN} | Status: {status}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Book> library = new List<Book>()
        {
            new Book("1984", "Corc Oruell", "102"),
            new Book("Xemse", "Nizami Gencevi", "103"),
            new Book("Deli Kur", "Ismayil Sixli", "104"),
            new Book("Ag Gemi", "Cingiz Aytmatov", "105")
        };

        Console.WriteLine("--- Ilkin kitab siyahisi ---");
        foreach (var book in library)
        {
            book.DisplayInfo();
        }

        Console.WriteLine("\n--- 2 kitabin goturulmesi ---");
        library[0].BorrowBook();
        library[2].BorrowBook();

        Console.WriteLine("\n--- Son veziyyet ---");
        foreach (var book in library)
        {
            book.DisplayInfo();
        }
    }
}

//2
using System;
using System.Collections.Generic;
public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}
public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }

    public double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}
public class Triangle : IShape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
    public double Height { get; set; }

    public Triangle(double a, double b, double c, double height)
    {
        SideA = a;
        SideB = b;
        SideC = c;
        Height = height;
    }

    public double CalculateArea()
    {
        return (SideA * Height) / 2;
    }

    public double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }
}
public class ShapeHelper
{
    public double CalculateArea(double radius)
    {
        return Math.PI * radius * radius;
    }

    public double CalculateArea(double width, double height)
    {
        return width * height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IShape> shapes = new List<IShape>()
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5, 4)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine("Fiqur: " + shape.GetType().Name);
            Console.WriteLine("Sahe: " + Math.Round(shape.CalculateArea(), 2));
            Console.WriteLine("Perimetr: " + Math.Round(shape.CalculatePerimeter(), 2));
            Console.WriteLine("------------------------");
        }
    }
}

//3
using System;
using System.Collections.Generic;

public class Vehicle
{
    public string Brand { get; set; }
    public double Speed { get; set; }

    public Vehicle(string brand, double speed)
    {
        Brand = brand;
        Speed = speed;
    }
    public virtual void MakeSound()
    {
        Console.WriteLine($"{Brand} ses cixarir.");
    }
}
public class Car : Vehicle
{
    public Car(string brand, double speed) : base(brand, speed) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Brand} (Masin): Bip bip!");
    }
}
public class Motorcycle : Vehicle
{
    public Motorcycle(string brand, double speed) : base(brand, speed) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Brand} (Motosiklet): Vrrr vrrr!");
    }
}
public class Bicycle : Vehicle
{
    public Bicycle(string brand, double speed) : base(brand, speed) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Brand} (Velosiped): Ding ding!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Car("BMW", 240),
            new Motorcycle("Yamaha", 180),
            new Bicycle("Giant", 30)
        };

        foreach (var v in vehicles)
        {
            Console.WriteLine($"Marka: {v.Brand}, Sürət: {v.Speed} km/s");
            v.MakeSound();
            Console.WriteLine("-------------------");
        }
    }
}

//4
using System;
using System.Collections.Generic;
public abstract class Employee
{
    public string Name { get; set; }
    private double baseSalary;

    public Employee(string name, double salary)
    {
        Name = name;
        SetSalary(salary);
    }
    public double GetSalary()
    {
        return baseSalary;
    }
    public void SetSalary(double salary)
    {
        if (salary >= 0)
        {
            baseSalary = salary;
        }
        else
        {
            Console.WriteLine("Maas menfi ola bilmez!");
        }
    }
    public abstract double CalculateBonus();
}
public class Manager : Employee
{
    public Manager(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus()
    {
        return GetSalary() * 0.20;
    }
}

public class Intern : Employee
{
    public Intern(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus()
    {
        return 100;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>()
        {
            new Manager("Elvin", 2000),
            new Manager("Anar", 2500),
            new Intern("Murad", 500),
            new Intern("Aysel", 600)
        };

        foreach (var emp in employees)
        {
            double baseSalary = emp.GetSalary();
            double bonus = emp.CalculateBonus();
            double totalSalary = baseSalary + bonus;

            Console.WriteLine($"Isci: {emp.Name}");
            Console.WriteLine($"Esas maas: {baseSalary} AZN | Bonus: {bonus} AZN | Umumi: {totalSalary} AZN");
            Console.WriteLine("---------------------------------------------");
        }
    }
}