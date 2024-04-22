using Core.Interface;
using Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Parser
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var serviceProvider = new ServiceCollection()
                .AddScoped<IWriteToFile, WriteToFile>() // Регистрируем интерфейс и его реализацию
                .AddScoped<IParserService, ParserService>() // Регистрируем интерфейс и его реализацию
                .BuildServiceProvider();

            var parserService = serviceProvider.GetService<IParserService>();
            var writeToFile = serviceProvider.GetService<IWriteToFile>();

            Application.Run(new Form1(parserService, writeToFile));

        }
    }
}