using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Person
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; }

        [JsonPropertyName("idade")]
        public int Age { get; set; }

        [JsonPropertyName("areaDeAtuacao")]
        public string OccupationArea { get; set; }
    }
}
