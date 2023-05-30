using Microsoft.VisualBasic.FileIO;

namespace CSharpFrameWork.Helpers
{
    public class CsvReaderHelper<T> where T:new()
    {
        public static List<T> Read(string filePath)
        {
            List<T> records = new List<T>();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Read header row
                string[] headers = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    T record = new T();

                    // Assign field values to properties
                    for (int i = 0; i < headers.Length; i++)
                    {
                        string header = headers[i];
                        string value = fields[i];

                        try
                        {
                            var property = typeof(T).GetProperty(header);

                            if (property != null)
                                property.SetValue(record, Convert.ChangeType(value, property.PropertyType));

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error assigning value '{value}' to property '{header}': {e.Message}");
                        }
                    }
                    records.Add(record);
                }
            }

            return records;
        }

    }
}
