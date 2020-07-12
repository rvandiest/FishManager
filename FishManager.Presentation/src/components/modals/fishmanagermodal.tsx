import React, { Component, ReactNode } from 'react';
import { Modal, Button } from 'react-bootstrap';

type FishManagerModalProps = {
    title: string
    onSave: Function
    onClose: Function
    visible: boolean
}

export class FishManagerModal extends Component<FishManagerModalProps, {}> {

    constructor(props: FishManagerModalProps) {
        super(props)
    }

    render(): ReactNode {
        return (
            <Modal show={this.props.visible} onHide={() => this.props.onClose()}>
                <Modal.Header closeButton>
                    <Modal.Title>{this.props.title}</Modal.Title>
                </Modal.Header>
                <Modal.Body>{this.props.children}</Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={() => this.props.onClose()}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={() => this.props.onSave()}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        )
    }
}
