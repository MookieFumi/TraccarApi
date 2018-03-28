using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraccarApi.Business.Entities
{
    [Table("events")]
    public class Event {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime ServerTime { get; set; }
        public int DeviceId { get; set; }
        public int? PositionId { get; set; }
        public int? GeofenceId { get; set; }
        public string Attributes { get; set; }
    }
}
