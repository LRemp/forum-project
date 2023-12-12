import { Avatar, Box, Flex, Grid, Text } from '@radix-ui/themes'
import React from 'react'

interface IMessage {
    id: number,
    text: string,
    created: string
}

function Message({ id, text, created } : IMessage) {
  return (
    <Box width="100%" className='bg-paynesgray text-white p-3 m-2 rounded-md drop-shadow-sm'>
        <Flex>
            <div className='bg-coral w-10 h-10 rounded-full grid text-black'>
                <span className='m-auto font-medium'>A</span>
            </div>
            <Grid className='px-2'>
                <Text size={"1"} className="font-bold">{new Date(created).toLocaleString()}</Text>
                <Text>{text}</Text>
            </Grid>
        </Flex>
    </Box>
  )
}

export default Message