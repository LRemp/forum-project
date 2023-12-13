import axios from 'axios'
import { useEffect, useState } from 'react'
import WithNavbar from '../components/WithNavbar'
import { Box, Container, Grid, Heading, Section, Text } from '@radix-ui/themes'
import ChannelCard from '../components/ChannelCard'
import { useAuthHeader, useIsAuthenticated } from 'react-auth-kit'
import RequestDialog from '../components/RequestDialog'
import AdminRequestDialog from '../components/AdminRequestDialog'

function Admin() {
  const isAuthenticated = useIsAuthenticated()
  const authHeader = useAuthHeader()
  const [requests, setRequests] = useState<Array<Channel>>([

  ])
  const fetchRequests = () => {
    axios.get('/api/channels/requests', {
        headers: { "Authorization" : authHeader() },
    })
      .then(({ data } : { data: Array<Channel> | null }) => {
        data && setRequests(data)
      })
  }

  useEffect(() => {
    fetchRequests()
  }, [])
    
  return (
    <WithNavbar>
      <Container>
        <br />
        <br />
        <Heading color="cyan" size="4">New channel requests:</Heading>
        <hr />
        <br />
        <Grid className='md:grid-cols-3 grid-cols-1' gap="4" width="auto">
          {requests.map((channel: Channel, index: number) => (
            <AdminRequestDialog {...channel} key={index} update={fetchRequests} />

          ))}
        </Grid>
      </Container>
    </WithNavbar>
  )
}

export default Admin