using Core.Data;

namespace Core.Interface
{
    public interface IWriteToFile
    {
        void WriteToJsonFile(ProductsInfo productsInfo, string fileName);
        void WriteToXmlFile(ProductsInfo productsInfo, string fileName);
        void WriteToCsvFile(ProductsInfo productsInfo, string fileName);
        void WriteToExcelFile(ProductsInfo productsInfo, string fileName);
    }
}