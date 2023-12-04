import { Avatar, Flex, Text } from "@radix-ui/themes"
import { useState, useRef, useEffect } from "react"

// Profile Dropdown
const ProfileDropDown = (props: any) => {

    const [state, setState] = useState(false)
    const profileRef = useRef()

    const navigation = [
        { title: "Dashboard", path: "javascript:void(0)" },
        { title: "Settings", path: "javascript:void(0)" },
        { title: "Log out", path: "javascript:void(0)" },
    ]

    
    useEffect(() => {
        const handleDropDown = (e: Event) => {
            if (!profileRef.current.contains(e.target)) setState(false)
        }
        document.addEventListener('click', handleDropDown)
    }, [])

    return (
        <div className={`relative ${props.class}`}>
            <div className="flex items-center space-x-4">
                <button ref={profileRef} className="w-10 h-10 outline-none rounded-full ring-offset-2 ring-gray-200 ring-2 lg:focus:ring-indigo-600"
                    onClick={() => setState(!state)}
                >
                    <img
                        src="https://randomuser.me/api/portraits/men/46.jpg"
                        className="w-full h-full rounded-full"
                    />
                </button>
                <div className="lg:hidden">
                    <span className="block">Micheal John</span>
                    <span className="block text-sm text-gray-500">john@gmail.com</span>
                </div>
            </div>
            <ul className={`bg-white top-12 right-0 mt-5 space-y-5 lg:absolute lg:border lg:rounded-md lg:text-sm lg:w-52 lg:shadow-md lg:space-y-0 lg:mt-0 ${state ? '' : 'lg:hidden'}`}>
                {
                    navigation.map((item, idx) => (
                        <li>
                            <a key={idx} className="block text-gray-600 lg:hover:bg-gray-50 lg:p-2.5" href={item.path}>
                                {item.title}
                            </a>
                        </li>
                    ))
                }
            </ul>
        </div>
    )
}

export default () => {

    const [menuState, setMenuState] = useState(false)

    // Replace javascript:void(0) path with your path
    /*const navigation = [
        { title: "Customers", path: "javascript:void(0)" },
    ]*/
    return (
        <nav className="bg-white border-b">
            <div className="flex items-center space-x-8 py-3 px-4 max-w-screen-xl mx-auto md:px-8">
                <div className="flex-none lg:flex-initial">
                    <a href="javascript:void(0)">
                        <img
                            src="https://www.floatui.com/logo.svg" 
                            width={120} 
                            height={50}
                            alt="Float UI logo"
                        />
                    </a>
                </div>
                <div className="flex-1 flex items-center justify-end">
                    <Flex gap={"1"} justify={"end"} align={"center"}>
                        <Text weight={"medium"}>Username</Text>
                        <Avatar
                            src="https://images.unsplash.com/photo-1502823403499-6ccfcf4fb453?&w=256&h=256&q=70&crop=focalpoint&fp-x=0.5&fp-y=0.3&fp-z=1&fit=crop"
                            fallback="A"
                            radius="full"
                        />  
                    </Flex>
                    <div className="flex-1 flex items-center justify-end space-x-2 sm:space-x-6">
                        
                    </div>
                </div>
            </div>
        </nav>
    )
}