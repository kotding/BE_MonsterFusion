namespace MonsterFusion_BE.Features.EventConfig
{
    public class BaseEventDataResponse : IEventDataResponse
    {
        public int uid_event { get; set; }
        public DateTime time_start { get; set; }
        public DateTime time_expired { get; set; }
        public BaseEventDataResponse(BaseEventData data)
        {
            uid_event = data.uid_event;
            time_start = data.time_start;
            time_expired = data.time_expired;
        }

        public bool IsValid()
        {
            return DateTime.UtcNow < time_expired;
        }
    }
}
