namespace WebServiceHomewok.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Book
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("publicationDate")]
        public DateTimeOffset PublicationDate { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public partial class Book
    {
        public static List<Book> FromJson(string json) => JsonConvert.DeserializeObject<List<Book>>(json, WebServiceHomewok.Models.Converter.Settings);
        public static Book FromJsonBook(string json) => JsonConvert.DeserializeObject<Book>(json, WebServiceHomewok.Models.Converter.Settings);
    }

}