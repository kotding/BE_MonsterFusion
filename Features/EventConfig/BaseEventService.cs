using Microsoft.Extensions.Caching.Memory;

namespace MonsterFusion_BE.Features.EventConfig
{
    public abstract class BaseEventService : IEventService
    {
        protected IMemoryCache cache;
        protected IAllEventRepository allEventRepository;
        public BaseEventService(IMemoryCache cache, IAllEventRepository allEventRepository)
        {
            this.cache = cache;
            this.allEventRepository = allEventRepository;
        }

        public abstract Task<IEventDataResponse> GetEventConfigAsync();
    }
}
