
import { useState, useEffect } from 'react'
import axios from 'axios';


export const useListState = () => {

    const [customerList, setCustomerList] = useState<any[]>([]);

    const handleDelete = async (customerId: string) => {
        
        try{
            const deleteResponse = await axios.delete(`https://localhost:7188/api/Customer/${customerId}`);
            console.log(deleteResponse.data);
            setCustomerList(prevCustomerList => {
                return prevCustomerList.filter(customer => customer.id !== customerId)
            })
        }
        catch(error) {
            console.error('Error deleting data:', error)
            return console.log(error)
        }
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios
                .get('https://localhost:7188/api/Customer/');                                
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
        ,handleDelete
    }
}

