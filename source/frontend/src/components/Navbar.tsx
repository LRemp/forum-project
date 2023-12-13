import { Avatar, Box, Button, Flex, Text } from "@radix-ui/themes"
import { useState, useRef, useEffect } from "react"
import { useAuthUser, useIsAuthenticated, useSignOut } from "react-auth-kit"
import { Link } from "react-router-dom"
import logo from "../assets/logo.png"

{/*
export default () => {

    const [menuState, setMenuState] = useState(false)
    const isAuthenticated = useIsAuthenticated()
    const signOut = useSignOut()
    const auth = useAuthUser()

    return (
        <nav className="bg-paynesgray border-b drop-shadow-md text-white">
            <div className="flex items-center space-x-8 py-3 px-4 max-w-screen-xl mx-auto md:px-8">
                <div className="flex-none lg:flex-initial">
                    <Link to={'/'}>
                        <img
                            src={logo}
                            width={120} 
                            height={50}
                            alt="Float UI logo"
                        />
                    </Link>
                </div>
                <div className="flex-1 flex items-center justify-end">
                    {isAuthenticated() ? (
                        <>
                            <Link to={`/admin`}>
                                <button className="py-1 px-3 m-2 text-sm rounded-sm drop-shadow-md bg-coral text-black font-medium">
                                    Admin
                                </button>
                            </Link>
                            <button onClick={() => signOut()} className="py-1 px-3 text-sm rounded-sm drop-shadow-md bg-gunmetal font-medium">
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
                                <button className="py-1 px-3 text-sm rounded-sm drop-shadow-md bg-silver text-black font-medium">
                                    Log in
                                </button>
                            </Link>
                            <Link to={`/register`}>
                                <button className="py-1 px-3 text-sm rounded-sm drop-shadow-md bg-gunmetal font-medium">
                                    Sign up
                                </button>
                            </Link>
                        </Flex>
                    )}
                     
                </div>
            </div>
        </nav>
    )
}*/}

export default () => {

    const [state, setState] = useState(false)

    const isAuthenticated = useIsAuthenticated()
    const signOut = useSignOut()
    const auth = useAuthUser()

    useEffect(() => {
        document.onclick = (e) => {
            const target = e.target;
            if (!target.closest(".menu-btn")) setState(false);
        };
    }, [])

    return (
        <nav className={`bg-white pb-5 md:text-sm ${state ? "shadow-lg rounded-xl border mx-2 mt-2 md:shadow-none md:border-none md:mx-2 md:mt-0" : ""}`}>
            <div className="gap-x-14 items-center max-w-screen-xl mx-auto px-4 md:flex md:px-8">
                <div className="flex items-center justify-between py-5 md:block">
                    <Link to={'/'}>
                        <img
                            src={logo}
                            width={120} 
                            height={50}
                            alt="Float UI logo"
                        />
                    </Link>
                    <div className="md:hidden">
                        <button className="menu-btn text-gray-500 hover:text-gray-800"
                            onClick={() => setState(!state)}
                        >
                            {
                                state ? (
                                    <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" viewBox="0 0 20 20" fill="currentColor">
                                        <path fillRule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clipRule="evenodd" />
                                    </svg>
                                ) : (
                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6">
                                        <path strokeLinecap="round" strokeLinejoin="round" d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
                                    </svg>
                                )
                            }
                        </button>
                    </div>
                </div>
                <div className={`flex-1 items-center mt-8 md:mt-0 md:flex ${state ? 'block' : 'hidden'} `}>
                    {isAuthenticated() ? (
                        <>
                            <div className="flex-1 gap-x-1 items-center justify-end mt-6 space-y-6 md:flex md:space-y-0 md:mt-0">
                                <Link to={`/admin`}>
                                    <button className="py-1 px-3 m-2 text-sm rounded-sm drop-shadow-md bg-coral text-black font-medium">
                                        Admin
                                    </button>
                                </Link>
                                <button onClick={() => signOut()} className="py-1 px-3 text-sm rounded-sm drop-shadow-md bg-gunmetal font-medium text-white">
                                    Log out
                                </button>
                                <Text className="mx-2" weight={"medium"}>{auth().username}</Text>
                                <div className='bg-coral w-10 h-10 rounded-full grid text-black'>
                                    <span className='m-auto font-bold'>{auth().username[0].toUpperCase()}</span>
                                </div>
                            </div>
                        </>
                    ) : (
                        <>
                            <div className="flex-1 gap-x-6 items-center justify-end mt-6 space-y-6 md:flex md:space-y-0 md:mt-0">
                                <Link to={'/login'} className="flex items-center justify-center gap-x-1 py-2 px-4 text-white font-medium bg-gray-600 hover:bg-gray-900 active:bg-coral rounded-md md:inline-flex">
                                    Log in
                                </Link>
                                <Link to={'/register'} className="flex items-center justify-center gap-x-1 py-2 px-4 text-white font-medium bg-gunmetal hover:bg-gray-900 active:bg-coral rounded-md md:inline-flex">
                                    Sign in
                                </Link>
                            </div>
                        </>

                    )}
                </div>
            </div>
        </nav>
    )
}