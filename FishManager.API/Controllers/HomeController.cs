using FishManager.Domain.Services.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FishManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFishManagerApplicationServiceCollection _services;

        public HomeController(ILogger<HomeController> logger, IFishManagerApplicationServiceCollection services)
        {
            _logger = logger;
            _services = services;
        }

    }
}
