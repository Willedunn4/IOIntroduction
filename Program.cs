using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Specify the directory containing the text files
        string directoryPath = @"C:\IO Documents";

        // Define the specific file names
        string[] fileNames = { "test1.txt", "test2.txt" };

        foreach (string fileName in fileNames)
        {
            string filePath = Path.Combine(directoryPath, fileName);

            Console.WriteLine($"File: {fileName}");

            try
            {
                // Read the content of the file with UTF-8 encoding (or specify the correct encoding)
                string fileContent = File.ReadAllText(filePath, Encoding.UTF8);

                // Create a dictionary to store character counts (excluding spaces)
                Dictionary<char, int> charCount = new Dictionary<char, int>();

                // Loop through each character in the file
                foreach (char c in fileContent)
                {
                    if (c != ' ')
                    {
                        // If the character is not a space, update the count in the dictionary
                        if (charCount.ContainsKey(c))
                        {
                            charCount[c]++;
                        }
                        else
                        {
                            charCount[c] = 1;
                        }
                    }
                }

                // Output the character counts for the current file
                foreach (var kvp in charCount.OrderBy(k => k.Key))
                {
                    Console.WriteLine($"{kvp.Key} {kvp.Value}");
                }

                Console.WriteLine(); // Add a blank line between files
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file {fileName}: {ex.Message}");
            }
        }

        Console.WriteLine("All files processed.");
    }
}

