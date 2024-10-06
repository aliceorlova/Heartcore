import React from 'react';
import { Card, Button } from 'react-bootstrap';

const PersonCard = ({ item, handleShow }) => {
    const formattedBirthday = item.birthday ? new Date(item.birthday).toISOString().split('T')[0] : null;

    return (
        <Card style={{ width: '12rem' }} className="mb-4">
            <Card.Img variant="top" src={item.image} alt={item.name} style={{ objectFit: 'cover' }} />
            <Card.Body>
                <Card.Title style={{ fontSize: '1rem' }}>{item.name}</Card.Title>
                <Card.Text style={{ fontSize: '0.9rem' }}>
                    Birthday: {formattedBirthday}
                </Card.Text>
                <Card.Text style={{ fontSize: '0.9rem' }}>
                    Country: {item.country}
                </Card.Text>
                <Button variant="primary" size="sm" onClick={() => handleShow(item)}>
                    View Shows
                </Button>
            </Card.Body>
        </Card>
    );
};

export default PersonCard;

