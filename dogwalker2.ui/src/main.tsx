import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import App from './App.tsx'
import Register from './Register.tsx';
import Details from './Details.tsx'
import './index.css'

const router = createBrowserRouter([ 
  {
  path: '/App',
  element: <App />
  },
  {
    path: '/',
    element: <App />
    },
  {
  path: '/Register',
  element: <Register />
  },
  {
  path: '/Details/:customerId',
  element: <Details />
  }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
