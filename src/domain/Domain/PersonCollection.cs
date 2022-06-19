using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class PersonCollection
    {
        [JsonPropertyName("pessoas")]
        public IEnumerable<Person> People { get; set; }
    }
}
