using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace libemployee{
    public class Employee
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
}