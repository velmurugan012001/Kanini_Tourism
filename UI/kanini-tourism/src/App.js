import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Navbar from '../src/Component/Navbar/Navbar';
import { Routes, Route } from "react-router-dom";
import Home from './Component/Router/Home';
import About from './Component/Router/About';
import Package from './Component/Router/Package';
import Booking from './Component/Router/Booking';
import Signup from './Component/Signup/Signup';
import RegistrationPage from './Component/Register/Register';
import AdminApprovalPage from './Component/Admin/AdminApprovalPage';
import AdminImageGallery from './Component/Admin/AdminImageGallery';
import BookingDetails from './Component/Booking/BookingDetails';
import Cauntact from './Component/About/Countact';


function App() {
  const token = JSON.parse(localStorage.getItem('token'))
  return (
    <div className="App">
            <Navbar token={token} />
      <Routes>
        <Route path='/Home' element={<Home />} />
        <Route path='/About' element={<About />} />
        <Route path='/Countact' element={<Cauntact/>}/> 
        <Route path='/package' element={<Package />} />
        <Route path='/booking' element={<Booking />} />
        <Route path='/' element={<Signup />} />
        <Route path='/register' element={<RegistrationPage />} />
        <Route path='/AdminApprovalPage' element={<AdminApprovalPage />} />
        <Route path='/AdminImageGallery' element={<AdminImageGallery />} />
        <Route path='/BookingDetails/:id' element={<BookingDetails />} />


      </Routes>


    </div>
  );
}

export default App;
