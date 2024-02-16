import { useState, useEffect } from 'react'
import axios from 'axios';
import  Customer  from '../interfaces/Customer'

export  const usePutCustomer =  (customerId: string, customer: any) => {

    
    
    const putCustomer = async () => {
        if(customerId) {
        try {
            const response = await axios
            .put(`https://localhost:7188/api/Customer/${customerId}`, customer);  
            return response.data;
            
        } catch (error) {
            return console.error('Error fetching data:', error);
        }
    }};

    // useEffect(() => {
    // getCustomerById();
    // }, [customerId]);
    return {
        putCustomer
    }
  
}
