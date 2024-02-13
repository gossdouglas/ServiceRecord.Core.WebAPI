import { Link, Route, Routes } from 'react-router-dom'
import Home from './components/Home'
import Employees from './components/Employees'
import AddEmployee from './components/AddEmployee'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.min.js'

const App = () => {
  return (
    <>

      <nav className="navbar bg-body-tertiary">
        <div>
        <a className="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                  Main Menu
                </a>
                <ul className="dropdown-menu">
                  <li><a className="dropdown-item" href="/">Home</a></li>
                  <li><a className="dropdown-item" href="/employees">Employees</a></li>
                  <li><a className="dropdown-item" href="/addemployee">Add Employee</a></li>
                </ul>
        </div>
      </nav>

      <p />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/employees" element={<Employees />} />
        <Route path="/addemployee" element={<AddEmployee />} />
        <Route />
      </Routes>
    </>
)}

export default App
