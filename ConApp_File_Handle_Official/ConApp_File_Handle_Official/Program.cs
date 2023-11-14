using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp_File_Handle_Official
{
    internal class Program
    {
        static string defaultDirectory = "D:\\Mphasis-B2\\Day-7\\ConApp_File_Handle_Official";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Create File");
                Console.WriteLine("2. Read File");
                Console.WriteLine("3. Append to File");
                Console.WriteLine("4. Delete File");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter file name: ");
                        string createFileName = Console.ReadLine();
                        string createFilePath = Path.Combine(defaultDirectory, createFileName);
                        Console.Write("Enter content: ");
                        string createFileContent = Console.ReadLine();
                        CreateFile(createFilePath, createFileContent);
                        break;

                    case "2":
                        Console.Write("Enter file name to read: ");
                        string readFileName = Console.ReadLine();
                        string readFilePath = Path.Combine(defaultDirectory, readFileName);
                        ReadFile(readFilePath);
                        break;

                    case "3":
                        Console.Write("Enter file name to append: ");
                        string appendFileName = Console.ReadLine();
                        string appendFilePath = Path.Combine(defaultDirectory, appendFileName);
                        Console.Write("Enter content to append: ");
                        string appendContent = Console.ReadLine();
                        AppendToFile(appendFilePath, appendContent);
                        break;

                    case "4":
                        Console.Write("Enter file name to delete: ");
                        string deleteFileName = Console.ReadLine();
                        string deleteFilePath = Path.Combine(defaultDirectory, deleteFileName);
                        DeleteFile(deleteFilePath);
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
        static void CreateFile(string fileName, string content)
        {
            try
            {
                // Create a new text file and write the content to it
                File.WriteAllText(Path.Combine(defaultDirectory, fileName), content);
                Console.WriteLine($"File '{fileName}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
            }
        }

        static void ReadFile(string fileName)
        {
            try
            {
                // Read the content of the specified text file
                string content = File.ReadAllText(Path.Combine(defaultDirectory, fileName));
                Console.WriteLine($"Content of file '{fileName}':\n{content}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        static void AppendToFile(string fileName, string content)
        {
            try
            {
                // Append the content to the specified text file
                File.AppendAllText(Path.Combine(defaultDirectory, fileName), $"\n{content}");
                Console.WriteLine($"Content appended to file '{fileName}' successfully.");

                // Explicitly close the file
                using (FileStream fs = new FileStream(Path.Combine(defaultDirectory, fileName), FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    fs.Close();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to file: {ex.Message}");
            }
        }

        static void DeleteFile(string fileName)
        {
            try
            {
                // Delete the specified text file
                File.Delete(Path.Combine(defaultDirectory, fileName));
                Console.WriteLine($"File '{fileName}' deleted successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
    }
}
