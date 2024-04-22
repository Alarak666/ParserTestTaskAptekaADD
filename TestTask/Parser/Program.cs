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
                .AddScoped<IWriteToFile, WriteToFile>() // ������������ ��������� � ��� ����������
                .AddScoped<IParserService, ParserService>() // ������������ ��������� � ��� ����������
                .BuildServiceProvider();

            var parserService = serviceProvider.GetService<IParserService>();
            var writeToFile = serviceProvider.GetService<IWriteToFile>();

            Application.Run(new Form1(parserService, writeToFile));

        }
    }
}