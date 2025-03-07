
using System.Diagnostics;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using static BuildDataModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel;
Console.WriteLine("Enter Path to CSV file");
var directory = Console.ReadLine();
if(string.IsNullOrWhiteSpace(directory))
{
    Console.WriteLine("Enter Path to CSV file");
    directory = Console.ReadLine();
}
else
{
    Stopwatch sw = new Stopwatch();
    sw.Start();
    var dataRecords = await CreateDataModel(directory);
    if(dataRecords != null)
    {
        sw.Stop();
        Console.WriteLine($"Elasped Time {sw.Elapsed}");
        Console.WriteLine($"Number of records {dataRecords.Count()}");
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

    
