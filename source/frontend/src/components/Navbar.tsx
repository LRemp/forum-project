import { Avatar, Box, Button, Flex, Text } from "@radix-ui/themes"
import { useState, useRef, useEffect } from "react"
import { useAuthUser, useIsAuthenticated, useSignOut } from "react-auth-kit"
import { Link } from "react-router-dom"
import logo from "../assets/logo.png"

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
    const isAuthenticated = useIsAuthenticated()
    const signOut = useSignOut()
    const auth = useAuthUser()

    // Replace javascript:void(0) path with your path
    /*const navigation = [
        { title: "Customers", path: "javascript:void(0)" },
    ]*/
    return (
        <nav className="bg-paynesgray border-b drop-shadow-md text-white">
            <div className="flex items-center space-x-8 py-3 px-4 max-w-screen-xl mx-auto md:px-8">
                <div className="flex-none lg:flex-initial">
                    <a href="javascript:void(0)">
                        <img
                            src={logo}
                            width={120} 
                            height={50}
                            alt="Float UI logo"
                        />
                    </a>
                </div>
                <div className="flex-1 flex items-center justify-end">
                    {isAuthenticated() ? (
                        <>
                            <button onClick={() => signOut()} className="py-1 px-3 text-sm rounded-md drop-shadow-md bg-gunmetal font-medium">
                                Log out
                            </button>
                            <Text className="mx-2" weight={"medium"}>{auth().username}</Text>
                            <div className='bg-coral w-10 h-10 rounded-full grid text-black'>
                                <span className='m-auto font-bold'>{auth().username[0].toUpperCase()}</span>
                            </div>
                        </>
                    ) : (
                        <Flex gap={"2"}>
                            <Link to={`/login`}>
                                <button className="py-1 px-3 text-sm rounded-md drop-shadow-md bg-silver text-black font-medium">
                                    Log in
                                </button>
                            </Link>
                            <Link to={`/register`}>
                                <button className="py-1 px-3 text-sm rounded-md drop-shadow-md bg-gunmetal font-medium">
                                    Sign up
                                </button>
                            </Link>
                        </Flex>
                    )}
                     
                </div>
            </div>
        </nav>
    )
}