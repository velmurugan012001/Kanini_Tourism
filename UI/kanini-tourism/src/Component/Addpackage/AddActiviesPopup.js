import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

const ActivitiesPopup = ({ show, handleClose, activity }) => {
  const [editedActivity, setEditedActivity] = useState({ ...activity });

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
    handleClose(); // Close the modal after form submission
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Edit Activity Details</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId="activityName">
            <Form.Label>Activity Name</Form.Label>
            <Form.Control
              type="text"
              name="name"
              value={editedActivity.name}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="activityDescription">
            <Form.Label>Description</Form.Label>
            <Form.Control
              as="textarea"
              name="description"
              value={editedActivity.description}
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group controlId="activityDuration">
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
        <Button variant="primary" onClick={handleSubmit}>
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ActivitiesPopup;
