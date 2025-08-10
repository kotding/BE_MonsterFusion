namespace MonsterFusion_BE.Features.EventConfig
{
    public interface IEventService
    {
        public Task<IEventDataResponse> GetEventConfigAsync();
    }
}
