import React, { Component, ReactNode } from 'react';
import { Navbar, Nav, NavDropdown, Form, Button, FormControl, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export default class NavigationBar extends Component<{}, {}> {

    render(): ReactNode {
        return (
            <Row>
                <Navbar bg="light" className={"container"}>
                    <Navbar.Brand><Link to="/">FishManager</Link></Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="mr-auto">
                            <Nav.Link>
                                <Link to="/">Home</Link>
                            </Nav.Link>
                            <Nav.Link>
                                <Link to="/overview">Overview</Link>
                            </Nav.Link>
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
            </Row>
        );
    }
}
