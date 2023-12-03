import React from 'react'
import Navbar from './Navbar'

function WithNavbar({ children } : { children: React.ReactNode }) {
  return (
    <div>
        <Navbar />
        {children}
    </div>
  )
}

export default WithNavbar