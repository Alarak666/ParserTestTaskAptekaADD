using Core.Constant.Enum;
using Core.Data;
using Core.Interface;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using OpenQA.Selenium.Support.UI;

namespace Core.Service
{
    public class ParserService : IParserService
    {
        #region publicMethod

        #region Info
        /// <summary>
        /// HTML-код страницы, из которого производится извлечение информации о категориях.
        /// </summary>
        ///string html;
        ///
        /// <summary>
        /// Список кортежей, содержащих URL и названия категорий, извлеченных из HTML-кода.
        /// </summary>
        ///List<Tuple<string, string>> extractedData = new List<Tuple<string, string>>();
        ///
        /// <summary>
        /// Объект типа HtmlDocument из библиотеки HtmlAgilityPack, используемый для парсинга HTML.
        /// </summary>
        ///HtmlDocument doc = new HtmlDocument();
        ///
        /// <summary>
        /// Элемент <ul> с классом 'categories-list', содержащий список категорий.
        /// </summary>
        ///HtmlNode categoryList;
        ///
        /// <summary>
        /// Коллекция элементов <li>, представляющих каждую категорию в списке.
        /// </summary>
        ///HtmlNodeCollection categoryItems;
        ///
        /// <summary>
        /// Счетчик, используемый для отслеживания порядкового номера категории.
        /// </summary>
        ///int count = 0;
        ///
        /// <summary>
        /// Текущий элемент <li>, представляющий отдельную категорию.
        /// </summary>
        ///HtmlNode item;
        ///
        /// <summary>
        /// Внутренний <div> с классом 'advancedmenu-wrap' внутри элемента <li>.
        /// </summary>
        ///HtmlNode advancedMenuWrap
        ///
        /// <summary>
        /// Внутренний <div> с классом 'opener-inside' внутри <div class="advancedmenu-wrap">.
        /// </summary>
        ///HtmlNode openerInside
        ///
        /// <summary>
        /// Элемент <a> с атрибутом href, содержащий ссылку на категорию.
        /// </summary>
        ///HtmlNode link
        ///
        /// <summary>
        /// Последний <span> внутри <div class="opener-inside">, содержащий название категории.
        /// </summary>
        ///HtmlNode name;
        /// 
        /// <summary>
        /// URL категории, извлеченный из атрибута href элемента <a>.
        /// </summary>
        ///string url;
        /// 
        /// <summary>
        /// Название категории, извлеченное из текста последнего <span>.
        /// </summary>
        ///string categoryName;
        /// 
        /// <returns>Список кортежей с URL и названиями категорий</returns>
        #endregion

