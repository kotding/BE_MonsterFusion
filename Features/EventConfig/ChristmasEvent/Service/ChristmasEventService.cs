
using Microsoft.Extensions.Caching.Memory;

namespace MonsterFusion_BE.Features.EventConfig.ChristmasEvent.Service
{
    public class ChristmasEventService : BaseEventService
    {
        public ChristmasEventService(IMemoryCache cache, IAllEventRepository allEventRepository) : base(cache, allEventRepository) { }

        public override Task<IEventDataResponse> GetEventConfigAsync()
        {
            if(cache.TryGetValue<BaseEventDataResponse>("ChristmasEventData", out var cacheData) && cacheData != null && cacheData.IsValid())
            {
                Console.WriteLine("Christmas event data from query");
                return Task.FromResult<IEventDataResponse>(cacheData);
            }
            var data = allEventRepository.christmasEventDatas.First();
            if(data == null)
            {
                return Task.FromResult<IEventDataResponse>(null);
            }
            else
            {
                Console.WriteLine("Christmas event data from cache");
                var responseData = new BaseEventDataResponse(data);
                cache.Set<BaseEventDataResponse>("ChristmasEventData", responseData);
                return Task.FromResult<IEventDataResponse>(responseData);
            }
        }
    }
}
