import React from 'react';
import Modal from 'react-bootstrap/Modal';

const HotelPopup = ({ show, handleClose, hotel }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Hotel Name :{hotel.name}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
       
        <p>place: {hotel.place}</p>
        <p>foodType: {hotel.foodType}</p>
        <p>bedType: {hotel.bedType}</p>
        {/* Add more hotel details as needed */}
      </Modal.Body>
    </Modal>
  );
};

export default HotelPopup;
