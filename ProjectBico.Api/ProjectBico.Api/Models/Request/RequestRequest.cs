using ProjectFatec.WebApi.Extensions;
using System;
using System.Text.Json.Serialization;

namespace ProjectFatec.WebApi.Models.Request
{
    public class RequestRequest
    {
        public virtual long ContractingUserId { get; set; }
        public virtual long JobId { get; set; }
        public virtual long ProviderId { get; set; }
        public string Description { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan StartTime { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}