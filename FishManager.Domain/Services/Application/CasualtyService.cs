using System;
using System.Collections.Generic;
using System.Linq;
using FishManager.Domain.Entities;
using FishManager.Domain.Repositories;
using FishManager.Domain.Services.Dto;
using FishManager.Domain.Services.Miscelleanous;

namespace FishManager.Domain.Services.Application
{
    public class CasualtyService : ICasualtyService
    {
        private IFishManagerRepository _repo;
        private IMapper _mapper;
        public CasualtyService(IFishManagerRepository repo)
        {
            _repo = repo;
            _mapper = DefaultMapper.GetInstance();
        }

        public IEnumerable<CasualtyDto> Find(Func<Casualty, bool> predicate)
        {
            var results = _repo.Casualties.FindAll<Casualty>(predicate);
            var mappedResults = _mapper.Map<List<CasualtyDto>>(results);
            return mappedResults;
        }

        public CasualtyDto Report(CasualtyDto casualtydto)
        {
            var casualty = _mapper.Map<Casualty>(casualtydto);

            casualty.Timestamp = DateTime.Now;

            casualty.CasualtyCause = _repo.CasualtyCauses.FindOneOrCreate<CasualtyCause>(
                (cs) => { return casualty.CasualtyCause.Name.Equals(cs.Name) && casualty.CasualtyCause.Category.Equals(cs.Category); },
                new CasualtyCause
                {
                    Name = casualty.CasualtyCause.Name,
                    Category = casualty.CasualtyCause.Category
                }
            );

            casualty.Species = _repo.Species.FindOneOrCreate<Species>(
                (sp) => { return casualty.Species.Name.Equals(sp.Name) && casualty.Species.Genus.Equals(sp.Genus); },
                new Species
                {
                    Name = casualty.Species.Name,
                    Genus = casualty.Species.Genus
                }
            );

            casualty.Tank = _repo.Tanks.FindOneOrCreate<Tank>(
                (sp) => { return casualty.Tank.Name.Equals(sp.Name); },
                new Tank
                {
                    Name = casualty.Tank.Name,
                }
            );

            var insertionResult = _repo.Casualties.InsertOne<Casualty>(casualty);

            return _mapper.Map<CasualtyDto>(insertionResult);
        }
    }
}