using AutomationFramework.Configuration;
using Newtonsoft.Json;

namespace AutomationFramework.Utils
{
    public class JSONHelper
    {
        /// <summary>
        /// Deserializes a JSON file into an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">Relative path. E.g.: \\TestData\\somefile.json</param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string filePath)
        {
            try
            {
                string fullPath = ConfigReader.GetProjectDirectory(MyDirectory.AutomationFrameworkTest) + filePath;
                string jsonFile = File.ReadAllText(fullPath);
                T obj = JsonConvert.DeserializeObject<T>(jsonFile);
                return obj;
            }
            catch (Exception e)
            {
                Logger.Error("Failed to deserialize JSON from file: " + filePath);
                Logger.Debug(e.ToString());
                return default(T);
            }
        }
    }
}
