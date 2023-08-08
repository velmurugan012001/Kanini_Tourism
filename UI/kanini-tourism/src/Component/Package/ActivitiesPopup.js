import React from 'react';
import Modal from 'react-bootstrap/Modal';

const ActivitiesPopup = ({ show, handleClose, activitiesDetails }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Activity Name: {activitiesDetails.activitiesName}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
                  <p>Description: {activitiesDetails.description}</p>
                  <p>Duration: {activitiesDetails.duration}</p>
        {/* Add more hotel details as needed */}
      </Modal.Body>
    </Modal>
  );
};

export default ActivitiesPopup;
