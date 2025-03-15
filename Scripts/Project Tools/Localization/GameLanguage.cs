using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Project.Tools.LocalizationHelp
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GameLanguage
    {
        English = 0,
        Russian = 1,
    }
}
