import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

const HotelPopup = ({ show, handleClose, hotel }) => {
  const [editedHotel, setEditedHotel] = useState({ ...hotel });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedHotel((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = () => {
    // Handle the form submission here, e.g., update the hotel data in the database
    // The edited data is available in the 'editedHotel' state variable
    console.log('Edited hotel data:', editedHotel);
    handleClose(); // Close the modal after form submission
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Edit Hotel Details</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId="hotelName">
            <Form.Label>Hotel Name</Form.Label>
            <Form.Control
              type="text"
              name="name"
              value={editedHotel.name}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="hotelPlace">
            <Form.Label>Place</Form.Label>
            <Form.Control
              type="text"
              name="place"
              value={editedHotel.place}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="hotelFoodType">
            <Form.Label>Food Type</Form.Label>
            <Form.Control
              type="text"
              name="foodType"
              value={editedHotel.foodType}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="hotelBedType">
            <Form.Label>Bed Type</Form.Label>
            <Form.Control
              type="text"
              name="bedType"
              value={editedHotel.bedType}
              onChange={handleChange}
            />
          </Form.Group>
          {/* Add more hotel details as needed */}
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Close
        </Button>
        <Button variant="primary" onClick={handleSubmit}>
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default HotelPopup;
