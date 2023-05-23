using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введiть шлях до каталогу: ");
        string directoryPath = Console.ReadLine(); // Вкажіть шлях до каталогу, для якого хочете підрахувати кількість файлів

        CountFilesInSubdirectories(directoryPath);

        Console.ReadLine();
    }

    static void CountFilesInSubdirectories(string directoryPath)
    {
        try
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            FileInfo[] files = directory.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                string subdirectory = file.DirectoryName;
                int fileCount = Directory.GetFiles(subdirectory, "*", SearchOption.AllDirectories).Length;
                Console.WriteLine($"Кiлькiсть файлiв у пiдкаталозi {subdirectory}: {fileCount}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при пiдрахунку файлiв: {ex.Message}");
        }
    }
}