        public async Task<List<Tuple<string, string>>> ExtractAllCategory(string html)
        {
            List<Tuple<string, string>> extractedData = new List<Tuple<string, string>>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                var categoryList = doc.DocumentNode.SelectSingleNode("//ul[@class='categories-list']");
                if (categoryList != null)
                {
                    var categoryItems = categoryList.SelectNodes(".//li");

                    if (categoryItems != null && categoryItems.Count > 0)
                    {
                        int count = 0;

                        foreach (var item in categoryItems)
                        {
                            count++;

                            var advancedMenuWrap = item.SelectSingleNode(".//div[contains(@class, 'advancedmenu-wrap')]");
                            if (advancedMenuWrap != null)
                            {
                                var openerInside = advancedMenuWrap.SelectSingleNode(".//div[contains(@class, 'opener-inside')]");
                                if (openerInside != null)
                                {
                                    var link = openerInside.SelectSingleNode(".//a[@href]");
                                    var name = openerInside.SelectSingleNode(".//span[last()]");

                                    if (link != null && name != null)
                                    {
                                        string url = link.Attributes["href"].Value;
                                        string categoryName = name.InnerText.Trim();

                                        if (!string.IsNullOrEmpty(categoryName))
                                            extractedData.Add(new Tuple<string, string>(url, categoryName));

                                        Console.WriteLine($"Category Name: {categoryName}, URL: {url}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting data: {ex.Message}");
            }

            return extractedData;
        }

        public async Task ExtractAllProductsInCategory(IWebDriver driver, Tuple<string, string> url, IWriteToFile writeToFile, List<FileWriteCheck> fileWriteChecks)
        {
            driver.Navigate().GoToUrl(url.Item1);

            List<string> visitedLinks = new List<string>();
            ProductsInfo extractedData;
            // Пример цикла, в котором выполняется навигация
            extractedData = new ProductsInfo()
            {
                CategoryName = url.Item2,
                CategoryUrl = url.Item1,
                Products = new List<Product>()
            };
            int count = 0;
            while (true)
            {
                string html = driver.PageSource;
                var items = ScrapProduct(html, driver);

                count = +items.Count;
                extractedData.Products.AddRange(items);

                IReadOnlyCollection<IWebElement> nextLink = driver.FindElements(By.CssSelector("li.item.action-pages-item.pages-item-next a"));

                if (nextLink.Count <= 0)
                {
                    break;
                }

                string nextLinkHref = nextLink.First().GetAttribute("href");

                // Проверяем, посещали ли мы эту ссылку ранее
                if (visitedLinks.Contains(nextLinkHref))
                {
                    Console.WriteLine("Эта ссылка уже посещалась, выход из цикла.");
                    break;
                }

                // Добавляем текущую ссылку в список посещенных
                visitedLinks.Add(nextLinkHref);

                driver.Navigate().GoToUrl(nextLinkHref);
            }

            extractedData.ProductCount = count;

            foreach (var item in fileWriteChecks)
            {
                switch (item)
                {
                    case FileWriteCheck.Json:
                        writeToFile.WriteToJsonFile(extractedData, url.Item2);
                        break;
                    case FileWriteCheck.Xml:
                        writeToFile.WriteToXmlFile(extractedData, url.Item2);
                        break;
                    case FileWriteCheck.Csv:
                        writeToFile.WriteToCsvFile(extractedData, url.Item2);
                        break;
                    case FileWriteCheck.Excel:
                        writeToFile.WriteToExcelFile(extractedData, url.Item2);
                        break;
                }
            }
        }

        #endregion

        #region privateMethod
        /// <summary>
        /// Извлекает данные о продуктах из HTML-кода страницы и добавляет их в список продуктов.
        /// </summary>
        /// <param name="html">HTML-код страницы, из которого извлекаются данные о продуктах.</param>
        /// <param name="driver">Экземпляр веб-драйвера (IWebDriver) для взаимодействия с браузером.</param>
        /// <returns>Список продуктов (List<Product>), содержащий извлеченные данные о продуктах.</returns>

        // Обновленный метод ScrapProduct для взаимодействия с каждой записью
        private List<Product> ScrapProduct(string html, IWebDriver driver)
        {
            var products = new List<Product>();

            IWebElement productList = driver.FindElement(By.CssSelector("ol.products.list.items.product-items"));
            IList<IWebElement> productItems = productList.FindElements(By.CssSelector("li.item.product.product-item"));

            foreach (var productItem in productItems)
            {
                var product = new Product();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,200)", "");
                string currentWindowHandle = driver.CurrentWindowHandle;

                try
                {
                    var defaultValue = 0;

                    // Открытие страницы продукта
                    //   string productUrl = productItem.FindElement(By.CssSelector("a.product-item-link")).GetAttribute("href");
                    //driver.Navigate().GoToUrl(productUrl);
                    IWebElement link = productItem.FindElement(By.CssSelector("a.product-item-link"));
                    link.SendKeys(Keys.Control + Keys.Return);
                    driver.SwitchTo().Window(driver.WindowHandles.Last());



                    IWebElement tableElement = driver.FindElement(By.Id("product-attribute-specs-table"));
                    var attributes = GetProductAttributes(tableElement);

                    product.Manufacturer = attributes.ContainsKey("Виробник")
                        ? attributes["Виробник"]
                        : "Manufacturer not available";
                    product.Barcode = attributes.ContainsKey("Штрих-код")
                        ? attributes["Штрих-код"]
                        : "Barcode not available";

                    var allInfoElement = driver.FindElement(By.CssSelector(".all-info-wrapper"));

                    product.Id = GetProductField(allInfoElement, ".product.attribute.sku .value", text => text.Trim(),
                        "");
                    product.ProductName = GetProductField(allInfoElement,
                        ".page-title-wrapper.product > h1 > span.base", text => text, "Product name not available");

                    product.NewPrice = GetProductField(allInfoElement, ".price", text => ParsePrice(text), 0m);
                    product.OldPrice = GetProductField(allInfoElement, ".old-price", text => ParsePrice(text), 0m);

                    products.Add(product);

                    // Navigate back to the previous page



                    // Wait for the productList element to be present

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    driver.Close();
                    driver.SwitchTo().Window(currentWindowHandle);
                }
            }

            return products;
        }


        /// <summary>
        /// Извлекает значение поля из элемента веб-страницы, используя переданный селектор CSS и функцию парсинга.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="productItem">Элемент веб-страницы, содержащий требуемое поле</param>
        /// <param name="selector">Селектор CSS для поиска элемента на веб-странице</param>
        /// <param name="parser">Функция парсинга для преобразования текста поля в заданный тип</param>
        /// <param name="defaultValue">Значение по умолчанию, возвращаемое, если поле не найдено или не может быть спарсено</param>
        /// <returns>Возвращает значение поля заданного типа, полученное из элемента веб-страницы, либо значение по умолчанию</returns>

        private T GetProductField<T>(IWebElement productItem, string selector, Func<string, T> parser, T defaultValue)
        {
            IReadOnlyCollection<IWebElement> elements = productItem.FindElements(By.CssSelector(selector));

            if (elements.Count > 0)
            {
                string text = elements.First().Text;
                return parser(text);
            }

            return defaultValue;
        }
        private Dictionary<string, string> GetProductAttributes(IWebElement table)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();

            // Находим все строки в таблице
            IList<IWebElement> rows = table.FindElements(By.CssSelector("tr"));

            // Проходим по каждой строке и добавляем значения в словарь
            var count = 0;
            foreach (var row in rows)
            {
                var attributeName = row.FindElements(By.CssSelector("th"))[0].Text;
                var attributeValue = row.FindElements(By.CssSelector("td"))[0].Text;

                attributes[attributeName] = attributeValue;

                count += attributeName is "Штрих-код" or "Виробник" ? 1 : 0;
                if (count == 2) break;
            }

            return attributes;
        }

        /// <summary>
        /// Преобразует текст цены в числовое значение типа decimal.
        /// </summary>
        /// <param name="priceText">Текст цены, который требуется преобразовать</param>
        /// <returns>Числовое значение цены типа decimal, полученное из текста, либо 0, если преобразование не удалось</returns>

        private decimal ParsePrice(string priceText)
        {
            decimal price = 0;

            // Удаление ненужных символов и преобразование текста в число
            if (!string.IsNullOrEmpty(priceText))
            {
                priceText = priceText.Replace("₴", "").Replace(".", ",").Replace(" ", "");
                decimal.TryParse(priceText, out price);
            }

            return price;
        }

        #endregion
    }
}
