import React, { Component } from "react";
import { Link } from "react-router-dom";
import logo from "./logo.png";
import "./Navbar.css";

class Navbar extends Component {
  constructor(props) {
    super(props);
    this.state = {
      clicked: false,
    };
  }

  handleMenuIconClick = () => {
    this.setState((prevState) => ({
      clicked: !prevState.clicked,
    }));
  };

  handleLogout = () => {
    // Clear the token from local storage
    localStorage.removeItem('token');
    // alert('Logged out successfully');
  };

  render() {
    const { token } = this.props;
    const navItems = [];
    if (token) {
      if (token.role === 'user') {
        navItems.push(
          { label: 'Home', path: '/Home', cName: 'nav-links' },
          { label: 'Travel Package', path: '/Package', cName: 'nav-links' }
        );
      } else if (token.role === 'agent') {
        navItems.push(
          { label: 'Home', path: '/Home', cName: 'nav-links' },
          { label: 'Add Package', path: '/Booking', cName: 'nav-links' },
          { label: 'Travel Package', path: '/Package', cName: 'nav-links' }
        );
      } else if (token.role === 'Admin') {
        navItems.push(
          { label: 'Admin', path: '/AdminApprovalPage', cName: 'nav-links' },
          { label: 'Home', path: '/Home', cName: 'nav-links' },
          { label: 'Add Package', path: '/Booking', cName: 'nav-links' },
          { label: 'Travel Package', path: '/Package', cName: 'nav-links' }
        );
      }
    }
    return (
      <nav className="NavbarItems">
        <div className="navbar-logo">
          <img src={logo} alt="Logo" />
          <span>Eagle Tourism</span>
          <div className="menu-icons" onClick={this.handleMenuIconClick}>
            <i className={this.state.clicked ? "fas fa-times" : "fas fa-bars"}></i>
          </div>
        </div>
        <ul className={this.state.clicked ? "nav-menu active" : "nav-menu"}>
          {navItems.map((item, index) => (
            <li key={index}>
              <Link className={item.cName} to={item.path}>
                {item.label} {item.icon}
              </Link>
            </li>
          ))}
          {token && (
            <li className="logout">
              <Link to="/" onClick={this.handleLogout}>
                Log Out 
              </Link>
            </li>
          )}
        </ul>
      </nav>
    );
  }
}

export default Navbar;
