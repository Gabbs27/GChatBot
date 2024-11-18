import React from 'react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { Chat, SignIn, SignUp } from './pages';
import Footer from './components/Footer';

const router = createBrowserRouter([
  {
    path: "/",
    element: <SignIn />,
  },
  {
    path: "/signup",
    element: <SignUp />,
  },
  {
    path: "/chat",
    element: <Chat />,
  }
]);

function App() {
  return (
    <>
    <RouterProvider router={router} />
    <Footer/>
    </>
  );
}

export default App;