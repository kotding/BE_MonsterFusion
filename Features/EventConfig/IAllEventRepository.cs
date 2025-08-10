using Microsoft.EntityFrameworkCore;
using MonsterFusion_BE.Features.EventConfig.AviatorEvent.Entity;
using MonsterFusion_BE.Features.EventConfig.ChristmasEvent.Entity;

namespace MonsterFusion_BE.Features.EventConfig
{
    public interface IAllEventRepository
    {
        public DbSet<AviatorEventData> aviatorEventDatas { get; set; }
        public DbSet<ChristmasEventData> christmasEventDatas { get; set; }
    }
}
