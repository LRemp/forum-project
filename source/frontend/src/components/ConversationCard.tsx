import { Heading, Text } from '@radix-ui/themes';
import React from 'react'
import { useNavigate } from 'react-router-dom';

interface IConversationCard {
    id: number;
    channelId: string | undefined;
    name: string;
    description: string;
}

function ConversationCard({ id, channelId, name, description }: IConversationCard) {
  const navigate = useNavigate()
  const openConversation = () => {
    navigate(`/channel/${channelId}/conversation/${id}`)
  }
    
  return (
    <div className='drop-shadow-md bg-paynesgray text-white rounded-sm p-5 hover:bg-gray-800 transition cursor-pointer' onClick={openConversation}>
      <Heading size="5">{name}</Heading>
      <Text>{description}</Text>
    </div>
  )
}

export default ConversationCard