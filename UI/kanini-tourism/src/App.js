 
import './App.css';
import Navbar from '../src/Component/Navbar/Navbar';
import { BrowserRouter as Router } from "react-router-dom";


function App() {
  return (
    <div className="App">
      <Router>
      <Navbar />
      </Router>

    </div>
  );
}

export default App;
