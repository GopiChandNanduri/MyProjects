using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System.Reflection;
using System.Text;

namespace ServiceNowExcel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceFilePath = "InputExcelPath/ServiceNowInput.xlsx";
            string destinationFilePath = "OutputExcelPath";
            List<string> sources = new List<string>() { "Workstream", "Owner", "IssueID" };
            List<int> indexColl = new List<int>();
            
            // Create a new FileInfo object for the source file
            FileInfo sourceFile = new FileInfo(sourceFilePath);

            // Create a new Excel package from the source file
            using (ExcelPackage sourcePackage = new ExcelPackage(sourceFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Get the first worksheet from the source file
                ExcelWorksheet sourceWorksheet = sourcePackage.Workbook.Worksheets[0];

                List<string> headers = new List<string>();
                Dictionary<string, List<StringBuilder>> rowsData = new Dictionary<string, List<StringBuilder>>();

                foreach (var item in sources)
                {
                    indexColl.Add(FindColumnIndex(sourceWorksheet, item));
                }

                int rowCount = sourceWorksheet.Dimension.Rows;
                int columnCount = sourceWorksheet.Dimension.Columns;
                for (int col = 1; col <= columnCount; col++)
                {
                    headers.Add(sourceWorksheet.Cells[1, col].Value?.ToString());
                }

                for (int row = 2; row <= rowCount; row++)
                {
                    string key = FetchUniqueKey(sourceWorksheet, row, indexColl);

                    StringBuilder sb = new StringBuilder();

                    for (int col = 1; col <= columnCount; col++)
                    {
                        sb.Append(sourceWorksheet.Cells[row, col].Value);
                        sb.Append("||");
                    }
                    
                    if (rowsData.TryGetValue(key, out List<StringBuilder> rowData))
                    {
                        rowData.Add(sb);
                    }
                    else
                        rowsData.Add(key, new List<StringBuilder>() { sb });

                }

                DeleteExistingFiles(destinationFilePath);

                int fileNumber = 1;
                // Save separate files 
                foreach (var data in rowsData.Values)
                {
                    using (ExcelPackage destinationPackage = new ExcelPackage())
                    {
                        // Create a new worksheet in the destination file
                        ExcelWorksheet destinationWorksheet = destinationPackage.Workbook.Worksheets.Add("Sheet1");

                        // Add headers from the source worksheet
                        int i = 1;
                        foreach (var headerName in headers)
                        {
                            destinationWorksheet.Cells[1, i].Value = headerName;
                            i++;
                        }

                        // Add Data
                        int row = 2;
                        foreach (var rowData in data)
                        {
                            string[] colData = rowData.ToString().Split("||");
                            int col = 1;
                            foreach (var item in colData)
                            {
                                destinationWorksheet.Cells[row, col].Value = item;
                                col++;
                            }
                            row++;
                        }

                        // Save the destination Excel package to a new file
                        FileInfo destinationFile = new FileInfo(Path.Combine(destinationFilePath,"ServiceNow"+ fileNumber.ToString()+ ".xlsx"));
                        destinationPackage.SaveAs(destinationFile);
                        fileNumber++;
                    }
                }
            }

            Console.WriteLine("Data copied successfully.");
        }

        private static void DeleteExistingFiles(string destinationFilePath)
        {
            // Check if the directory exists
            if (Directory.Exists(destinationFilePath))
            {
                // Get all files in the directory
                string[] files = Directory.GetFiles(destinationFilePath);

                // Delete each file
                foreach (string file in files)
                {
                    File.Delete(file);
                    Console.WriteLine($"Deleted file: {file}");
                }

                Console.WriteLine("All files deleted successfully.");
            }
            else
            {
                Directory.CreateDirectory(destinationFilePath);
                Console.WriteLine("Directory not found so created.");
            }
        }

        private static string FetchUniqueKey(ExcelWorksheet sourceWorksheet, int row, List<int> colIndexs)
        {
            string uniqueKey = string.Empty;
            foreach (var item in colIndexs)
            {
                uniqueKey += sourceWorksheet.Cells[row, item].Value?.ToString();
            }
            return uniqueKey;
        }

        static int FindColumnIndex(ExcelWorksheet worksheet, string columnName)
        {
            // Iterate through the header row to find the column index based on the column name
            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
            {
                var headerCellValue = worksheet.Cells[1, col].Text;
                if (headerCellValue.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return col;
                }
            }

            // Return -1 if the column name is not found
            return -1;
        }

    }
}
