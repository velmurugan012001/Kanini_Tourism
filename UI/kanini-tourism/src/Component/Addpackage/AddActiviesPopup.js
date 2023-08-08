import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

const ActivitiesPopup = ({ show, handleClose, activity ,onSave }) => {
  const [editedActivity, setEditedActivity] = useState({ ...activity });
  const [formData, setFormData] = useState({
    offeringType: '',
    destination: '',
    location: '',
    days: 0,
    nights: 0,
    totaldays: 0,
    itineraryDetails: '',
    pricePerPerson: '',
    hotelName: '',
    hotelPlace: '',
    hotelImage: '',
    foodType: '',
    bedType: '',
    vehicleType: '',
    toDate: '',
    fromDate: '',
    facilities: '',
    itinerary: '',
    activitiesName: '',
    description: '',
    duration: 0,
    activitiesImageUrl: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedActivity((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = () => {
    // Handle the form submission here, e.g., update the activity data in the database
    // The edited data is available in the 'editedActivity' state variable
    console.log('Edited activity data:', editedActivity);
     // Call the onSave function with the edited data
     onSave(editedActivity);
    // Update formData with editedActivity data
    setFormData((prevFormData) => ({
      ...prevFormData,
      activitiesName: editedActivity.activitiesName,
      description: editedActivity.description,
      duration: editedActivity.duration,
      // Add more fields as needed
    }));

    handleClose(); // Close the modal after form submission
  };


  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title className="Typography1">Activity Details</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId="activitiesName">
            <Form.Label>Activity Name</Form.Label>
            <Form.Control
              type="text"
              name="activitiesName"
              value={editedActivity.activitiesName}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="description">
            <Form.Label>Description</Form.Label>
            <Form.Control
              as="textarea"
              name="description"
              value={editedActivity.description}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="duration">
            <Form.Label>Duration</Form.Label>
            <Form.Control
              type="number"
              name="duration"
              value={editedActivity.duration}
              onChange={handleChange}
            />
          </Form.Group>

          {/* Add more activity details as needed */}
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

export default ActivitiesPopup;
