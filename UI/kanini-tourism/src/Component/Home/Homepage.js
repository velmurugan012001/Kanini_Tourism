import React, { useState, useEffect } from 'react';
import './Homepage.css';
import cardpg1 from "../../Assect/i1.jpg";
import cardpg2 from "../../Assect/i2.jpg";
import cardpg3 from "../../Assect/p1.png";
import cardpg4 from "../../Assect/p2.jpg";

const images = [
  'https://www.visitsaudi.com/content/dam/no-dynamic-media-folder/manifest-newarticles-batch1/11-10-instagram-worthy-sunset-spots-in-saudi/10instagram-worthysunsetspotsinsaudi_card_7.jpg',
  'https://www.visitsaudi.com/content/dam/no-dynamic-media-folder/manifest-newarticles-batch1/11-10-instagram-worthy-sunset-spots-in-saudi/10instagram-worthysunsetspotsinsaudi_card_6.jpg',
  'https://scth.scene7.com/is/image/scth/Summer%20packages%20landing_1920x1080:crop-1160x650?defaultImage=Summer%20packages%20landing_1920x1080&wid=1456&hei=815',
  // Add more image URLs as needed
];

const tourismInfo = [
  {
    title: 'Tour Package 1',
    description: 'Explore the scenic beauty with our amazing tour package.',
    image: cardpg1,
  },
  {
    title: 'Tour Package 2',
    description: 'Experience adventure and culture with our exciting tour package.',
    image: cardpg2,
  },
  {
    title: 'Tour Package 3',
    description: 'Discover hidden gems with our unique tour package.',
    image: cardpg3,
  },
  {
    title: 'Tour Package 4',
    description: 'Relax and unwind with our luxury tour package.',
    image: cardpg4,
  },
];

export default function Homepage() {
  const [activeIndex, setActiveIndex] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      setActiveIndex((prevIndex) => (prevIndex + 1) % images.length);
    }, 5000); // Change slide every 5 seconds

    return () => clearInterval(interval);
  }, []);

  return (
    <div className='homepage-container'>
      <div className='background-image-container'>
        {images.map((image, index) => (
          <div
            key={index}
            className={`homeimg ${index === activeIndex ? 'active' : ''}`}
            style={{ backgroundImage: `url(${image})` }}
          />
        ))}
        <p1>Welcome to our Tourism Website</p1>
      </div>
      <div className='cards'>
        {tourismInfo.map((info, index) => (
          <div key={index} className='card'>
            <img className='card-image' src={info.image} alt='Tour Package' />
            <h3>{info.title}</h3>
            <p>{info.description}</p>
          </div>
        ))}
      </div>
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
