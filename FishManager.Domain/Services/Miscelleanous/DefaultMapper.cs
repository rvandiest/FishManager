using System.Collections.Generic;
using AutoMapper;
using FishManager.Domain.Entities;
using FishManager.Domain.Services.Dto;

namespace FishManager.Domain.Services.Miscelleanous
{
    public class DefaultMapper : IMapper
    {
        private AutoMapper.IMapper _mapper;
        private static DefaultMapper instance;
        private DefaultMapper(MapperConfiguration config)
        {
            _mapper = config.CreateMapper();
        }

        public static DefaultMapper GetInstance()
        {
            if (instance == null)
            {
                instance = new DefaultMapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Species, SpeciesDto>();
                    cfg.CreateMap<Casualty, CasualtyDto>();
                    cfg.CreateMap<CasualtyCause, CasualtyCauseDto>();
                    cfg.CreateMap<SpeciesDto, Species>();
                    cfg.CreateMap<CasualtyDto, Casualty>();
                    cfg.CreateMap<CasualtyCauseDto, CasualtyCause>();
                    cfg.CreateMap<Tank, TankDto>();
                    cfg.CreateMap<TankDto, Tank>();
                }));
            }
            return instance;
        }

        public T Map<T>(object source)
        {
            return _mapper.Map<T>(source);
        }
    }
}