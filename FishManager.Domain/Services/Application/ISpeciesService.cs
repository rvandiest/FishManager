using System;
using System.Collections.Generic;
using FishManager.Domain.Entities;
using FishManager.Domain.Services.Dto;

namespace FishManager.Domain.Services.Application
{
    public interface ISpeciesService
    {
        SpeciesDto Create(SpeciesDto species);
        IEnumerable<SpeciesDto> Find(Func<Species, bool> predicate);
    }
}