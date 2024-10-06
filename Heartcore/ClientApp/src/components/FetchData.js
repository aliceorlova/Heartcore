import React, { Component } from 'react';
import axios from 'axios';
import PersonCard from './PersonCard'; 
import { Card, Button, Container, Row, Col, Modal } from 'react-bootstrap';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
      this.state = {
          people: [],
          show: false, // State to manage modal visibility
          loading: false,
          selectedPerson: null, // State to store the selected person
      };
  }

    handleClose = () => {
        this.setState({ show: false });
    };

    handleShow = (item) => {
        this.setState({ show: true, selectedPerson: item });
    };

    handleLoadData = () => {
        this.fetchData(); // Fetch data when button is clicked
    };

    render() {

        const { people, show, loading, selectedPerson } = this.state;

        return (
            <Container>

                <Button variant="primary" onClick={this.handleLoadData} className="mb-3">
                    Load Data To Umbraco and Display
                </Button>
                {loading && <div>Loading...</div>}
            <Row>
                {people.map(item => (
                    <Col key={item.id} xs={12} sm={6} md={3}>
                        <PersonCard item={item} handleShow={this.handleShow} /> 
                    </Col>
                ))}
            </Row>
            <Modal show={show} onHide={this.handleClose}>
                <Modal.Header closeButton>
                        <Modal.Title>{selectedPerson?.name}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                        <img src={selectedPerson?.image} alt={selectedPerson?.name} style={{ width: '100%', height: 'auto' }} />
                        <p><strong>Birthday:</strong> {selectedPerson?.birthday}</p>
                        <p><strong>Country:</strong> {selectedPerson?.country}</p>
                    <p><strong>Shows:</strong></p>
                    <ul>
                            {selectedPerson?.shows.map((show, index) => (
                            <li key={index}>{show.name}</li>
                        ))}
                    </ul>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={this.handleClose}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
    </Container>
    );
  } 

    fetchData = async () => {
        this.setState({ loading: true })
        const response = await fetch('people');
        const data = await response.json();
        this.setState({ people:data, loading: false });
    }
}
