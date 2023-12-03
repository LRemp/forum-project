import axios from 'axios'
import { useEffect, useState } from 'react'
import WithNavbar from '../components/WithNavbar'

function Home() {
  const [channels, setChannels] = useState([])
  const fetchChannels = () => {
    axios.get('/api/channels')
      .then((res: any) => {
        console.log(res)
        setChannels(res.data)
      })
  }

  useEffect(() => {
    fetchChannels()
  }, [])
    
  return (
    <WithNavbar>
      <div>
        Channels:

      </div>
    </WithNavbar>
  )
}

export default Home