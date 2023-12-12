import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import WithNavbar from '../components/WithNavbar'
import { Box, Container, Grid, Heading } from '@radix-ui/themes'
import BackButton from '../components/BackButton'
import axios from 'axios'
import ConversationCard from '../components/ConversationCard'

function Channel() {
  const { channelId } = useParams()
  const [conversations, setConversations] = useState<Array<Conversation>>([
    {
      "id": 1,
      "name": "Postman testing",
      "description": "Running postman tests",
    }
  ])
  const fetchConversations = () => {
    axios.get(`/api/channels/${channelId}/conversations`)
      .then(({ data } : { data: Array<Conversation> | null }) => {
        data && setConversations(data)
      })
  }

  useEffect(() => {
    fetchConversations()
  }, [])

  return (
    <WithNavbar>
      <Container>
        <BackButton link={`/`} label={'Back to channels'} />
        <br />
        <br />
        <Heading size="6">Join a disccussion in those conversations:</Heading>
        <hr />
        <br />
        <Grid columns="3" gap="4" width="auto">
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