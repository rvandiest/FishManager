import React, { Component, ReactNode } from 'react';
import { Row, Col, Modal, Button, Form } from 'react-bootstrap';
import { FishManagerModal } from './fishmanagermodal';
import { CasualtyDto } from '../../dto/casualty';
import { SpeciesDto } from '../../dto/species';
import { CasualtyCauseDto } from '../../dto/casualtycause';
import { CasualtyService } from '../../services/casualty.service';
import { TankDto } from '../../dto/tankdto';
import RichSelectBox from '../richselectbox';
import { SuggestionService } from '../../services/suggestion.service'

type AddCasualtyModalState = {
    tankSuggestions: Array<String>
    speciesSuggestions: Array<String>
    genusSuggestions: Array<String>
    causeCategorySuggestions: Array<String>
    causeSuggestions: Array<String>
    visible: boolean
    entry: CasualtyDto
}

export class AddCasualtyModal extends Component<{}, AddCasualtyModalState> {

    constructor(props: {}) {
        super(props)
        this.state = {
            visible: false,
            tankSuggestions: new Array<String>(),
            speciesSuggestions: new Array<String>(),
            genusSuggestions: new Array<String>(),
            causeCategorySuggestions: new Array<String>(),
            causeSuggestions: new Array<String>(),
            entry: new CasualtyDto()
        }
    }

    private async onSave() {
        console.log(this.state)
        var result = await CasualtyService.reportCasualty(this.state.entry)
    }

    async componentDidMount() {
        const tankSuggestions = await SuggestionService.TankSuggestions();
        const speciesSuggestions = await SuggestionService.SpeciesSuggestions();
        const genusSuggestions = await SuggestionService.GenusSuggestions();
        const causeCategorySuggestions = await SuggestionService.CasualtyCauseCategorySuggestions();
        const causeSuggestions = await SuggestionService.CasualtyCauseSuggestions();

        this.setState({
            ...this.state,
            tankSuggestions: tankSuggestions,
            speciesSuggestions: speciesSuggestions,
            genusSuggestions: genusSuggestions,
            causeCategorySuggestions: causeCategorySuggestions,
            causeSuggestions: causeSuggestions
        })
    }

    render(): ReactNode {
        return (
            <>
                <FishManagerModal
                    title={"Report casualty"}
                    onSave={() => this.onSave()} onClose={() => this.setState({ visible: false })} visible={this.state.visible}>
                    <Form>
                        <RichSelectBox
                            id={"tankSelect"}
                            title={"Tank"}
                            options={this.state.tankSuggestions}
                            onSelect={(selection: string) => {
                                this.state.entry.tank.name = selection;
                            }}
                        />
                        <RichSelectBox
                            id={"genusSelect"}
                            title={"Genus"}
                            options={this.state.genusSuggestions}
                            onSelect={(selection: string) => {
                                this.state.entry.species.genus = selection;
                            }}
                        />
                        <RichSelectBox
                            id={"speciesSelect"}
                            title={"Species"}
                            options={this.state.speciesSuggestions}
                            onSelect={(selection: string) => {
                                this.state.entry.species.name = selection;
                            }}
                        />
                        <RichSelectBox
                            id={"causeCategorySelect"}
                            title={"Cause category"}
                            options={this.state.causeCategorySuggestions}
                            onSelect={(selection: string) => {
                                this.state.entry.casualtyCause.category = selection;
                            }}
                        />
                        <RichSelectBox
                            id={"causeSpecificationSelect"}
                            title={"Cause specification"}
                            options={this.state.causeSuggestions}
                            onSelect={(selection: string) => {
                                this.state.entry.casualtyCause.name = selection;
                            }}
                        />
                        <Form.Group>
                            <Form.Label>Amount</Form.Label>
                            <Form.Control
                                type="number"
                                min={1}
                                max={100}
                                onChange={(event) => {
                                    this.state.entry.count = +event.target.value
                                    this.setState(this.state)
                                }} />
                        </Form.Group>
                    </Form>
                </FishManagerModal>
                <Button className={"btn-sm float-right"} variant="primary" onClick={() => { this.setState({ visible: true }) }}>
                    +
                </Button>
            </>
        )
    }
}
