using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON_Flattener
{
    public class JsonHandler
    {

        private readonly string _json;
        private readonly Dictionary<string, object> _jsonDictionary;
        private readonly JObject _jObject;

        public JsonHandler(string json)
        {
            _json = json;
            _jsonDictionary = new Dictionary<string, object>();
            _jObject = new JObject();
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
                Console.Error.WriteLine($"Exception \"{e.GetType().Name}\" has been thrown when opening a file. Incorrect input!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Error.WriteLine("Stack trace:");
                Console.Error.WriteLine(Environment.StackTrace);
                Console.ForegroundColor = ConsoleColor.Black;
                Environment.Exit(1);
            }

            return jsonToken;
        }
        
        /// <summary>
        /// Deserializes JSON file from JToken file to a dictionary.
        /// </summary>
        /// <exception cref="System.NullReferenceException"> improper casting.</exception>
        /// <param name="tokens">JToken file containing deserialized JSON data.</param>
        /// <param name="flattened">String representing what will be added in each recursive call
        /// to the name of the object.</param>
        private void JTokenToDictionary(JToken tokens, string flattened)
        {
            if (tokens.Type is JTokenType.Array)
            {
                foreach (var kid in tokens.Children())
                {
                    JTokenToDictionary(kid, flattened + ".");
                }
            }
            else if (tokens.Type is JTokenType.Object)
            {
                foreach (var jValue in tokens.Children<JProperty>())
                {
                    var temp = string.IsNullOrEmpty(flattened) ? "" : ".";
                    JTokenToDictionary(jValue.Value,  flattened + temp + jValue.Name);
                }
            }
            else
            {
                _jsonDictionary.Add(flattened, ((JValue)tokens).Value);
            }
        }

        /// <summary>
        /// Function used to flatten a JSON file.
        /// </summary>
        /// <returns>String containing a flattened JSON.</returns>
        public string DeserializeJson()
        {
            JToken jsonToken = DeserializeJsonToJToken(_json);
            JTokenToDictionary(jsonToken, "");
            
            foreach (var value in _jsonDictionary)
            {
                _jObject.Add(new JProperty(value.Key, value.Value));
            }

            return _jObject.ToString();
        }
    }
}