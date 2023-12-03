import { Theme } from '@radix-ui/themes'
import { createBrowserRouter, RouterProvider } from "react-router-dom"
import Home from './routes/Home'
import Login from './routes/Login';
import Register from './routes/Register';
import Channel from './routes/Channel';

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
]);

export default function () {
  return (
    <Theme>
      <RouterProvider router={router} />
    </Theme>
  );
}