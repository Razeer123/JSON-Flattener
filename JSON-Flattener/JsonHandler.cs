using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON_Flattener
{
    public class JsonHandler
    {

        private string _json;

        public JsonHandler(string json)
        {
            this._json = json;
        }

        /// <summary>
        /// Deserializes JSON file from string to a JToken file.
        /// </summary>
        /// <exception cref="JsonReaderException"> invalid JSON.</exception>
        /// <param name="json">String containing JSON file content.</param>
        /// <returns>JToken file containing deserialized JSON data.</returns>
        private JToken DeserializeJsonToJToken(string json)
        {
            JToken jsonToken = null;

            try
            {
                jsonToken = JToken.Parse(json);
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
            
            return jsonToken;
        }
    }
}