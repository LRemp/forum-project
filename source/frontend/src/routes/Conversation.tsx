import React, { ChangeEvent, ChangeEventHandler, ReactNode, useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router-dom'
import WithNavbar from '../components/WithNavbar'
import { Box, Container, Grid, Heading, IconButton, ScrollArea, Text, TextField } from '@radix-ui/themes'
import BackButton from '../components/BackButton'
import ConversationCard from '../components/ConversationCard'
import Message from '../components/Message'
import axios from 'axios'
import { ArrowRightIcon, PaperPlaneIcon } from '@radix-ui/react-icons'
import { useAuthHeader, useIsAuthenticated } from 'react-auth-kit'

function Conversation({}) {
  const isAuthenticated = useIsAuthenticated()
  const authHeader = useAuthHeader()
  const ref = useRef()
  const [inputValue, setInputValue] = useState<string | undefined>(undefined)
  const { channelId, conversationId } = useParams()
  const [messages, setMessages] = useState<Array<Message>>([
    {
      "id": 1,
      "text": "Hi there",
      "created": "2023-11-29T11:50:45"
    }
  ])

  const fetchChats = async () => {
    await axios.get(`/api/channels/${channelId}/conversations/${conversationId}/messages`)
      .then(({ data } : { data: Array<Message> | null }) => {
        console.log(data)
        data && setMessages(data)
      })
  }

  const scrollToBottom = () => {
    ref.current.scrollTo(
    {
      top: ref.current.scrollHeight,
      behaviour: 'auto'
    })
  }

  useEffect(() => {
    fetchChats()
    scrollToBottom()
  }, [])

  const updateInput = (e: ChangeEvent) => setInputValue(e.target.value);

  const sendMessage = (e: any) => {
    e.preventDefault()
    if(!inputValue || inputValue == "") return
    console.log(inputValue)
    setInputValue("")
    
    axios.post(`/api/channels/${channelId}/conversations/${conversationId}/messages`, { text: inputValue }, {
      headers: { "Authorization" : authHeader() },
    })
      .then(async (res) => {
        await fetchChats()
        scrollToBottom()
      })
  }

  return (
    <WithNavbar>
      <Container>
        <BackButton link={`/channel/${channelId}`} label={'Back to conversations'} />
        <br />
        <br />
        <ScrollArea type="always" scrollbars="vertical" style={{ height: "70vh" }} ref={ref}>
          {messages.map((message, index) => (
            <Message key={index} {...message} />
          ))}
        </ScrollArea>
        <form onSubmit={sendMessage}>
          {isAuthenticated() ? (
            <div>
              <div className="relative mt-2">
                <button className='bg-coral flex text-white w-8 h-8 rounded-sm drop-shadow-md absolute right-3 inset-y-0 my-auto'>
                  <PaperPlaneIcon width="18" height="18" className='m-auto' />
                </button>
                  <input
                    type={"text"}
                    value={inputValue}
                    onChange={updateInput}
                    placeholder="Enter your message..."
                    className="w-full p-3 text-white bg-paynesgray outline-none border focus:border-coral shadow-sm rounded-lg"
                  />
              </div>
            {/*  <TextField.Root className='p-2'>
                <TextField.Input value={inputValue} onChange={updateInput} placeholder="Enter the message..." />
                <TextField.Slot>
                  <button className='bg-coral text-white p-2 rounded-sm drop-shadow-md'>

                    <PaperPlaneIcon width="18" height="18" />
                  </button>
                </TextField.Slot>
          </TextField.Root>*/}
            </div>
          ) : (
            <div className='text-center font-bold p-5 w-100 bg-gunmetal text-white rounded-md drop-shadow-md'>
              <Text>Log in to participate in the conversation!</Text>
            </div>
          )}
          
        </form>
      </Container>
    </WithNavbar>
  )
}

export default Conversation