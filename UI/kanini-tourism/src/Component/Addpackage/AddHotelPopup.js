import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

const HotelPopup = ({ show, handleClose, hotel ,onSave}) => {
  const [editedHotel, setEditedHotel] = useState({ ...hotel });
  const [formData, setFormData] = useState({
    // Add the initial values for the formData object as needed
    // For hotel related fields, initialize them here if needed
    hotelName: '',
    hotelImage: '',
    hotelPlace: '',
    foodType: '',
    bedType: '',
    

    // Add more fields as needed
  });

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
    
      // Call the onSave function with the edited data
      onSave(editedHotel);
    // Update formData with editedHotel data
    setFormData((prevFormData) => ({
      ...prevFormData,
      hotelName: editedHotel.hotelName,
      hotelImage: editedHotel.hotelImage,
      hotelPlace: editedHotel.hotelPlace,
      foodType: editedHotel.foodType,
      bedType: editedHotel.bedType,
      


      // Add more fields as needed
    }));

    handleClose(); // Close the modal after form submission
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title className="Typography1">Hotel Details</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId="hotelName">
            <Form.Label>Hotel Name</Form.Label>
            <Form.Control
              type="text"
              name="hotelName"
              value={editedHotel.hotelName}
              onChange={handleChange}
            />
          </Form.Group>
          <Form.Group controlId="hotelImage">
            <Form.Label>Hotel Image</Form.Label>
            <Form.Control
              type="text"
              name="hotelImage"
              value={editedHotel.hotelImage}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="hotelPlace">
            <Form.Label>Place</Form.Label>
            <Form.Control
              type="text"
              name="hotelPlace"
              value={editedHotel.hotelPlace}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="foodType">
            <Form.Label>Food Type</Form.Label>
            <Form.Control
              type="text"
              name="foodType"
              value={editedHotel.foodType}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="bedType">
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
        <Button variant="success" onClick={handleSubmit}>
          Save
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default HotelPopup;
