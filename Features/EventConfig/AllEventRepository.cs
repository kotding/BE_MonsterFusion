using Microsoft.EntityFrameworkCore;
using MonsterFusion_BE.Features.EventConfig.AviatorEvent.Entity;
using MonsterFusion_BE.Features.EventConfig.ChristmasEvent.Entity;

namespace MonsterFusion_BE.Features.EventConfig
{
    public class AllEventRepository : DbContext , IAllEventRepository
    {
        public AllEventRepository(DbContextOptions<AllEventRepository> options) : base(options) { }
        public DbSet<AviatorEventData> aviatorEventDatas { get; set; }
        public DbSet<ChristmasEventData> christmasEventDatas { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            base.SaveChangesAsync();
        }
    }
}
