
using System.Diagnostics;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using static BuildDataModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
Console.WriteLine("Enter Path to CSV file");
var directory = Console.ReadLine();
if(string.IsNullOrWhiteSpace(directory))
{
    Console.WriteLine("Enter Path to CSV file");
    directory = Console.ReadLine();
}
else
{
    var dataRecords = CreateDataModel(directory);
    if(dataRecords != null)
    {
        Console.WriteLine("Enter Search Term");
        var searchTerm = Console.ReadLine();
        var filteredRecords = !string.IsNullOrWhiteSpace(searchTerm) ? GetRecordsBySearchTerm(dataRecords, searchTerm) 
            : null;

        if(filteredRecords != null)
        {
            // Output the filtered records
            foreach (var record in filteredRecords)
            {
                foreach (var field in record)
                {
                    Console.Write($"{field.Key}: {field.Value} ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Search return no results!");
        }
    }
}

    
