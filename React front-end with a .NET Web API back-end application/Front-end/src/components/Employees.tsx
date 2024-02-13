import axios from 'axios';
import { useEffect, useState } from "react";
import url from "../misc/fixed";

interface Employee{
  id: number,
  name: string,
  age:number,
  counter:number
}

const Employees = () => {

    const [employees, setEmployees] = useState<Employee[]>([]);
    
    useEffect(() => {
      getEmployees();
    },[])

    const getEmployees = () => {
      axios.get<Employee[]>(url)
      .then(res => setEmployees(res.data));
    }

    const onDelete = (id: number) =>
    {
      axios.delete(url + `/${id}`)
      .then(res=> console.log(res.data))  // getEmployees()
      .catch(err=> console.log(err));
      setEmployees(employees.filter((e) => e.id != id)); // This is temporary
    }

    if (employees.length == 0) return (
      <>
      <h1 className="text-center">Employees</h1>
      <p/>
      <h3>There are no employees</h3>
      </>
    );

    return (
    <>
    <h1 className="text-center">Employees</h1>
    <p/>
    <div className="container text-center">
    <div className="row">
    <div className="col" style={{backgroundColor: "darkblue", color:"white"}}>
      Employee Id
    </div>
    <div className="col" style={{backgroundColor: "darkblue", color:"white"}}>
      Employee Name
    </div>
    <div className="col" style={{backgroundColor: "darkblue", color:"white"}}>
      Employee age
    </div>
    <div className="col" style={{backgroundColor: "darkblue", color:"white"}}>
    </div>
    </div>

    {employees.map((employee)=> (
        <div className="row" key={employee.id}>
        <div className= {employee.counter%2 == 0 ? "col p-3 mb-2 bg-info text-dark" : "col p-3 mb-2 bg-light text-dark"}>
          {employee.id}
        </div>
        <div className={employee.counter%2 == 0 ? "col p-3 mb-2 bg-info text-dark" : "col p-3 mb-2 bg-light text-dark"}>
        {employee.name}
        </div>
        <div className={employee.counter%2 == 0 ? "col p-3 mb-2 bg-info text-dark" : "col p-3 mb-2 bg-light text-dark"}>
        {employee.age}
        </div>
        <div className={employee.counter%2 == 0 ? "col p-3 mb-2 bg-info text-dark" : "col p-3 mb-2 bg-light text-dark"}>
        <button className="btn btn-outline-danger" onClick={() => onDelete(employee.id)}>
         Delete
        </button>
        </div>
        </div>
        ))}    
    </div>
    </>
    )};

export default Employees;
