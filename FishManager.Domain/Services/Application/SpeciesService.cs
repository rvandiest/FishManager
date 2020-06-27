using System;
using System.Collections.Generic;
using System.Linq;
using FishManager.Domain.Entities;
using FishManager.Domain.Repositories;
using FishManager.Domain.Services.Dto;
using FishManager.Domain.Services.Miscelleanous;

namespace FishManager.Domain.Services.Application
{
    public class SpeciesService : ISpeciesService
    {
        private IFishManagerRepository _repo;
        private IMapper _mapper;
        public SpeciesService(IFishManagerRepository repo)
        {
            _repo = repo;
            _mapper = DefaultMapper.GetInstance();
        }
        public SpeciesDto Create(SpeciesDto value)
        {
            var result = _repo.Species.FindOneOrCreate<Species>(
                (sp) => { return sp.Genus.Equals(value.Genus) && sp.Name.Equals(value.Name); },
                _mapper.Map<Species>(value)
            );

            var mappedResult = _mapper.Map<SpeciesDto>(value);

            return mappedResult;
        }

        public IEnumerable<SpeciesDto> Find(Func<Species, bool> predicate)
        {
            var result = _repo.Species
                            .FindAll<Species>(predicate)
                            .ToList();

            var mappedResult = _mapper.Map<List<SpeciesDto>>(result);
            return mappedResult;
        }
    }
}