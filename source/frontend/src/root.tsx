import { Theme } from '@radix-ui/themes'
import { createBrowserRouter, RouterProvider } from "react-router-dom"
import Home from './routes/Home'
import Login from './routes/Login';
import Register from './routes/Register';
import Channel from './routes/Channel';
import Conversation from './routes/Conversation';
import { Toaster } from 'react-hot-toast';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
  },
  {
    path: "/login",
    element: <Login />,
  },
  {
    path: "/register",
    element: <Register />,
  },
  {
    path: "/channel/:channelId",
    element: <Channel />,
  },
  {
    path: "/channel/:channelId/conversation/:conversationId",
    element: <Conversation />,
  },
]);

export default function () {
  return (
    <Theme className=''>
      <Toaster />
      <RouterProvider router={router} />
    </Theme>
  );
}