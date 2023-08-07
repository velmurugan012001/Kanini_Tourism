import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Navbar from '../src/Component/Navbar/Navbar';
import { Routes, Route } from "react-router-dom";
import Home from './Component/Router/Home';
import About from './Component/Router/About';
import Contact from './Component/Home/Contact';
import Package from './Component/Router/Package';
import Booking from './Component/Router/Booking';
import Signup from './Component/Signup/Signup';
import RegistrationPage from './Component/Register/Register';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/about' element={<About />} />
        <Route path='/contact' element={<Contact />} />
        <Route path='/package' element={<Package />} />
        <Route path='/booking' element={<Booking />} />
        <Route path='/signup' element={<Signup />} />
        <Route path='/register' element={<RegistrationPage />} />
      </Routes>

      <Navbar />
    </div>
  );
}

export default App;
