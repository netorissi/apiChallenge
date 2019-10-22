using System.Collections.Generic;
using Newtonsoft.Json;

namespace Poll_Challenge_Api.Models
{
    public class Poll
    {
        [JsonProperty("poll_id")]
        public int? PollId { get; set; }

        [JsonProperty("poll_description")]
        public string PollDescription { get; set; }

        [JsonProperty("views")]
        public int? Views { get; set; } = 0;

        [JsonProperty("options")]
        public virtual ICollection<Option> Options { get; set; }
    }
}
