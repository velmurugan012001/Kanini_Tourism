import React from 'react';
import './Homepage.css';
import Carousel from 'react-bootstrap/Carousel';
import img1 from './../../Assect/bg1.jpg';
import img2 from './../../Assect/bg2.jpg';
import img3 from './../../Assect/bg3.webp';
import 'bootstrap/dist/css/bootstrap.min.css';
import Countact from '../About/Countact';
import imgs1 from './../../Assect/a2.jpg';
import imgs2 from './../../Assect/p2.jpg';
import imgs3 from './../../Assect/p3.jpg';



export default function Homepage() {


  return (
    <>
    <div className='homepage-container'>
     <Carousel interval={2000} /* Auto slide every 3 seconds */>
        <Carousel.Item>
          <img className="d-block w-100" src={img1} alt="First slide" />
          <Carousel.Caption>
            <h3>Traveling is the only thing</h3>
                 <h3> you can buy that makes you richer.</h3>
            <p>
    . Discover the beauty of the world and create lasting memories with our exceptional tourism services.
  </p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img className="d-block w-100" src={img2} alt="Second slide" />
          <Carousel.Caption>
            <h3> Attraction, Accessibility, Accommodation, Amenities and Activities.</h3>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img className="d-block w-100" src={img3} alt="Third slide" />
          <Carousel.Caption>
            <h3>Plan your next journey with us and embark on an unforgettable adventure</h3>
            <p>create lasting memories with our exceptional tourism services..</p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>

      <div className='tourism-info'>
        <h2>About Tourism</h2>
        <p>
          Tourism is an essential part of many economies around the world. It involves people traveling to different places for leisure, business, or other purposes.
          Tourism provides numerous benefits, including economic growth, job creation, cultural exchange, and fostering mutual understanding between people of different backgrounds.
          Whether it's exploring natural wonders, experiencing local traditions, or indulging in culinary delights, tourism offers a diverse range of experiences for travelers to enjoy.
        </p>
        <p>
          At our tourism agency, we are committed to providing the best travel experiences to our customers. We offer various tour packages that cater to different interests and preferences.
          Whether you're seeking adventure, relaxation, or cultural exploration, we have something for everyone. Our team of experienced guides and travel experts is dedicated to ensuring your trip is memorable and enjoyable.
        </p>
        <p>
          Plan your next journey with us and embark on an unforgettable adventure. Discover the beauty of the world and create lasting memories with our exceptional tourism services.
        </p>
      </div>
      
     
    </div>
  {/* Adding three cards */}
<div className='cards-container'>
  <div className='card'>
    <img className='card-image' src={imgs1} alt='Card 1' />
    <div className='card-content'>
      <h2>Gokarna, Karnataka</h2>
      <p>Land of palm trees, blue seas and golden sands..</p>
    </div>
  </div>
  <div className='card'>
    <img className='card-image' src={imgs2} alt='Card 2' />
    <div className='card-content'>
      <h2>Munnar, Kerala</h2>
      <p>Tea Gardens, Lakes and Pretty little hill-station. .</p>
    </div>
  </div>
  <div className='card'>
    <img className='card-image' src={imgs3} alt='Card 3' />
    <div className='card-content'>
      <h2>Goa</h2>
      <p>Beaches, Sunsets and Crazy Nights. ...</p>
    </div>
  </div>
</div>
<br></br>

    <Countact />
    </>
  );
}
