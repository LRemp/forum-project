import { useNavigate } from 'react-router-dom'
import { ThickArrowLeftIcon } from '@radix-ui/react-icons'
import { Flex, Text } from '@radix-ui/themes'

interface IBackButton {
    link: string,
    label: string
}

function BackButton({ link, label } : IBackButton) {
  const navigate = useNavigate()
  const open = () => navigate(link)
  return (
    <div onClick={open} className={'my-4 cursor-pointer py-1 px-3 text-lg rounded-sm drop-shadow-md bg-gunmetal font-medium text-white flex'}>
      <Flex p={"1"} className='m-auto'>
        <ThickArrowLeftIcon width={'22'} height={'22'} />
        <Text size={"3"}>{label}</Text>
      </Flex>
    </div>
  )
}

export default BackButton