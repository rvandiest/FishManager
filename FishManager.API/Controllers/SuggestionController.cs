using System.Collections.Generic;
using FishManager.Domain.Services.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FishManager.API.Controllers
{
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly ILogger<SuggestionController> _logger;
        private readonly IFishManagerApplicationServiceCollection _services;

        public SuggestionController(ILogger<SuggestionController> logger, IFishManagerApplicationServiceCollection services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet]
        [Route("api/[controller]/tank")]
        public IList<string> GetTankSuggestions()
        {
            return _services.SuggestionService.FindTankSuggestions();
        }

        [HttpGet]
        [Route("api/[controller]/genus")]
        public IList<string> GetGenusSuggestions()
        {
            return _services.SuggestionService.FindGenusSuggestions();
        }

        [HttpGet]
        [Route("api/[controller]/species/{category?}")]
        public IList<string> GetSpeciesSuggestions(string category)
        {
            return _services.SuggestionService.FindSpeciesSuggestions(category);
        }

        [HttpGet]
        [Route("api/[controller]/casualtycause/{genus?}")]
        public IList<string> GetCasualtyCauseSuggestions(string genus)
        {
            return _services.SuggestionService.FindCasualtyCauseSuggestions(genus);
        }

        [HttpGet]
        [Route("api/[controller]/casualtycausecategory")]
        public IList<string> GetCasualtyCauseCategorySuggestions()
        {
            return _services.SuggestionService.FindCasualtyCauseCategorySuggestions();
        }

    }
}