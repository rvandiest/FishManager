using System;
using System.Collections.Generic;
using FishManager.Domain.Entities;
using FishManager.Domain.Services.Dto;

namespace FishManager.Domain.Services.Application
{
    public interface ICasualtyService
    {
        CasualtyDto Report(CasualtyDto casualty);
        IEnumerable<CasualtyDto> Find(Func<Casualty, bool> predicate);
    }
}