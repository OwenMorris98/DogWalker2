import { useState, useEffect } from 'react'
import axios from 'axios';

interface Customer {
    first_name : string,
    last_name: string,
    address: string,
    city: string,
    state: string,
    zipcode: string
    
}

export const getCustomerById = () => {

    const [customerId, setCustomerId] = useState('');
    const [customer, setCustomer] = useState<Customer | null>(null);


   
    useEffect(() => {

        const fetchData = async () => {
            try {
                const response = await axios
                .get(`https://localhost:7188/api/Customer/${customerId}`);
                                //const response = await axios.get('https://localhost:7199/api/ShoppingListItems');
                console.log(response.data);
                setCustomer(response.data);
                
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        
            fetchData();
        

       
    }, [customerId]);

    return {
        customer,
        setCustomerId,
        customerId
    }
}
