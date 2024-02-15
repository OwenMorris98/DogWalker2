
import './App.css'
import { useParams } from 'react-router-dom'
import { getCustomerById } from './hooks/getCustomerById';
import { useEffect } from 'react';
//import { Link } from "react-router-dom"
function Details() {
const {setCustomerId, customer, customerId} = getCustomerById();
const params = useParams<{customerid: string }>();

useEffect(() => {
    if(params.customerid) {
        setCustomerId(params.customerid);
    }
    
}, [params, setCustomerId, customerId])


    return (
        <div>
            {/* <h1>Details Page {params.customerid}</h1> */}
            <h2>{customer?.first_name}</h2>
            <h2>{customer?.last_name}</h2>
            <h2>{customer?.address}</h2>
            <h2>{customer?.city}</h2>
            <h2>{customer?.state}</h2>
            <h2>{customer?.zipcode}</h2>
        </div>
    )
}


export default Details