using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace libincome{
    public class Incomes
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
}