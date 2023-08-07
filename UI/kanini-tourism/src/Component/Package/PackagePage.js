import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';
import './PackagePage.css'; // Import the custom CSS file
import Carousel from 'react-bootstrap/Carousel';
import img1 from './../../Assect/bg1.jpg';
import img2 from './../../Assect/bg2.jpg';
import img3 from './../../Assect/bg1.jpg';
import 'bootstrap/dist/css/bootstrap.min.css';
import HotelPopup from './HotelPopup.jsx';

function Package() {
  const [packages, setPackages] = useState([]);
  const [showHotelPopup, setShowHotelPopup] = useState(false);
  const [selectedHotel, setSelectedHotel] = useState(null);

  useEffect(() => {
    // Function to fetch package details
    const fetchPackages = async () => {
      try {
        const response = await fetch('https://localhost:7202/api/Packages'); // Replace with your API endpoint URL
        const data = await response.json();
        setPackages(data); // Assuming the response contains an array of package details
      } catch (error) {
        console.error('Error fetching package details:', error);
      }
    };

    fetchPackages();
  }, []);

  const fetchHotelDetails = async (hotalId) => {
    try {
      const response = await axios.get(`https://localhost:7202/api/Hotels/${hotalId}`);
      const hotel = response.data;
      setSelectedHotel(hotel);
      setShowHotelPopup(true);
    } catch (error) {
      console.error('Error fetching hotel details:', error);
    }
  };
  

  const handleHotelClick = (hotel) => {
   
      fetchHotelDetails(hotel.hotalId);
   
  };
  
  

  const handleCloseHotelPopup = () => {
    setSelectedHotel(null);
    setShowHotelPopup(false);
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

      <div className="row">
        {packages.map((pkg) => (
          <div key={pkg.id} className="col">
            <Card className="custom-card" style={{ width: '80rem', height: '40rem' }}>
  <Card.Img variant="top" src={pkg.imageSrc} style={{ width: '18rem' }} />
  <Card.Body className="custom-card-body">
    <Card.Title className="custom-card-title">{pkg.title}</Card.Title>
    <Card.Text>
      <p>{pkg.location}</p>
      <br />
      <p>destination: {pkg.destination}</p>
      <br />
      <p>Offering Type: {pkg.offeringType}</p>
      <p>Itinerary Details: {pkg.itineraryDetails}</p>
      <p>Day: {pkg.days}</p>
      <p>Night: {pkg.nights}</p>
      <p>Total Days: {pkg.totaldays}</p>
    </Card.Text>
  </Card.Body>
  <ListGroup className="list-group-flush">
                <ListGroup.Item
                  className="custom-list-group-item"
                  onClick={() => handleHotelClick(pkg.hotel)}
                >
                  Hotel
                </ListGroup.Item>
    <ListGroup.Item className="custom-list-group-item">Travel</ListGroup.Item>
    <ListGroup.Item className="custom-list-group-item">Activities</ListGroup.Item>
  </ListGroup>
  <Card.Body>
    <Card.Link href="#" className="custom-card-link">
      Price Per Person: {pkg.pricePerPerson}
    </Card.Link>
  </Card.Body>
</Card>
          </div>
        ))}
      </div>
       {/* Render the HotelPopup component */}
       {selectedHotel && (
        <HotelPopup
          show={showHotelPopup}
          handleClose={handleCloseHotelPopup}
          hotel={selectedHotel}
        />
      )}
    </div>
  );
}

export default Package;
