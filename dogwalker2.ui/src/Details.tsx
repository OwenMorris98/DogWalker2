
import './App.css'
import { useParams } from 'react-router-dom'
import { useGetCustomerById } from './hooks/useGetCustomerById';
import { useEffect, useState } from 'react';
import  Customer  from './interfaces/Customer'
import { usePutCustomer } from './hooks/usePutCustomer';
//import { Link } from "react-router-dom"
function Details() {
const {customerId} = useParams<{customerId: string }>();

const {getCustomerById} = useGetCustomerById(customerId as string);
const [customer, setCustomer] = useState<Customer | null>(null);
const [editMode, setEditMode] = useState(false);
const {putCustomer} = usePutCustomer(customerId as string, customer)

const handleSave = async () => {
  console.log(`Save button pressed! ${customer?.first_name}`, `${customer?.last_name}` );
  const putResponse = await putCustomer();
  console.log(putResponse);

  toggleEditMode();
}

const getCustomer = async () => {
    try {
        const response = await getCustomerById();
        console.log(response)
        setCustomer(response);
    } catch (error) {

        console.error('Error fetching customer data:', error);
    }
};
const handleFieldChange = (field: string) => (event: React.ChangeEvent<HTMLInputElement>) => {
    setCustomer((prevCustomer) => ({
      ...prevCustomer!,
      [field]: event.target.value,
    }));
  };

const toggleEditMode = () => {
    setEditMode((prevEditMode) => !prevEditMode);
  };

  const saveButtonOnClick = editMode ? handleSave : toggleEditMode;

useEffect(() => {
    if (customerId) {
        getCustomer();
    }
}, [customerId]);


    return (
        <div>
            {/* <h1>Details Page {params.customerid}</h1> */}
    <>
      {customer && (
        <>
          {editMode ? (
            <table>
              <thead>
                <tr>
                  <td>
                    <input
                      type="text"
                      value={customer.first_name}
                      onChange={handleFieldChange('first_name')}
                    />
                  </td>
                  <td>
                    <input
                      type="text"
                      value={customer.last_name}
                      onChange={handleFieldChange('last_name')}
                    />
                  </td>
                  <td>
                    <input
                      type="text"
                      value={customer.address}
                      onChange={handleFieldChange('address')}
                    />
                  </td>
                  <td>
                    <input
                      type="text"
                      value={customer.city}
                      onChange={handleFieldChange('city')}
                    />
                  </td>
                  <td>
                    <input
                      type="text"
                      value={customer.state}
                      onChange={handleFieldChange('state')}
                    />
                  </td>
                  <td>
                    <input
                      type="text"
                      value={customer.zipcode}
                      onChange={handleFieldChange('zipcode')}
                    />
                  </td>
                </tr>
              </thead>
            </table>
          ) : (
            <table>
              <thead>
                <tr>
                  <td>{customer.first_name}</td>
                  <td>{customer.last_name}</td>
                  <td>{customer.address}</td>
                  <td>{customer.city}</td>
                  <td>{customer.state}</td>
                  <td>{customer.zipcode}</td>
                </tr>
              </thead>
            </table>
          )}
          <button onClick={saveButtonOnClick}>{editMode ? 'Save' : 'Edit'}</button>
          
        </>
      )}
    </>            
        </div>
    )
}


export default Details