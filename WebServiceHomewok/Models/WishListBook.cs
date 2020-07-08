namespace WebServiceHomewok.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class wishListBook
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }
    }

    public partial class wishListBook
    {
        public static List<wishListBook> FromJson(string json) => JsonConvert.DeserializeObject<List<wishListBook>>(json, WebServiceHomewok.Models.Converter.Settings);
    }
}
