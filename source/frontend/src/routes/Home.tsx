import axios from 'axios'
import { useEffect, useState } from 'react'
import WithNavbar from '../components/WithNavbar'
import { Box, Container, Grid, Heading, Section, Text } from '@radix-ui/themes'
import ChannelCard from '../components/ChannelCard'

function Home() {
  const [channels, setChannels] = useState<Array<Channel>>([])
  const fetchChannels = () => {
    axios.get('/api/channels')
      .then(({ data } : { data: Array<Channel> | null }) => {
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
          <Heading size="8">Hey, user!</Heading>
        </Section>

        <Heading color="cyan" size="4">Explore these channels:</Heading>
        <hr />
        <br />
        <Grid columns="3" gap="4" width="auto">
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