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
    public class CasualtyController : ControllerBase
    {
        private readonly ILogger<CasualtyController> _logger;
        private readonly IFishManagerApplicationServiceCollection _services;

        public CasualtyController(ILogger<CasualtyController> logger, IFishManagerApplicationServiceCollection services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet]
        [Route("api/[controller]/range/{start}/{end}")]
        public JsonResult GetAllInRange(DateTime start, DateTime end)
        {
            var result = _services.CasualtyService
                .Find(cs => cs.Timestamp >= start && cs.Timestamp <= end)
                .ToList();
                
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("api/[controller]/report")]
        public JsonResult ReportCasualty([FromBody] CasualtyDto casualty)
        {
            if (ModelState.IsValid)
            {
                return new JsonResult(_services.CasualtyService.Report(casualty));
            }
            else
            {
                return new JsonResult(BadRequest());
            }

        }
    }
}
