
import './App.css'
import { useListState } from './hooks/useListState'
import { Link } from "react-router-dom"
import {
  AlertDialog,
  AlertDialogBody,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogContent,
  AlertDialogOverlay,
  AlertDialogCloseButton,
} from '@chakra-ui/react'

function App() {
  // const [count, setCount] = useState(0)

  const {customerList, handleDelete} = useListState()

  const { isOpen, onOpen, onClose } = useDisclosure()
  const cancelRef = React.useRef()

  return (
    <>
      <ul>
        {customerList.map((customers) => (
          <li key={customers.id}>{customers.last_name}, {customers.first_name}
           <>
          <Link to={`/Details/${customers.id}`}>Details</Link>
          </>
          <button onClick={() => handleDelete(customers.id)}>Delete</button>
          <Button colorScheme='red' onClick={onOpen}>
        Delete Customer
      </Button>
          </li>
         
        ))}
      </ul>
          <Link className='button' to='/Register'>Register Customer</Link>

     
    </>
  )
}

export default App
