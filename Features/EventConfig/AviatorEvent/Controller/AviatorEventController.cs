using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using MonsterFusion_BE.Features.EventConfig.AviatorEvent.Service;
using Newtonsoft.Json;

namespace MonsterFusion_BE.Features.EventConfig.AviatorEvent.Controller
{
    [Route("EventConfig/AviatorEvent")]
    [ApiController]
    public class AviatorEventController : ControllerBase
    {
        private readonly AviatorEventService aviatorEventService;
        public AviatorEventController(AviatorEventService aviatorEventService)
        {
            this.aviatorEventService = aviatorEventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventConfig()
        {
            var data = await aviatorEventService.GetEventConfigAsync();
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
