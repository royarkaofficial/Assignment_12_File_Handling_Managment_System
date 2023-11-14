using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12_File_Handling_Mngment_System
{
    internal class Program
    {
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
                        Console.Write("Enter file path: ");
                        string createFilePath = Console.ReadLine();
                        Console.Write("Enter content: ");
                        string createFileContent = Console.ReadLine();
                        CreateFile(createFilePath, createFileContent);
                        break;

                    case "2":
                        Console.Write("Enter file path to read: ");
                        string readFilePath = Console.ReadLine();
                        ReadFile(readFilePath);
                        break;

                    case "3":
                        Console.Write("Enter file path to append: ");
                        string appendFilePath = Console.ReadLine();
                        Console.Write("Enter content to append: ");
                        string appendContent = Console.ReadLine();
                        AppendToFile(appendFilePath, appendContent);
                        break;

                    case "4":
                        Console.Write("Enter file path to delete: ");
                        string deleteFilePath = Console.ReadLine();
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

        static void CreateFile(string filePath, string content)
        {
            try
            {
                // Create a new text file and write the content to it
                File.WriteAllText(filePath, content);
                Console.WriteLine($"File '{filePath}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
            }
        }

        static void ReadFile(string filePath)
        {
            try
            {
                // Read the content of the specified text file
                string content = File.ReadAllText(filePath);
                Console.WriteLine($"Content of file '{filePath}':\n{content}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filePath}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
        static void AppendToFile(string filePath, string content)
        {
            try
            {
                // Append the content to the specified text file
                File.AppendAllText(filePath, $"\n{content}");
                Console.WriteLine($"Content appended to file '{filePath}' successfully.");

                // Explicitly close the file
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    fs.Close();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filePath}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to file: {ex.Message}");
            }
        }

        static void DeleteFile(string filePath)
        {
            try
            {
                // Delete the specified text file
                File.Delete(filePath);
                Console.WriteLine($"File '{filePath}' deleted successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filePath}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
    }
}
