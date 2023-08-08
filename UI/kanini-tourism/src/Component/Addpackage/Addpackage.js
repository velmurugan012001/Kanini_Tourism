import React, { useState, useEffect } from 'react';
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Carousel from 'react-bootstrap/Carousel';
import HotelPopup from './AddHotelPopup.js';
import TravelPopup from './AddTravelPopup.js';
import ActivitiesPopup from './AddActiviesPopup.js';
import img1 from './../../Assect/bg1.jpg';
import img2 from './../../Assect/bg2.jpg';
import img3 from './../../Assect/bg1.jpg';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import './Addpackage.css'

export default function Addpackage() {
  

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
    setFormData((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      console.log(formData);
       
      // Send the form data to the server using Axios POST request
      const response = await axios.post('https://localhost:7202/api/Package', formData);
  
      console.log(response);
      console.log('Server response:', response.data);
  
      // Reset the form data after successful submission (optional)
      setFormData({
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
        activitiesImageUrl: '',
      });
      // Show the alert after successful form submission
      window.alert('Form submitted successfully!');
    } catch (error) {
      console.error('Error submitting form:', error);
    }
  };
  

    

     // State to control the display of popups
  const [showHotelPopup, setShowHotelPopup] = useState(false);
  const [showTravelPopup, setShowTravelPopup] = useState(false);
  const [showActivitiesPopup, setShowActivitiesPopup] = useState(false);

  // State to hold data for each popup
  const [selectedHotel, setSelectedHotel] = useState({});
  const [selectedTravel, setSelectedTravel] = useState({});
  const [selectedActivity, setSelectedActivity] = useState({});

  // Function to open and close the popups
  const handleHotelPopup = (hotel) => {
    setSelectedHotel(hotel);
    setShowHotelPopup(true);
  };

  const handleTravelPopup = (travel) => {
    setSelectedTravel(travel);
    setShowTravelPopup(true);
  };

  const handleActivitiesPopup = (activity) => {
    setSelectedActivity(activity);
    setShowActivitiesPopup(true);
  };
  const handleActivitiesSave = (editedActivity) => {
    // Update the formData with the editedActivity data
    setFormData((prevFormData) => ({
      ...prevFormData,
      activitiesName: editedActivity.activitiesName,
      description: editedActivity.description,
      duration: editedActivity.duration,
      // Add more fields as needed
    }));
   };
// Function to handle saving travel data
const handleTravelSave = (editedTravel) => {
    setFormData((prevFormData) => ({
      ...prevFormData,
      vehicleType: editedTravel.vehicleType,
      toDate: editedTravel.toDate,
      fromDate: editedTravel.fromDate,
      facilities: editedTravel.facilities,
      itinerary: editedTravel.itinerary,
      // Add more fields as needed
    }));
  };

   // Function to handle saving hotel data
   const handleHotelSave = (editedHotel) => {
    setFormData((prevFormData) => ({
      ...prevFormData,
      hotelName: editedHotel.hotelName,
      hotelImage: editedHotel.hotelImage,
      hotelPlace: editedHotel.hotelPlace,
      foodType: editedHotel.foodType,
      bedType: editedHotel.bedType,
      
      // Add more fields as needed
    }));
  };
  return (
    <div className='bgimg2'>
      

      <Card className="custom-card" style={{ width: '30rem' }}>
        <Card.Body className="custom-card-body">
          <Card.Title className="Typography1">Add Package</Card.Title>
          <Form>
            <Form.Group controlId="location">
              <Form.Label>Location</Form.Label>
              <Form.Control
                type="text"
                name="location"
                value={formData.location}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group controlId="offeringType">
              <Form.Label>Offering Type</Form.Label>
              <Form.Control
                type="text"
                name="offeringType"
                value={formData.offeringType}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group controlId="destination">
              <Form.Label>Destination</Form.Label>
              <Form.Control
                type="text"
                name="destination"
                value={formData.destination}
                onChange={handleChange}
              />
            </Form.Group>


            <Form.Group controlId="days">
              <Form.Label>Days</Form.Label>
              <Form.Control
                type="number"
                name="days"
                value={formData.days}
                onChange={handleChange}
              />
            </Form.Group>
            


            <Form.Group controlId="nights">
              <Form.Label>Nights</Form.Label>
              <Form.Control
                type="number"
                name="nights"
                value={formData.nights}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group controlId="totaldays">
              <Form.Label>Total days</Form.Label>
              <Form.Control
                type="number"
                name="totaldays"
                value={formData.totaldays}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group controlId="itineraryDetails">
              <Form.Label>Itinerary Details</Form.Label>
              <Form.Control
                type="text"
                name="itineraryDetails"
                value={formData.itineraryDetails}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group controlId="pricePerPerson">
              <Form.Label>Price Per Person</Form.Label>
              <Form.Control
                type="number"
                name="pricePerPerson"
                value={formData.pricePerPerson}
                onChange={handleChange}
              />
            </Form.Group><br></br>
 {/* Buttons to open popups */}
 <Button variant="secondary" onClick={() => handleHotelPopup()}>Hotel Details</Button>
    <Button variant="secondary" onClick={() => handleTravelPopup()}>Travel Details</Button>
    <Button variant="secondary" onClick={() => handleActivitiesPopup()}>Activities Details</Button>

    {/* Hotel Popup */}
    <HotelPopup
        show={showHotelPopup}
        handleClose={() => setShowHotelPopup(false)}
        hotel={selectedHotel}
        onSave={handleHotelSave} // Pass the onSave prop here
      />

      {/* Travel Popup */}
      <TravelPopup
        show={showTravelPopup}
        handleClose={() => setShowTravelPopup(false)}
        travel={selectedTravel}
        onSave={handleTravelSave} // Pass the onSave prop here
      />

    {/* Activities Popup */}
    <ActivitiesPopup
        show={showActivitiesPopup}
        handleClose={() => setShowActivitiesPopup(false)}
        activity={selectedActivity}
        onSave={handleActivitiesSave} // Pass the onSave prop here
      />

            {/* Add more form fields for other properties as needed */}
            <Button variant="success" type="submit" onClick={handleSubmit} className="centered-button">
              Submit
            </Button>
          </Form>
        </Card.Body>
      </Card>
    </div>
  );
  }