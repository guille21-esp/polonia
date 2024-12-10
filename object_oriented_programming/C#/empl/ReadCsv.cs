using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace libreadcsv{
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
}