import React, { Component, ReactNode } from 'react';
import { CasualtyDataTable } from '../components/casualtydatatable'
import { AddCasualtyModal } from '../components/modals/addcasualtymodal'
import { Row, Col } from 'react-bootstrap';
import { CasualtyDto } from '../dto/casualty';
import { CasualtyService } from '../services/casualty.service';

type OverviewState = {
  data: Array<CasualtyDto>
}

export default class Overview extends Component<{}, OverviewState> {

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
      <>
        <Row className={"mt-3"}>
          <Col xs={9} md={9} lg={9} xl={9}>
            <h5>Casualties in the last month</h5>
          </Col>
          <Col xs={3} md={3} lg={3} xl={3}>
            <AddCasualtyModal />
          </Col>

        </Row>
        <Row>
          <CasualtyDataTable
            data={this.state.data}
          />
        </Row>
      </>
    )
  }
}
