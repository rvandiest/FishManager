import React, { Component, ReactNode } from 'react';
import DataTable, { createTheme, IDataTableProps } from 'react-data-table-component';
import { CasualtyDto } from '../dto/casualty'
import { CasualtyService } from '../services/casualty.service'
import { TankDto } from '../dto/tankdto';

type Column = {
    name: string,
    selector: string | Function,
    sortable: boolean,
    right?: boolean
}

type CasualtyDataTableProps = {
    data: Array<CasualtyDto>
}

export class CasualtyDataTable extends Component<CasualtyDataTableProps, {}> {
    private columns: any

    constructor(props: CasualtyDataTableProps) {
        super(props);

        this.state = { data: new Array<CasualtyDto>() }

        this.columns = [
            {
                name: 'Date',
                sortable: true,
                selector: (elem: CasualtyDto) => new Date(elem.timestamp).toDateString()
            },
            {
                name: 'Tank',
                selector: (elem: CasualtyDto) => elem.tank?.name,
                sortable: true,
            },
            {
                name: 'Genus',
                selector: (elem: CasualtyDto) => elem.species?.genus,
                sortable: true,
            },
            {
                name: 'Species',
                selector: (elem: CasualtyDto) => elem.species?.name,
                sortable: true,
            },
            {
                name: 'Cause',
                selector: (elem: CasualtyDto) => elem.casualtyCause?.name,
                sortable: true,
            },
            {
                name: 'Cause category',
                selector: (elem: CasualtyDto) => elem.casualtyCause?.category,
                sortable: true,
            },
        ];
    }

    render(): ReactNode {
        return <DataTable
            columns={this.columns}
            data={this.props.data}
            noHeader={true}
        />
    }
}
