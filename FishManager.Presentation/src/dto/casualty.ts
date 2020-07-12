import { CasualtyCauseDto } from "./casualtycause"
import { SpeciesDto } from './species'
import { TankDto } from './tankdto'

export class CasualtyDto {
    constructor(){
        this.species = new SpeciesDto();
        this.tank = new TankDto();
        this.casualtyCause = new CasualtyCauseDto();
    }
    
    public species: SpeciesDto
    public tank: TankDto
    public count: number
    public casualtyCause: CasualtyCauseDto
    public timestamp: Date
}