using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonsterFusion_BE.Features.EventConfig.ChristmasEvent.Service;

namespace MonsterFusion_BE.Features.EventConfig.ChristmasEvent.Controller
{
    [Route("EventConfig/ChristmasEvent")]
    [ApiController]
    public class ChristmasEventController : ControllerBase
    {
        ChristmasEventService service;
        public ChristmasEventController(ChristmasEventService service)
        {
            this.service = service;
        }
        [HttpGet("")]
        [ResponseCache(Duration = 10)]
        public async Task<IActionResult> GetEventConfig()
        {
            var data = await service.GetEventConfigAsync();
            if(data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);    
            }
        }
    }
}
