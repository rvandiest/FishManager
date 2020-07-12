using System.Collections.Generic;
using System.Linq;
using FishManager.Domain.Repositories;

namespace FishManager.Domain.Services.Application
{
    public class SuggestionService : ISuggestionService
    {
        private IFishManagerRepository _repo;
        public SuggestionService(IFishManagerRepository repo)
        {
            _repo = repo;
        }

        public IList<string> FindCasualtyCauseCategorySuggestions()
        {
            return _repo.CasualtyCauses
                .FindAll((cc) => true, (cc) => cc.Category)
                .ToList();
        }

        public IList<string> FindCasualtyCauseSuggestions(string category = null)
        {
            return _repo.CasualtyCauses
                .FindAll((cc) => category == null ? true : cc.Category.Contains(category), (cc) => cc.Name)
                .ToList();
        }

        public IList<string> FindGenusSuggestions()
        {
            return _repo.Species
                .FindAll((sp) => true, (sp) => sp.Genus)
                .ToList();
        }

        public IList<string> FindSpeciesSuggestions(string genus = null)
        {
            return _repo.Species
                .FindAll((sp) => genus == null ? true : sp.Genus.Contains(genus), (sp) => sp.Name)
                .ToList();
        }

        public IList<string> FindTankSuggestions()
        {
            return _repo.Tanks
                .FindAll((tk) => true, (tk) => tk.Name)
                .ToList();
        }
    }
}