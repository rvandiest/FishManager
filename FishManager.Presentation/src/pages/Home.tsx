import React, { Component, ReactNode } from 'react';
import { CasualtyDataTable } from '../components/casualtydatatable'
import { AddCasualtyModal } from '../components/modals/addcasualtymodal'
import { Row, Col } from 'react-bootstrap';
import { CasualtyDto } from '../dto/casualty';
import { CasualtyService } from '../services/casualty.service';

type HomeState = {
  data: Array<CasualtyDto>
}

export default class Home extends Component<{}, HomeState> {

  constructor(props: {}) {
    super(props);

    this.state = {
      data: new Array<CasualtyDto>()
    }

  }

  async componentDidMount() {
    const untill: Date = new Date();
    const from: Date = new Date(untill.getFullYear(), untill.getMonth() - 1, untill.getDate());

    const casualties = await CasualtyService.findCasualtiesInTimeRange(from, untill);
    //console.log(casualties)
    this.setState({ data: casualties })

  }

  render(): ReactNode {
    return (
      <Row>
        Milguh
      </Row>
    )
  }
}
