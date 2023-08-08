import React from 'react';
import Modal from 'react-bootstrap/Modal';

const DisTravelPopup = ({ show, handleClose, travelDetails }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Vehicle Type: {travelDetails.vehicleType}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
                  <p>To Date: {travelDetails.toDate}</p>
                  <p>From Date: {travelDetails.fromDate}</p>
                  <p>Facilities: {travelDetails.facilities}</p>
                  <p>Itinerary: {travelDetails.itinerary}</p>
        {/* Add more hotel details as needed */}
      </Modal.Body>
    </Modal>
  );
};

export default DisTravelPopup;
