import { Heading, Text } from '@radix-ui/themes';
import React from 'react'
import { useNavigate } from 'react-router-dom';

interface IConversationCard {
    id: number;
    channelId: number;
    name: string;
    description: string;
}

function ConversationCard({ id, channelId, name, description }: IConversationCard) {
  const navigate = useNavigate()
  const openConversation = () => {
    navigate(`/channel/${channelId}/conversation/${id}`)
  }
    
  return (
    <div className='drop-shadow-md bg-gray-100 rounded-md p-5 hover:bg-gray-300 transition cursor-pointer' onClick={openConversation}>
      <Heading size="5">{name}</Heading>
      <Text>{description}</Text>
    </div>
  )
}

export default ConversationCard