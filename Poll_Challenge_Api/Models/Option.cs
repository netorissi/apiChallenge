using System.Collections.Generic;
using Newtonsoft.Json;

namespace Poll_Challenge_Api.Models
{
    public class Option
    {
        [JsonProperty("option_id")]
        public int? OptionId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("poll_id")]
        public int? PollId { get; set; }

        [JsonProperty("poll")]
        public virtual Poll Poll { get; set; }
    }
}