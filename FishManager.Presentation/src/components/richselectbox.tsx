import React, { Component, ReactNode } from "react";
import { Form, InputGroup, FormControl, Button } from "react-bootstrap";
import { Typeahead } from "react-bootstrap-typeahead";

type RichSelectBoxProps = {
    id: string
    title: String
    options: Array<String>
    onSelect: Function
}

type RichSelectBoxState = {
    value: string
}

export default class RichSelectBox extends Component<RichSelectBoxProps, RichSelectBoxState> {

    private optionsWereSupplied: boolean

    constructor(props: RichSelectBoxProps) {
        super(props);
    }

    public render(): ReactNode {
        return (
            <Form.Group>
                <Form.Label>{this.props.title}</Form.Label>
                <Typeahead
                    id={this.props.id}
                    onChange={(selected) => {
                        this.props.onSelect(selected[0])
                    }}
                    onInputChange={(value) => { this.props.onSelect(value) }}
                    options={this.props.options}
                />
            </Form.Group>
        );
    }
}