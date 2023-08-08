import React, { useEffect, useState } from 'react';
import { Table } from '@mui/material';
import { Button } from '@mui/material';
import { TableBody } from '@mui/material';
import { TableCell } from '@mui/material';
import { TableContainer } from '@mui/material';
import { TableHead } from '@mui/material';
import { TableRow } from '@mui/material';
import { Paper } from '@mui/material';
import axios from 'axios';
import './AdminApprovel.css'
import Carousel from 'react-bootstrap/Carousel';
import img1 from './../../Assect/bg1.jpg';
import img2 from './../../Assect/bg2.jpg';
import img3 from './../../Assect/bg3.webp';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate } from 'react-router-dom';

const AdminApprovalPage = () => {
  const [pendingUsers, setPendingUsers] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchPendingUsers();
  }, []);

  const fetchPendingUsers = async () => {
    try {
      const response = await axios.get('https://localhost:7202/api/Users/pending');
      setPendingUsers(response.data);
    } catch (error) {
      console.error('Error fetching pending users:', error);
    }
  };

  const handleApproveUser = async (userId) => {
    try {
      await axios.post(`https://localhost:7202/api/Users/approve/${userId}`);
      fetchPendingUsers();
    } catch (error) {
      console.error('Error approving user:', error);
    }
  };

  const handleRejectUser = async (userId) => {
    try {
      await axios.post(`https://localhost:7202/api/Users/reject/${userId}`);
      fetchPendingUsers();
    } catch (error) {
      console.error('Error rejecting user:', error);
    }
  };

  const handleUploadGallery = () => {
    // Use the navigate function to redirect to the adminImageGallery page
    navigate('/AdminImageGallery');
  };

  return (
    <div>
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
            <h3>Second slide label</h3>
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
      <h2>Pending Users</h2>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
               
              <TableCell>Username</TableCell>
              <TableCell>Email</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {pendingUsers.map((user) => (
              <TableRow key={user.userId}>
                 <TableCell>{user.userName}</TableCell>
                <TableCell>{user.emailId}</TableCell>
                <TableCell>
                  <Button variant="contained" color="primary" onClick={() => handleApproveUser(user.userId)}>
                    Approve
                  </Button>
                  <Button variant="contained" color="secondary" onClick={() => handleRejectUser(user.userId)}>
                    Reject
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Button variant="contained" color="secondary" onClick={handleUploadGallery}>
      Upload Gallery
    </Button>
    </div>
    
  );
};

export default AdminApprovalPage;