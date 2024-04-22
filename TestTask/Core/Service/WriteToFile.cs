using Core.Data;
using Core.Interface;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Core.Service
{
    public class WriteToFile : IWriteToFile
    {
        private void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private string GetFilePath(string subdirectoryName, string fileName)
        {
            string directoryPath = Path.Combine("ParsingData", subdirectoryName);
            EnsureDirectoryExists(directoryPath);
            return Path.Combine(directoryPath, $"{fileName}");
        }
        public void WriteToJsonFile(ProductsInfo productsInfo, string fileName)
        {
            string filePath = GetFilePath("JSON", $"{fileName}.json");

            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Удалить файл, если он уже существует
            }

            string json = JsonConvert.SerializeObject(productsInfo, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void WriteToXmlFile(ProductsInfo productsInfo, string fileName)
        {
            string filePath = GetFilePath("XML", $"{fileName}.xml");

            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Удалить файл, если он уже существует
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ProductsInfo));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, productsInfo);
            }
        }

        public void WriteToCsvFile(ProductsInfo productsInfo, string fileName)
        {
            string filePath = GetFilePath("CSV", $"{fileName}.csv");

            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Удалить файл, если он уже существует
            }

            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(productsInfo.Products.AsEnumerable());
            }
        }

        public void WriteToExcelFile(ProductsInfo productsInfo, string fileName)
        {
            string filePath = GetFilePath("Excel", $"{fileName}.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Если вы используете EPPlus в некоммерческих целях

            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Удалить файл, если он уже существует
            }

            using (var pck = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = pck.Workbook.Worksheets.Add("Product");

                // Данные продуктов
                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "ProductName";
                worksheet.Cells[1, 3].Value = "Manufacturer";
                worksheet.Cells[1, 4].Value = "OldPrice";
                worksheet.Cells[1, 5].Value = "NewPrice";

                int row = 2;
                foreach (var product in productsInfo.Products)
                {
                    worksheet.Cells[row, 1].Value = product.Id;
                    worksheet.Cells[row, 2].Value = product.ProductName;
                    worksheet.Cells[row, 3].Value = product.Manufacturer;
                    worksheet.Cells[row, 4].Value = product.OldPrice;
                    worksheet.Cells[row, 5].Value = product.NewPrice;

                    row++;
                }

                pck.Save();
            }
        }
    }
}
