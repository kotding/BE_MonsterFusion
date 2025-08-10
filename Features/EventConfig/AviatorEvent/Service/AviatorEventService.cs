using Microsoft.Extensions.Caching.Memory;
using MonsterFusion_BE.Features.EventConfig.AviatorEvent.Entity;

namespace MonsterFusion_BE.Features.EventConfig.AviatorEvent.Service
{
    public class AviatorEventService : BaseEventService
    {
        public AviatorEventService(IMemoryCache cache, IAllEventRepository allEventRepository) : base(cache, allEventRepository) { }

        public override Task<IEventDataResponse> GetEventConfigAsync()
        {
            if(cache.TryGetValue<BaseEventDataResponse>("AviatorEventData", out BaseEventDataResponse? dataCache) && dataCache != null && dataCache.IsValid())
            {
                Console.WriteLine("Aviator event data from cache");
                return Task.FromResult<IEventDataResponse>(dataCache);
            }
            AviatorEventData data = allEventRepository.aviatorEventDatas.First();
            if(data == null)
            {
                Console.WriteLine("Aviator event data not found");
                return Task.FromResult<IEventDataResponse>(null);
            }
            else
            {
                Console.WriteLine("Aviator event data from query");
                var dataResponse = new BaseEventDataResponse(data);
                Console.WriteLine(dataResponse.time_expired);
                cache.Set<BaseEventDataResponse>("AviatorEventData", dataResponse);
                return Task.FromResult<IEventDataResponse>(dataResponse);
            }
        }
    }
}
