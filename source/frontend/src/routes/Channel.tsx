import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import WithNavbar from '../components/WithNavbar'
import { Box, Container, Grid, Heading, Text } from '@radix-ui/themes'
import BackButton from '../components/BackButton'
import axios from 'axios'
import ConversationCard from '../components/ConversationCard'
import { useIsAuthenticated } from 'react-auth-kit'
import ConversationDialog from '../components/ConversationDialog'

function Channel() {
  const { channelId } = useParams()
  const isAuthenticated = useIsAuthenticated()
  const [channelData, setChannelData] = useState({})
  const [conversations, setConversations] = useState<Array<Conversation>>([

  ])
  const fetchConversations = () => {
    axios.get(`/api/channels/${channelId}/conversations`)
      .then(({ data } : { data: Array<Conversation> | null }) => {
        data && setConversations(data)
      })
  }

  const getChannelInfo = () => {
    axios.get(`/api/channels/${channelId}`)
      .then(({ data } : { data: Object | null }) => {
        console.log(data)
        data && setChannelData(data)
      })
  }

  useEffect(() => {
    getChannelInfo()
    fetchConversations()
  }, [])

  return (
    <WithNavbar>
      <Container>
        <BackButton link={`/`} label={'Back to channels'} />
        <div>
          {isAuthenticated() && <ConversationDialog channelId={channelId} update={fetchConversations} />}
        </div>

        <Heading size="4">{channelData?.name}</Heading>
        <Text>{channelData?.description}</Text>

        <br />
        <br />
        <br />
        <Heading size="6">Join a disccussion in those conversations:</Heading>
        <hr />
        <br />
        <Grid className='md:grid-cols-3 grid-cols-1' gap="4" width="auto">
          {conversations.map((channel: Channel, index: number) => (
            <Box>
              <ConversationCard {...channel} channelId={channelId} key={index} />
            </Box>
          ))}
        </Grid>
      </Container>
    </WithNavbar>
  )
}

export default Channel