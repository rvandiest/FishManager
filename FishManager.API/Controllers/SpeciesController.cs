using System;
using System.Collections.Generic;
using System.Linq;
using FishManager.Domain.Entities;
using FishManager.Domain.Services.Application;
using FishManager.Domain.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FishManager.API.Controllers
{
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ILogger<SpeciesController> _logger;
        private readonly IFishManagerApplicationServiceCollection _services;

        public SpeciesController(ILogger<SpeciesController> logger, IFishManagerApplicationServiceCollection services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public List<SpeciesDto> GetAllInRange(string genus, string species)
        {
            Func<Species, bool> genusPartialMatch = (sp) => genus == null ? true : sp.Genus.Contains(genus);
            Func<Species, bool> speciesPartialMatch = (sp) => species == null ? true : sp.Name.Contains(species);

            var result = _services.SpeciesService
                            .Find(cs => genusPartialMatch(cs) && speciesPartialMatch(cs))
                            .ToList();
            return result;
        }

    }
}