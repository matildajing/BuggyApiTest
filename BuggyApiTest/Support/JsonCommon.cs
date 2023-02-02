using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BuggyApiTest.Support
{
    public class JsonCommon
    {
        public JsonCommon()
        {
        }

        public static JObject GetJsonFromDataFile(string jsonFile)
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string fileFolder = Path.Combine(RunningPath, "TestData");
            string filePath = System.IO.Path.Combine(fileFolder, jsonFile);

            return JObject.Parse(File.ReadAllText(filePath));

        }

        public static string getString(string jsonString, string key)
        {
            JObject jObject = JObject.Parse(jsonString);
            return jObject.GetValue(key)?.ToString();
        }
    }
}
