
namespace MonsterFusion_BE.Features.EventConfig.AviatorEvent.Service.BGService
{
    public class ResetAviatorService : BackgroundService
    {
        private IServiceScopeFactory scropeFactory;
        public ResetAviatorService(IServiceScopeFactory scropeFactory)
        {
            this.scropeFactory = scropeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(20 * 1000);
                using(var scrope = scropeFactory.CreateScope())
                {
                    var allEventRepository = scrope.ServiceProvider.GetService<IAllEventRepository>();
                    if(allEventRepository != null)
                    {
                        var data = allEventRepository.aviatorEventDatas.First();
                        if (data != null)
                        {
                            data.time_expired += TimeSpan.FromSeconds(60);
                            allEventRepository.SaveChangesAsync();
                            Console.WriteLine("Reset time expired aviator");
                        }
                    }
                }

            }
        }
    }
}
