using Newtonsoft.Json;


namespace recruitmentmanagementsystem.CommonModel
{
    public class InterviewEmail
    {
        /* [JsonProperty("name")]
         public string Name { get; set; }*/

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("starttime")]
        public string StartTime { get; set; }

        [JsonProperty("endtime")]
        public string EndTime { get; set; }
    }
}

