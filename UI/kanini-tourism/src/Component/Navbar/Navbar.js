import React, { Component } from "react";
import { Menu } from "../Menu/Menu";
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

  render() {
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
          {Menu.map((item, index) => (
            <li key={index}>
              <a className={item.cName} href={item.url}>
                <i className={item.icon}></i>
                {item.title}
              </a>
            </li>
          ))}
        </ul>
      </nav>
    );
  }
}

export default Navbar;
