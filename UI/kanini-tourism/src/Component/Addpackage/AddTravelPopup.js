import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
const TravelPopup = ({ show, handleClose, travel, onSave }) => {
    const [editedTravel, setEditedTravel] = useState({ ...travel });
  const [formData, setFormData] = useState({
    // Add the initial values for the formData object as needed
    // For travel related fields, initialize them here if needed
    vehicleType: '',
    toDate: '',
    fromDate: '',
    facilities: '',
    itinerary: '',
    // Add more fields as needed
  });

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
 // Call the onSave function with the edited data
 onSave(editedTravel);
    // Update formData with editedTravel data
    setFormData((prevFormData) => ({
      ...prevFormData,
      vehicleType: editedTravel.vehicleType,
      toDate: editedTravel.toDate,
      fromDate: editedTravel.fromDate,
      facilities: editedTravel.facilities,
      itinerary: editedTravel.itinerary,
      // Add more fields as needed
    }));

    handleClose(); // Close the modal after form submission
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Edit Travel Details</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId="vehicleType">
            <Form.Label>Vehicle Type</Form.Label>
            <Form.Control
              type="text"
              name="vehicleType"
              value={editedTravel.vehicleType}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="toDate">
            <Form.Label>To Date</Form.Label>
            <Form.Control
              type="date"
              name="toDate"
              value={editedTravel.toDate}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="fromDate">
            <Form.Label>From Date</Form.Label>
            <Form.Control
              type="date"
              name="fromDate"
              value={editedTravel.fromDate}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="facilities">
            <Form.Label>Facilities</Form.Label>
            <Form.Control
              type="text"
              name="facilities"
              value={editedTravel.facilities}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="itinerary">
            <Form.Label>itinerary</Form.Label>
            <Form.Control
              type="text"
              name="itinerary"
              value={editedTravel.itinerary}
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
