import React from 'react'
import Navbar from './Navbar'

function WithNavbar({ children } : { children: React.ReactNode }) {
  return (
    <div>
        <Navbar />
        <div className='max-w-screen-xl m-auto px-4'>
            {children}
        </div>
    </div>
  )
}

export default WithNavbar