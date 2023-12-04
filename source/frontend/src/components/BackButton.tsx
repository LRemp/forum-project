import { useNavigate } from 'react-router-dom'
import { ArrowLeftIcon } from '@radix-ui/react-icons'
import { Flex, Text } from '@radix-ui/themes'

interface IBackButton {
    link: string,
    label: string
}

function BackButton({ link, label } : IBackButton) {
  const navigate = useNavigate()
  const open = () => navigate(link)
    return (
    <div onClick={open} className={'cursor-pointer'}>
        <Flex p={"3"}>
            <ArrowLeftIcon width={'22'} height={'22'} />
            <Text size={"3"}>{label}</Text>
        </Flex>
    </div>
  )
}

export default BackButton