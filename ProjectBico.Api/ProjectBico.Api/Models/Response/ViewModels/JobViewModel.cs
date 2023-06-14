using ProjectFatec.WebApi.Extensions;
using System;
using System.Text.Json.Serialization;

namespace ProjectFatec.WebApi.Models.Response.ViewModels
{
    public class JobViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan StartTime { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan EndTime { get; set; }

        public double PriceTime { get; set; }

    }
}
