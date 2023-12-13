import axios from 'axios'
import { useEffect, useState } from 'react'
import WithNavbar from '../components/WithNavbar'
import { Box, Container, Grid, Heading, Section, Text } from '@radix-ui/themes'
import ChannelCard from '../components/ChannelCard'
import { useIsAuthenticated } from 'react-auth-kit'
import RequestDialog from '../components/RequestDialog'

function Home() {
  const isAuthenticated = useIsAuthenticated()
  const [channels, setChannels] = useState<Array<Channel>>([

  ])
  const fetchChannels = () => {
    axios.get('/api/channels')
      .then(({ data } : { data: Array<Channel> | null }) => {
        console.log(data)
        data && setChannels(data)
      })
  }

  useEffect(() => {
    fetchChannels()
  }, [])
    
  return (
    <WithNavbar>
      <Container>
        <Section>
          {isAuthenticated() && <RequestDialog />}
          <Heading size="8">{isAuthenticated() ? (<>Hey, user!</>) : (<>Welcome to chathub!</>)}</Heading>
        </Section>

        

        <Heading color="cyan" size="4">Explore these channels:</Heading>
        <hr />
        <br />
        <Grid className='md:grid-cols-3 grid-cols-1' gap="4" width="auto">
          {channels.map((channel: Channel, index: number) => (
            <Box>
              <ChannelCard {...channel} key={index} />
            </Box>
          ))}
        </Grid>
      </Container>
    </WithNavbar>
  )
}

export default Home