import React, { useState, useEffect } from 'react';
import './Homepage.css';
import Carousel from 'react-bootstrap/Carousel';
import img1 from './../../Assect/bg1.jpg';
import img2 from './../../Assect/bg2.jpg';
import img3 from './../../Assect/bg1.jpg';
import 'bootstrap/dist/css/bootstrap.min.css';




export default function Homepage() {


 
  return (
    <div className='homepage-container'>
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
  );
}
