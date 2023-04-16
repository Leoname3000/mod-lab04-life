using System.IO;
using System.Text.Json;

namespace cli_life
{
    public static class JsonReader
    {
        public static GameOfLife ReadSettings(string pathToSettings)
        {
            string rawContents = File.ReadAllText(@pathToSettings);
            GameOfLife contents = JsonSerializer.Deserialize<GameOfLife>(rawContents);
            return contents;
        }

        public static Pattern ReadPattern(string pathToPattern)
        {
            string rawContents = File.ReadAllText(@pathToPattern);
            Pattern contents = JsonSerializer.Deserialize<Pattern>(rawContents);
            return contents;
        }
    }
}