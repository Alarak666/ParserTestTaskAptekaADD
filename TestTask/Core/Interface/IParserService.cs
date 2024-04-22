using Core.Constant.Enum;
using Core.Data;
using OpenQA.Selenium;
using System.Reflection.Emit;

namespace Core.Interface
{
    public interface IParserService
    {
        Task<List<Tuple<string, string>>> ExtractAllCategory(string htmlDocument);
        Task ExtractAllProductsInCategory(
            IWebDriver driver,
            Tuple<string,
            string>? url,
            IWriteToFile writeToFile,
            List<FileWriteCheck> fileWriteChecks);
    }
}