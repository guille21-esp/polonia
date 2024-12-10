using System;
using System.Collections.Generic;
using libincome;

namespace libmanager
{
    public class Manager : libemployee.Employee
    {
        private List<libemployee.Employee> employees = new List<libemployee.Employee>();
        private List<Incomes> incomes = new List<Incomes>();

        public Manager(int id, string name, string department)
            : base(id, name, department) // Call the base Employee constructor
        {
        }

        public void Hire(int id, string name, int salary, int month, int year, string dep)
        {
            int newId = employees.Count + 1;

            // Create a new Employee and Income object
            var emp = new libemployee.Employee(newId, name, dep);
            var inc = new Incomes { Id = newId, Month = month, Year = year, Income = salary };

            // Add to the respective lists
            employees.Add(emp);
            incomes.Add(inc);

            Console.WriteLine($"{emp.Name} was hired.");
        }
    }
}