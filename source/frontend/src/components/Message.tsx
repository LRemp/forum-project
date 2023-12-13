import { Avatar, Box, Flex, Grid, Text } from '@radix-ui/themes'
import React from 'react'

interface IMessage {
    id: number,
    text: string,
    created: string,
    author: Author
}

function Message({ id, text, created, author } : IMessage) {
  return (
    <Box className='bg-paynesgray text-white w-[98%] p-3 m-2 rounded-sm drop-shadow-sm'>
        <Flex>
            <div className='bg-coral w-10 h-10 rounded-full grid text-black'>
                <span className='m-auto font-medium'>{author.username[0].toUpperCase()}</span>
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