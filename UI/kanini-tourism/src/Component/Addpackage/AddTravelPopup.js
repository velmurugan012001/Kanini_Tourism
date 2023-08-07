import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

const TravelPopup = ({ show, handleClose, travel }) => {
  const [editedTravel, setEditedTravel] = useState({ ...travel });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedTravel((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = () => {
    // Handle the form submission here, e.g., update the travel data in the database
    // The edited data is available in the 'editedTravel' state variable
    console.log('Edited travel data:', editedTravel);
    handleClose(); // Close the modal after form submission
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Edit Travel Details</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId="travelVehicleType">
            <Form.Label>Vehicle Type</Form.Label>
            <Form.Control
              type="text"
              name="vehicleType"
              value={editedTravel.vehicleType}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="travelToDate">
            <Form.Label>To Date</Form.Label>
            <Form.Control
              type="date"
              name="toDate"
              value={editedTravel.toDate}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="travelFromDate">
            <Form.Label>From Date</Form.Label>
            <Form.Control
              type="date"
              name="fromDate"
              value={editedTravel.fromDate}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="travelFacilities">
            <Form.Label>Facilities</Form.Label>
            <Form.Control
              type="text"
              name="facilities"
              value={editedTravel.facilities}
              onChange={handleChange}
            />
          </Form.Group>

          {/* Add more travel details as needed */}
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

export default TravelPopup;
