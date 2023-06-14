using ProjectFatec.WebApi.Extensions;
using System;
using System.Text.Json.Serialization;

namespace ProjectFatec.WebApi.Models.Response.ViewModels
{
    public class RequestDetailsViewModel : RequestViewModel
    {
        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan StartTime { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime RejectionDate { get; set; }
        public double PriceTime {  get; set; }
    }
}
