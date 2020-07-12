using System.Collections.Generic;

namespace FishManager.Domain.Services.Application
{
    public interface ISuggestionService
    {
        IList<string> FindTankSuggestions();
        IList<string> FindGenusSuggestions();
        IList<string> FindSpeciesSuggestions(string genus);
        IList<string> FindCasualtyCauseCategorySuggestions();
        IList<string> FindCasualtyCauseSuggestions(string category);
    }
}