using ConsoleApp.models;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp.handlers
{
    internal static class TranslateHandler
    {
        /// <summary>
        /// Load json from the provided region
        /// </summary>
        /// <param name="region"></param>
        /// <returns>Translate</returns>
        public static Translate LoadJson(string region)
        {
            //Path to the json files with the region provided in function
            var r = File.OpenText(Path.Combine(".", "translations", "translation" + region + ".json"));
            var json = r.ReadToEnd();
            var translate = JsonConvert.DeserializeObject<Translate>(json);

            return translate;

        }
    }
}
