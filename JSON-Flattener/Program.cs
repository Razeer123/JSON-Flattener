using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JSON_Flattener
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                DisplayInfo();
            }
            
            var inputJson = ReadFile(args[0]);
            var handler = new JsonHandler(inputJson);
            
            Console.WriteLine(handler.DeserializeJson());
        }
        
        /// <summary>
        /// Displays information whether given arguments are not correct.
        /// </summary>
        static void DisplayInfo()
        {
            Console.Error.WriteLine("Given arguments are not correct!");
            Console.Error.WriteLine("You have to provide exactly one argument which is a location of the JSON file. Try again...");
            Environment.Exit(1);
        }
        
        /// <summary>
        /// Reads a given file and saves the content to the string.
        /// </summary>
        /// <exception cref="FileNotFoundException"> file not found.</exception>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>String filled with content of the given file.</returns>
        static string ReadFile(string fileName)
        {
            var content = "";
            
            try
            {
                content = File.ReadAllText(fileName);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Exception \"{0}\" has been thrown when opening a file. Incorrect input!", e.GetType().Name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Error.WriteLine("Stack trace:");
                Console.Error.WriteLine(Environment.StackTrace);
                Console.ForegroundColor = ConsoleColor.Black;
                Environment.Exit(1);
            }

            return content;
        }
    }
}