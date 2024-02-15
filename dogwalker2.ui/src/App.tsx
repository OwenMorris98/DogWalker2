
import './App.css'
import { useListState } from './hooks/useListState'
import { Link } from "react-router-dom"

function App() {
  // const [count, setCount] = useState(0)

  const {customerList} = useListState()

  return (
    <>
      <ul>
        {customerList.map((customers) => (
          <li key={customers.id}>{customers.last_name}, {customers.first_name}
           <>
          <Link to={`/Details/${customers.id}`}>Details</Link>
          </>
          </li>
         
        ))}
      </ul>
          <Link className='button' to='/Register'>Register Customer</Link>

     
    </>
  )
}

export default App
