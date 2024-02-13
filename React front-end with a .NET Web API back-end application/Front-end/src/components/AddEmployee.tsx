import axios from 'axios';
import { FormEvent, useEffect, useRef, useState } from "react";
import url from "../misc/fixed";
import { CAlert, CButton } from '@coreui/bootstrap-react';

const AddEmployee = () => {

    const [id, setId] = useState("");
    const [name, setName] = useState("");
    const [age, setAge] = useState("");

    function handleSubmit(event: FormEvent<HTMLFormElement>): void {
        event.preventDefault(); 

        const emp = { id:id, name:name, age:age, counter:0 }
        axios.post(url, emp)
          .then(res=> {console.log(res.data); setVisible(true);}) 
          .catch(err=> console.log(err));
    }

    const resetForm = () => {
        setVisible(false);
        setId("");
        setName("");
        setAge("");
    } 

    const [visible, setVisible] = useState(false)

    return(
        <>
        <h1 className="text-center">Add employee</h1>
        <p/>

        <CAlert color="success" dismissible visible={visible} onClose={() => resetForm()}>Employee saved!</CAlert>
        
        <form onSubmit={handleSubmit}>    
        <div className="mb-3" style={{width: "200px", padding: "10px"}}>
        <label htmlFor="id" className="form-label">
          Employee Id:
        </label>
        <input id="id" type="text" className="form-control" onChange={(event) => setId(event.target.value)} value={id} />
        </div>
        <div className="mb-3" style={{width: "200px", padding: "10px"}}>
        <label htmlFor="name" className="form-label">
          Employee name:
        </label>
        <input id="id" type="name" className="form-control" onChange={(event) => setName(event.target.value)} value={name} />
        </div>
        <div className="mb-3" style={{width: "200px", padding: "10px"}}>
        <label htmlFor="age" className="form-label">
          Employee age:
        </label>
        <input id="age" type="number" className="form-control" onChange={(event) => setAge(event.target.value)} value={age} />
        </div>
        <div className="mb-3" style={{width: "200px", padding: "10px"}}>
        <button className="btn btn-primary">Save Employee</button>
        </div>
        </form>
        </>
    );

}

export default AddEmployee;