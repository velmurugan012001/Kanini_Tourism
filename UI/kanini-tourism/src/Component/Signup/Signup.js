import React, { useState } from 'react';
import { Button, Typography, TextField, Container, Link, Card, CardContent } from '@mui/material';
import axios from 'axios';
import jwt_decode from 'jwt-decode';
import { Link as RouterLink, useNavigate } from 'react-router-dom';
import './Signup.css';

const Login = () => {
  const [formData, setFormData] = useState({
    emailId: '',
    password: '',
  });
  const navigate = useNavigate();

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const validateForm = () => {
    const newErrors = {};

    if (!formData.emailId) {
      newErrors.emailId = 'Email is required';
    } else if (!isValidEmail(formData.emailId)) {
      newErrors.emailId = 'Invalid email format';
    }

    if (!formData.password) {
      newErrors.password = 'Password is required';
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const isValidEmail = (email) => {
    const emailPattern = /^[a-z]+[a-z0-9._-]+@[a-z0-9.-]+\.[a-z]{2,4}$/;
    return emailPattern.test(email);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    if (!validateForm()) {
      return;  
    }
  
    try {
      const response = await axios.post('https://localhost:7202/api/Users/login', formData);
    
      const encodedToken = response.data;
      const decodedToken = jwt_decode(encodedToken);
      localStorage.setItem('token', JSON.stringify(decodedToken));
      console.log('Encoded Token:', encodedToken);
      console.log('Login success:', response.data);
      alert('Login successful! ');
      navigate('/home');
    } catch (error) {
      console.error('Error during login:', error.response.data);
    }
    
  };
  return (
    <div className='bgimg'>
      <p className='welcome'> Welcome to the Eagle Tourism</p>
      <Container className='Container' maxWidth="sm" style={{ textAlign: 'center', marginTop: '100px' }}>
      
          <CardContent>
            <p className='Typography1' variant="h4" gutterBottom>
              Login
            </p>
            <form onSubmit={handleSubmit}>
              <TextField
                label="Email"
                name="emailId"
                type="email"
                value={formData.emailId}
                onChange={handleChange}
                fullWidth
                margin="normal"
                variant="outlined"
                style={{ marginBottom: '20px' }}
                error={Boolean(errors.emailId)}
                helperText={errors.emailId}
              />
              <TextField
                label="Password"
                name="password"
                type="password"
                value={formData.password}
                onChange={handleChange}
                fullWidth
                margin="normal"
                variant="outlined"
                style={{ marginBottom: '20px' }}
                error={Boolean(errors.password)}
                helperText={errors.password}
              />
              <Button
                type="submit"
                className='button'
                variant="contained"
                style={{ padding: '10px 30px', marginBottom: '10px'}}
              >
                Login
              </Button>
              <Typography>
                New user? <p className='Typography2'><Link component={RouterLink} to="/register">Sign Up</Link></p>
              </Typography>
            </form>
          </CardContent>
       
      </Container>
    </div>
  );
};

export default Login;
