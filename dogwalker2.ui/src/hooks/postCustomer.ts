import { useState, useEffect } from 'react'
import axios from 'axios';

interface Customer {
    firstName : string,
    lastName: string,
    address: string,
    city: string,
    state: string,
    zipcode: string
    
}

export const postCustomer = () => {

    const [inputs, setInputs] = useState<Partial<Customer>>({});

    const handleChange = (event: any) => {
        const name = event.target.name;
        const value = event.target.value;
        setInputs(values => ({...values, [name]: value}))
      }

    const handleSubmit = async (e: any) => {
        e.preventDefault();
        console.log(inputs.firstName, inputs.lastName, inputs.address, inputs.city, inputs.state, inputs.zipcode)
        try {
            const resp = await axios.post("https://localhost:7188/api/Customer/", 
            { 
             first_name : inputs.firstName, 
             last_name: inputs.lastName,
             address: inputs.address,
             city: inputs.city,
             state: inputs.state,
             zipcode: inputs.zipcode,
            });
            console.log(resp.data);

        }
        catch(error) {
            console.log(error);
            
        }
    };

    return {   
        handleSubmit,
        inputs,
        handleChange,
        
    }
}