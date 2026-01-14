using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class TrackMobileLocation
    {
        public string? DeviceId { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public int Id { get; set; }
    }
}
