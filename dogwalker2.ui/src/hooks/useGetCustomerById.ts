import { useState, useEffect } from 'react'
import axios from 'axios';
import  Customer  from '../interfaces/Customer'

export  const useGetCustomerById =  (customerId: string) => {

    const getCustomerById = async () => {
        if(customerId) {
        try {
            const response = await axios
            .get(`https://localhost:7188/api/Customer/${customerId}`);                                
            return response.data;
            
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    }};

    useEffect(() => {
    getCustomerById();
    }, [customerId]);

    return {
        getCustomerById,    
    }
}
