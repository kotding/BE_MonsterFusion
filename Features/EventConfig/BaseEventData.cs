using System.ComponentModel.DataAnnotations;

namespace MonsterFusion_BE.Features.EventConfig
{
    public class BaseEventData : IEventData
    {
        [Key] public int uid_event { get; set; }
        public DateTime time_start { get; set; }
        public DateTime time_expired { get; set; }
    }
}
