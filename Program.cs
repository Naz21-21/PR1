using System;

class Address
{
    public string Index { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public string Apartment { get; set; }
}

class Converter
{
    public double USD { get; set; }
    public double EUR { get; set; }
    public double PLN { get; set; }

    public Converter(double usd, double eur, double pln)
    {
        USD = usd;
        EUR = eur;
        PLN = pln;
    }

    public double ConvertFromUAH(double amount, string currency)
    {
        return currency.ToUpper() switch
        {
            "USD" => amount / USD,
            "EUR" => amount / EUR,
            "PLN" => amount / PLN,
            _ => 0
        };
    }

    public double ConvertToUAH(double amount, string currency)
    {
        return currency.ToUpper() switch
        {
            "USD" => amount * USD,
            "EUR" => amount * EUR,
            "PLN" => amount * PLN,
            _ => 0
        };
    }
}

class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int Experience { get; set; }

    public Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public double CalculateSalary()
    {
        double baseSalary = Position.ToLower() switch
        {
            "junior" => 1000,
            "middle" => 2000,
            "senior" => 3000,
            _ => 1500
        };
        return baseSalary + Experience * 100;
    }

    public double CalculateTax()
    {
        return CalculateSalary() * 0.18;
    }
}

class User
{
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime RegistrationDate { get; }

    public User()
    {
        RegistrationDate = DateTime.Now;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"\nКористувач: {FirstName} {LastName}");
        Console.WriteLine($"Логін: {Login}");
        Console.WriteLine($"Вік: {Age}");
        Console.WriteLine($"Дата реєстрації анкети: {RegistrationDate}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Виберіть завдання (1-Address, 2-Converter, 3-Employee, 4-User):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                RunAddress();
                break;
            case 2:
                RunConverter();
                break;
            case 3:
                RunEmployee();
                break;
            case 4:
                RunUser();
                break;
            default:
                Console.WriteLine("Невірний вибір");
                break;
        }
    }

    static void RunAddress()
    {
        Address myAddress = new Address
        {
            Index = "01001",
            Country = "Ukraine",
            City = "Kyiv",
            Street = "Khreshchatyk",
            House = "22",
            Apartment = "15"
        };

        Console.WriteLine("Поштова адреса:");
        Console.WriteLine($"{myAddress.Index}, {myAddress.Country}, {myAddress.City}, {myAddress.Street}, буд. {myAddress.House}, кв. {myAddress.Apartment}");
    }

    static void RunConverter()
    {
        Converter converter = new Converter(36.9, 39.5, 8.3);

        Console.WriteLine("Введіть тип операції: 1 - з грн в валюту, 2 - з валюти в грн");
        int type = int.Parse(Console.ReadLine());

        Console.WriteLine("Введіть валюту (USD, EUR, PLN):");
        string currency = Console.ReadLine();

        Console.WriteLine("Введіть суму:");
        double amount = double.Parse(Console.ReadLine());

        double result = type == 1 ? converter.ConvertFromUAH(amount, currency) : converter.ConvertToUAH(amount, currency);

        Console.WriteLine($"Результат: {result:F2} {currency}");
    }

    static void RunEmployee()
    {
        Console.WriteLine("Введіть ім'я:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Введіть прізвище:");
        string lastName = Console.ReadLine();
        Console.WriteLine("Введіть посаду (junior/middle/senior):");
        string position = Console.ReadLine();
        Console.WriteLine("Введіть стаж (роки):");
        int experience = int.Parse(Console.ReadLine());

        Employee employee = new Employee(firstName, lastName)
        {
            Position = position,
            Experience = experience
        };

        Console.WriteLine($"\nСпівробітник: {employee.FirstName} {employee.LastName}");
        Console.WriteLine($"Посада: {employee.Position}");
        Console.WriteLine($"Оклад: {employee.CalculateSalary():F2}");
        Console.WriteLine($"Податок: {employee.CalculateTax():F2}");
    }

    static void RunUser()
    {
        User user = new User();

        Console.WriteLine("Введіть логін:");
        user.Login = Console.ReadLine();
        Console.WriteLine("Введіть ім'я:");
        user.FirstName = Console.ReadLine();
        Console.WriteLine("Введіть прізвище:");
        user.LastName = Console.ReadLine();
        Console.WriteLine("Введіть вік:");
        user.Age = int.Parse(Console.ReadLine());

        user.DisplayInfo();
    }
}
