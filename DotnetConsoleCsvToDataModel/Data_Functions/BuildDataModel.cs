using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using System.Threading.Tasks;

class BuildDataModel
{
    public static async Task<List<dynamic>> CreateDataModel(string aDirectory) // Change parameter name to aDirectory
    {
        aDirectory = "C:\\Users\\charl\\OneDrive\\Documents\\csv_data\\";
        var data = new List<dynamic>();
        
        try
        {
            string[] csvFiles = Directory.GetFiles(aDirectory, "*.csv"); // Get all CSV files in the directory
            foreach (var file in csvFiles)
            {
                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, new CsvConfiguration { CultureInfo = CultureInfo.InvariantCulture }))
                {
                    var records = new List<dynamic>();

                    while (await Task.Run(() => csv.Read())) // Use Task.Run to run the synchronous Read method asynchronously
                    {
                        var record = csv.GetRecord<dynamic>();
                        data.Add(record);
                    }
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"A exception was thrown {e.Message}");
        }
        
        // Output the data to verify
        return data;
    }

    public static List<dynamic> GetRecordsBySearchTerm(List<dynamic> dataRecords, string aSearchTerm)
    {
        var filteredData = dataRecords.Where(record => record != null && aSearchTerm != null && (record as IDictionary<string, object>).Values.Contains(aSearchTerm)).ToList();
        return filteredData;
    }
}