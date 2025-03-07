

using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;


class BuildDataModel
{
    public static List<dynamic> CreateDataModel(string aCsvFileName)
    {
        aCsvFileName = "C:\\Users\\charl\\OneDrive\\Documents\\csv_data\\house-price.csv";
        var data = new List<dynamic>();
        try
        {
            using (var reader = new StreamReader(aCsvFileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration { CultureInfo = CultureInfo.InvariantCulture }))
            {
                var records = new List<dynamic>();

                while (csv.Read())
                {
                    var record = csv.GetRecord<dynamic>();
                    data.Add(record);
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