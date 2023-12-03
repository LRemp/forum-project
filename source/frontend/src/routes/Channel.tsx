import React from 'react'
import { useParams } from 'react-router-dom'
import WithNavbar from '../components/WithNavbar'

function Channel() {
  const { channelId } = useParams()
  return (
    <WithNavbar>
      <div>{channelId}</div>
    </WithNavbar>
  )
}

export default Channel