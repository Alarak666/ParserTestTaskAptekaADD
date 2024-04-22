using Core.Constant.Enum;
using Core.Data;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO.Compression;
namespace Parser
{
    public partial class Form1 : Form
    {
        private readonly IParserService _parserService;
        private readonly IWriteToFile _writeToFile;
        // Изменим конструктор, через Dependency Injection
        public Form1(IParserService parserService, IWriteToFile writeToFile)
        {
            InitializeComponent();
            _parserService = parserService;
            _writeToFile = writeToFile;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var pathToChromeDriver = @"chromedriver.exe";
            try
            {
                IWebDriver driver = new ChromeDriver(pathToChromeDriver);
                driver.Navigate().GoToUrl("https://www.add.ua/");

                // Получаем HTML-код страницы
                string html = driver.PageSource;

                // Далее обрабатываем html, чтобы извлечь все ссылки
                var catalogPaths = await _parserService.ExtractAllCategory(html);
                label3.Text = catalogPaths.Count.ToString();
                //Работа c ссылками
                List<FileWriteCheck> fileChecks = Ckeched();
                var count = 0;
                Thread.Sleep(100);
                foreach (var url in catalogPaths)
                {
                    count++;
                    this.Invoke((MethodInvoker)delegate
                    {
                        label2.Text = $"{count}\\{label3.Text} - {url.Item2}";
                    });
                    try
                    {
                       await _parserService.ExtractAllProductsInCategory(driver, url, _writeToFile, fileChecks);
                    }
                    catch (Exception ex)
                    {
                        string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");
                        LogExceptionToFile(Path.Combine(logFilePath), ex);
                    }
                }

                driver.Quit();
                MessageBox.Show($"Complete parsing {label3.Text}//{count}");

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
        }
        private void LogExceptionToFile(string logFilePath, Exception exception)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now} - Exception: {exception.Message}");
                    sw.WriteLine($"StackTrace: {exception.StackTrace}");
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл лога: {ex.Message}");
            }
        }
        private List<FileWriteCheck> Ckeched()
        {
            var listCheck = new List<FileWriteCheck>();
            foreach (System.Windows.Forms.Control control in panel2.Controls)
            {
                if (control is System.Windows.Forms.CheckBox checkBox && checkBox.Checked)
                {
                    switch (checkBox.Text)
                    {
                        case "Json":
                            listCheck.Add(FileWriteCheck.Json);
                            break;
                        case "Xml":
                            listCheck.Add(FileWriteCheck.Xml);
                            break;
                        case "Csv":
                            listCheck.Add(FileWriteCheck.Csv);
                            break;
                        case "Excel":
                            listCheck.Add(FileWriteCheck.Excel);
                            break;
                            // Добавьте case для остальных чекбоксов, если необходимо
                    }
                }
            }
            return listCheck;
        }
        private void Fill_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine("ParsingData", "JSON");

            // Получение списка файлов в директории
            string[] files = Directory.GetFiles(folderPath);

            // Создание списка объектов с названиями файлов и ссылками на них
            List<FileData> fileDataList = new List<FileData>();
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                fileDataList.Add(new FileData { FileName = fileName, FilePath = filePath });
            }

            // Привязка списка объектов к гриду или другому контроллеру для отображения данных
            GridFile.DataSource = fileDataList;
        }

        private void CompressFolder(string sourceFolderPath, string destinationFolderPath)
        {
            string zipFileName = Path.Combine(destinationFolderPath, "archive.zip");
            ZipFile.CreateFromDirectory(sourceFolderPath, zipFileName);
        }

        private void ArchiveData(string sourceDirectory, string resultSubdirectory)
        {
            string resultFolderPath = Path.Combine("ParsingData", "Result", resultSubdirectory);
            if (Directory.Exists(resultFolderPath))
            {
                Directory.Delete(resultFolderPath, true); // Удалить папку и её содержимое, если она уже существует
            }
            Directory.CreateDirectory(resultFolderPath);
            CompressFolder(sourceDirectory, resultFolderPath);
        }

        private void JsonAll_Click(object sender, EventArgs e)
        {
            var path = Path.Combine("ParsingData", "JSON");
            ArchiveData(path, "JSON");
            MessageBox.Show($"JSON archive path - {path}");
        }

        private void XmlAll_Click(object sender, EventArgs e)
        {
            var path = Path.Combine("ParsingData", "XML");
            ArchiveData(path, "XML");
            MessageBox.Show($"XML archive path - {path}");
        }

        private void CsvAll_Click(object sender, EventArgs e)
        {
            var path = Path.Combine("ParsingData", "CSV");
            ArchiveData(path, "CSV");
            MessageBox.Show($"CSV archive path - {path}");
        }

        private void ExecelAll_Click(object sender, EventArgs e)
        {
            var path = Path.Combine("ParsingData", "Excel");
            ArchiveData(path, "Excel");
            MessageBox.Show($"Excel archive path - {path}");
        }
    }
}