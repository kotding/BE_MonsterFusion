
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
                await Task.Delay(20 * 1000 , stoppingToken);
                using(var scope = scropeFactory.CreateScope())
                {
                    var allEventRepository = scope.ServiceProvider.GetService<IAllEventRepository>();
                    if(allEventRepository != null)
                    {
                        var data = allEventRepository.aviatorEventDatas.FirstOrDefault();
                        if (data != null)
                        {
                            data.time_expired += TimeSpan.FromSeconds(60);
                            await allEventRepository.SaveChangesAsync(stoppingToken);
                            Console.WriteLine("Reset time expired aviator");
                        }
                    }
                }

            }
        }
    }
}
