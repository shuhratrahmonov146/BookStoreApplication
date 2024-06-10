using System.Text.Json.Serialization;

namespace BookStore.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Category
    {
        Fiction,
        NonFiction,
        Science,
        History,
        Biography,
        Fantasy,
        Mystery,
        Romance,
        Horror,
        SelfHelp
    }
}
