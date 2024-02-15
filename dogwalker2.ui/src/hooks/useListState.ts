
import { useState, useEffect } from 'react'
import axios from 'axios';


export const useListState = () => {

    const [customerList, setCustomerList] = useState<any[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios
                .get('https://localhost:7188/api/Customer/');
                                //const response = await axios.get('https://localhost:7199/api/ShoppingListItems');
                console.log(response.data);
                setCustomerList(response.data.customers);
                
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, []);

    return {
        customerList
    }
}

