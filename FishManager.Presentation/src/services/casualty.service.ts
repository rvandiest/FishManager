import { CasualtyDto } from '../dto/casualty'
import { HttpService } from './httpservice.service'

export class CasualtyService {
    public static async findCasualtiesInTimeRange(start: Date, end: Date): Promise<Array<CasualtyDto>> {
        return await HttpService.get<Array<CasualtyDto>>(`/api/casualty/range/${start.toISOString()}/${end.toISOString()}`);
    }

    public static async reportCasualty(casualty: CasualtyDto) {
        return HttpService.post<CasualtyDto>('/api/casualty/report', casualty)
    }
}