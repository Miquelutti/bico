using ProjectFatec.WebApi.Extensions;
using System;
using System.Text.Json.Serialization;

namespace ProjectFatec.WebApi.Models.Request
{
    public class JobRequest
    {
        public virtual long ProviderId { get; set; }
        public virtual long JobCategoryId { get; set; }
        public string Description { get; set; }
        
        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan StartTime { get; set; }
        
        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan? BreakTime { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan? ReturnTime { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan EndTime { get; set; }

        public double PriceTime { get; set; }
    }
}


