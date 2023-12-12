import { Heading, Text } from '@radix-ui/themes';
import React from 'react'
import { useNavigate } from 'react-router-dom';

interface IChannelCard {
    id: number;
    name: string;
    description: string;
}

function ChannelCard({ id, name, description }: IChannelCard) {
  const navigate = useNavigate()
  const openChannel = () => {
    navigate(`/channel/${id}`)
  }
    
  return (
    <div className='drop-shadow-md bg-paynesgray text-white rounded-md p-5 hover:bg-gray-800 transition cursor-pointer' onClick={openChannel}>
      <Heading size="5">{name}</Heading>
      <Text>{description}</Text>
    </div>
  )
}

export default ChannelCard