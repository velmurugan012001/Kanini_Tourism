import React, { useEffect, useState } from 'react';
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';
import './PackagePage.css'; // Import the custom CSS file
import Carousel from 'react-bootstrap/Carousel';
import img1 from './../../Assect/i9.jpg';
import img2 from './../../Assect/i5.webp';
import img3 from './../../Assect/p9.jpg';
import 'bootstrap/dist/css/bootstrap.min.css';
import ActivitiesPopup from './ActivitiesPopup';
import HotelPopup from './HotelPopup';
import TravelPopup from './DisTravelPopup';
import { Link } from 'react-router-dom';
import Countact from '../About/Countact';

function Package() {
  const [packages, setPackages] = useState([]);
  const [showHotelPopup, setShowHotelPopup] = useState(false);
  const [selectedHotel, setSelectedHotel] = useState({});
  const [showTravelPopup, setShowTravelPopup] = useState(false);
  const [selectedTravel, setSelectedTravel] = useState({});
  const [showActivitiesPopup, setShowActivitiesPopup] = useState(false);
  const [selectedActivities, setSelectedActivities] = useState({});
  const [selectedFilter, setSelectedFilter] = useState("All"); // Added filter state

  useEffect(() => {
    const fetchPackages = async (filter) => {
      try {
        let url = 'https://localhost:7202/api/Package';
        if (filter !== "All") {
          url += `?offeringType=${filter}`;
        }
        const response = await fetch(url);
        const data = await response.json();
        setPackages(data);
      } catch (error) {
        console.error('Error fetching package details:', error);
      }
    };

    fetchPackages(selectedFilter); // Fetch packages with the selected filter
  }, [selectedFilter]);

  const handleHotelPopup = (hotel) => {
    setSelectedHotel(hotel);
    setShowHotelPopup(true);
  };

  const handleTravelPopup = (travel) => {
    setSelectedTravel(travel);
    setShowTravelPopup(true);
  };

  const handleActivitiesPopup = (activity) => {
    setSelectedActivities(activity);
    setShowActivitiesPopup(true);
  };
  return (
    <div>
       
      <Carousel interval={3000} /* Auto slide every 3 seconds */>
        <Carousel.Item>
          <img className="d-block w-100" src={img1} alt="First slide" />
          <Carousel.Caption>
            <h3>Jobs fill your pocket, but adventures fill your soul.</h3>
            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img className="d-block w-100" src={img2} alt="Second slide" />
          <Carousel.Caption>
            <h3>Live your life by a compass not a clock</h3>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img className="d-block w-100" src={img3} alt="Third slide" />
          <Carousel.Caption>
            <h3>Life is either a daring adventure or nothing at all.</h3>
            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>
      {/* Filter Select */}
       <select
        value={selectedFilter}
        onChange={(e) => setSelectedFilter(e.target.value)}
      >
        <option value="All">All</option>
        <option value="Adventure">Location</option>
        <option value="Relaxation">Relaxation</option>
        {/* Add other offering types as needed */}
      </select>
<div className="row">
  {packages.map((pkg) =>
    selectedFilter === "All" || selectedFilter === pkg.location ? (
      <div key={pkg.id} className="col">
        <Card className="custom-card" style={{ width: '40rem', height: '40rem' }}>
          <Card.Img variant="top" src={pkg.imageSrc} style={{ width: '18rem' }} />
          <Card.Body className="custom-card-body">
            <Card.Title className="custom-card-title">{pkg.title}</Card.Title>
            <Card.Text>
              <p className="Typography1">{pkg.location}</p>
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
            <ListGroup.Item className="custom-list-group-item" onClick={() => handleHotelPopup(pkg)}>
              Hotel
            </ListGroup.Item>
            <ListGroup.Item className="custom-list-group-item" onClick={() => handleTravelPopup(pkg)}>
              Travel
            </ListGroup.Item>
            <ListGroup.Item className="custom-list-group-item" onClick={() => handleActivitiesPopup(pkg)}>
              Activities
            </ListGroup.Item>
          </ListGroup>
          <Card.Body>
            <Card.Link as={Link} to={`/BookingDetails/${pkg.id}`} className="custom-card-link">
              Price Per Person: {pkg.pricePerPerson}
              <p>Book Now</p>
            </Card.Link>
          </Card.Body>
        </Card>
      </div>
    ) : null
  )}
</div>

     
      {/* Hotel Popup */}
      {showHotelPopup && (
        <HotelPopup show={showHotelPopup} handleClose={() => setShowHotelPopup(false)} hotel={selectedHotel} />
      )}

      {/* Travel Popup */}
      {showTravelPopup && (
        <TravelPopup show={showTravelPopup} handleClose={() => setShowTravelPopup(false)} travelDetails={selectedTravel} />
      )}

      {/* Activities Popup */}
      {showActivitiesPopup && (
        <ActivitiesPopup
          show={showActivitiesPopup}
          handleClose={() => setShowActivitiesPopup(false)}
          activitiesDetails={selectedActivities}
        />
      )}
      <Countact></Countact>
    </div>
  );
}

export default Package;