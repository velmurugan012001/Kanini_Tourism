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

export default function Addpackage() {
  

  const [formData, setFormData] = useState({
    packageID: 0,
    offeringType: '',
    destination: '',
    location: '',
    days: 0,
    nights: 0,
    totaldays: 0,
    itineraryDetails: '',
    pricePerPerson: '',
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
        console.log("Formdata")
      // Send the form data to the server using Axios POST request
      const response = await axios.post('https://localhost:7202/api/Packages', formData,);
      console.log(response)
      console.log('Server response:', response.data);
      // Reset the form data after successful submission (optional)
      setFormData({
        packageID: 0,
        offeringType: '',
        destination: '',
        location: '',
        days: 0,
        nights: 0,
        totaldays: 0,
        itineraryDetails: '',
        pricePerPerson: '',
      });
    } catch (error) {
      console.error('Error submitting form:', error);
    }
  };
     // State to control the display of popups
  const [showHotelPopup, setShowHotelPopup] = useState(false);
  const [showTravelPopup, setShowTravelPopup] = useState(false);
  const [showActivitiesPopup, setShowActivitiesPopup] = useState(false);

  
  // State to hold the fetched data for each popup
  const [hotelData, setHotelData] = useState({});
  const [travelData, setTravelData] = useState({});
  const [activitiesData, setActivitiesData] = useState({});

  // Function to fetch data for each popup
  const fetchHotelData = async () => {
    try {
      const response = await axios.get('https://localhost:7202/api/Hotels');
      setHotelData(response.data); // Assuming the API response is an object containing hotel data
    } catch (error) {
      console.error('Error fetching hotel data:', error);
    }
  };

  const fetchTravelData = async () => {
    try {
      const response = await axios.get('https://localhost:7202/api/Travels');
      setTravelData(response.data); // Assuming the API response is an object containing travel data
    } catch (error) {
      console.error('Error fetching travel data:', error);
    }
  };

  const fetchActivitiesData = async () => {
    try {
      const response = await axios.get('https://localhost:7202/api/Activities');
      setActivitiesData(response.data); // Assuming the API response is an object containing activities data
    } catch (error) {
      console.error('Error fetching activities data:', error);
    }
  };

    // Fetch data when the component mounts
    useEffect(() => {
        fetchHotelData();
        fetchTravelData();
        fetchActivitiesData();
      }, []);
  // State to hold the selected hotel, travel, and activity
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

  return (
    <div>
      <Carousel interval={3000} /* Auto slide every 3 seconds */>
        <Carousel.Item>
          <img className="d-block w-100" src={img1} alt="First slide" />
          <Carousel.Caption>
            <h3>First slide label</h3>
            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img className="d-block w-100" src={img2} alt="Second slide" />
          <Carousel.Caption>
            <h3>Second slide label</h3>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img className="d-block w-100" src={img3} alt="Third slide" />
          <Carousel.Caption>
            <h3>Third slide label</h3>
            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>

      <Card className="custom-card" style={{ width: '20rem' }}>
        <Card.Body className="custom-card-body">
          <Card.Title className="custom-card-title">Add Package</Card.Title>
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
            </Form.Group>

           
 
    {/* Buttons to open popups */}
    <Button variant="secondary" onClick={() => handleHotelPopup(hotelData)}>Hotel Details</Button>
    <Button variant="secondary" onClick={() => handleTravelPopup(travelData)}>Travel Details</Button>
    <Button variant="secondary" onClick={() => handleActivitiesPopup(activitiesData)}>Activities Details</Button>

    {/* Hotel Popup */}
    <HotelPopup show={showHotelPopup} handleClose={() => setShowHotelPopup(false)} hotel={selectedHotel} />

    {/* Travel Popup */}
    <TravelPopup show={showTravelPopup} handleClose={() => setShowTravelPopup(false)} travel={selectedTravel} />

    {/* Activities Popup */}
    <ActivitiesPopup show={showActivitiesPopup} handleClose={() => setShowActivitiesPopup(false)} activity={selectedActivity} />

            {/* Add more form fields for other properties as needed */}
            <Button variant="primary" type="submit" onClick={handleSubmit}>
              Submit
            </Button>
          </Form>
        </Card.Body>
      </Card>
    </div>
  );
}