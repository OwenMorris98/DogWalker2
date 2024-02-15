
import './App.css'
//import { Link } from "react-router-dom"
import { postCustomer } from './hooks/postCustomer';

function Register() {
    
    const {inputs, handleChange, handleSubmit} = postCustomer();
    
    return(
        <section>
        <h2 className='text-center'>post request</h2>
        <form className='form' onSubmit={handleSubmit}>
          <div className='form-row'>
            <label htmlFor='name' className='form-label'>
              First Name
            </label>
            <input
              type='text'
              className='form-input'
              name='firstName'
              value={inputs.firstName || ""}
              onChange={handleChange}
            />
          </div>
          <div className='form-row'>
            <label htmlFor='lastName' className='form-label'>
              Last Name
            </label>
            <input
              type='text'
              className='form-input'
              id='last-name'
              name='lastName'
              value={inputs.lastName || ""}
              onChange={handleChange}
            />
          </div>
          <div className='form-row'>
            <label htmlFor='address' className='form-label'>
              Address
            </label>
            <input
              type='text'
              className='form-input'
              id='address'
              name='address'
              value={inputs.address || ""}
              onChange={handleChange}
            />
          </div>
          <div className='form-row'>
            <label htmlFor='city' className='form-label'>
              City
            </label>
            <input
              type='text'
              className='form-input'
              id='city'
              name='city'
              value={inputs.city || ""}
              onChange={handleChange}
            />
          </div>
          <div className='form-row'>
            <label htmlFor='state' className='form-label'>
              State
            </label>
            <input
              type='text'
              className='form-input'
              id='state'
              name='state'
              value={inputs.state || ""}
              onChange={handleChange}
            />
          </div>
          <div className='form-row'>
            <label htmlFor='zipcode' className='form-label'>
              Address
            </label>
            <input
              type='text'
              className='form-input'
              id='zipcode'
              name='zipcode'
              value={inputs.zipcode || ""}
              onChange={handleChange}
            />
          </div>
          <button type='submit' className='btn btn-block'>
            register
          </button>
        </form>
      </section>
    )
}

export default Register
