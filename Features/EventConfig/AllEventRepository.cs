using Microsoft.EntityFrameworkCore;
using MonsterFusion_BE.Features.EventConfig.AviatorEvent.Entity;
using MonsterFusion_BE.Features.EventConfig.ChristmasEvent.Entity;

namespace MonsterFusion_BE.Features.EventConfig
{
    public class AllEventRepository : DbContext, IAllEventRepository
    {
        public AllEventRepository(DbContextOptions<AllEventRepository> options) : base(options) { }
        public DbSet<AviatorEventData> aviatorEventDatas { get; set; }
        public DbSet<ChristmasEventData> christmasEventDatas { get; set; }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
