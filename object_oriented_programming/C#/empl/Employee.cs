using System;
using System.IO;
using System.Collections.Generic;

class ReadCsv
{
    public static List<string[]> ReadCsvFile(string filePath)
    {
        List<string[]> rows = new List<string[]>();

        try
        {
            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Process each line and split by the comma to get individual values
            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                // Add the values to the list of rows
                rows.Add(values);
            }

            Console.WriteLine("CSV file read successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return rows;
    }
}

class Employee
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }

    // Constructor with parameters
    public Employee(int id, string name, string department)
    {
        Id = id;
        Name = name;
        Department = department;
    }

    // Default constructor
    public Employee() { }
}

class Incomes
{
    
    public int Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int Income { get; set; }

    // Constructor with parameters
    public Incomes(int id, int month, int year, int income)
    {
        Id = id;
        Month = month;
        Year = year;
        Income = income;
    }

    // Default constructor
    public Incomes() { }
}

class Program
{
    static StreamWriter log;
    static void Main()
    {
        log= new StreamWriter("log.csv", true);
        // Create a list to store Employee objects
        List<Employee> employees = new List<Employee>();
        
        // Specify the path to the CSV file
        string csvFilePath = "emps.csv";
        
        // Call the method to read and process the CSV data
        List<string[]> employeeData = ReadCsv.ReadCsvFile(csvFilePath);
        
        // Process each row in the CSV data
        foreach (string[] row in employeeData)
        {             
            int id = int.Parse(row[0]);
            string name = row[1];
            string department = row[2];

            // Add the Employee object to the list
            //Employee employee = new Employee (id,name,department);
            employees.Add(new Employee(id, name, department)); 
            //employees.Add(employee);           
        }

        // Display the employees
        Console.WriteLine("Employees created from CSV:");
        foreach (Employee employee in employees)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}");
        }

        List<Incomes> incomes = new List<Incomes>();

        string csvFilePath2 = "income.csv";

        List<string[]> incomeData = ReadCsv.ReadCsvFile(csvFilePath2);

        foreach (string[] row in incomeData)
        {             
            int id = int.Parse(row[0]);
            int month = int.Parse(row[1]);
            int year = int.Parse(row[2]);
            int income = int.Parse(row[3]);

            // Add the Employee object to the list
            incomes.Add(new Incomes(id, month, year, income));              
        }

        Console.WriteLine("Income created from CSV:");
        foreach (Incomes income in incomes)
        {
            Console.WriteLine($"Id: {income.Id}, Month: {income.Month}, Year: {income.Year} , Income: {income.Income}");
        }

        int cont=0;
        foreach(var income in incomes){
            foreach(var employee in employees){
                if(income.Id == employee.Id){
                    cont++;
                    Console.WriteLine($"{employee.Name} {income.Month} {income.Year} {employee.Department} {income.Income}");
                    log.WriteLine($"{employee.Name},{income.Month},{income.Year},{employee.Department},{income.Income}");
                }
            }
        }
        Console.WriteLine(cont);
        log.Flush();
    }
}



