import { HttpService } from './httpservice.service'

export class SuggestionService {
    public static async TankSuggestions() {
        return await HttpService.get<Array<string>>('/api/suggestion/tank');
    }

    public static async GenusSuggestions() {
        return await HttpService.get<Array<string>>('/api/suggestion/genus');
    }

    public static async SpeciesSuggestions() {
        return await HttpService.get<Array<string>>('/api/suggestion/species');
    }

    public static async CasualtyCauseSuggestions() {
        return await HttpService.get<Array<string>>('/api/suggestion/casualtycause');
    }

    public static async CasualtyCauseCategorySuggestions() {
        return await HttpService.get<Array<string>>('/api/suggestion/casualtycausecategory');
    }
}