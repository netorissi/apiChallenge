using System.Collections.Generic;
using Newtonsoft.Json;

namespace Poll_Challenge_Api.Models
{
    public class Vote
    {
        [JsonProperty("vote_id")]
        public int? VoteId { get; set; }

        [JsonProperty("option_id")]
        public int? OptionId { get; set; }

        [JsonProperty("qty")]
        public int? Qty { get; set; } = 0;

        [JsonProperty("option")]
        public virtual Option Option { get; set; }
    }

    public class ResponseVote
    {
        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("votes")]
        public List<object> Votes { get; set; }
    }
}
