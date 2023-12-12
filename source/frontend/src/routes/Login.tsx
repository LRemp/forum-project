import axios from 'axios'
import { useState } from 'react'
import { Link, useNavigate } from "react-router-dom";
import { useSignIn } from 'react-auth-kit'
import logo from "../assets/logo.png"

function Login() {
  const signIn = useSignIn()
  const navigate = useNavigate();
  const [result, setResult] = useState<String>("")
  const [formData, setFormData] = useState({ username: '', password: '' })
 
  const onSubmit = (e: any) => {
    e.preventDefault()
    axios.post('/api/users/login', formData)
      .then((res: any) => {
        if(res.status = 200) {
          setResult(JSON.stringify(res))
          console.log('login')
          if(signIn(
            {
                token: res.data.token,
                expiresIn: 10,
                tokenType: "Bearer",
                authState: {
                  username: res.data.username
                }
                //refreshToken: res.data.refreshToken,
                //refreshTokenExpireIn: 24 * 60
            }
          )){
            navigate("/");
          }else {
            console.log('error')
          }
        }
      })
  }

  return (
    <main className="w-full h-screen flex flex-col items-center justify-center px-4">
        <div className="max-w-sm w-full text-gray-600">
            <div className="text-center">
                <img src={logo} width={150} className="mx-auto" />
                <div className="mt-5 space-y-2">
                    <h3 className="text-gray-800 text-2xl font-bold sm:text-3xl">Log in to your account</h3>
                    <p className="">Don't have an account? <Link to={`/register`} className="font-medium text-paynesgray hover:text-gunmetal">Sign up</Link></p>
                </div>
            </div>
            <form
                onSubmit={onSubmit}
                className="mt-8 space-y-5"
            >
                <div>
                    <label className="font-medium">
                        Username
                    </label>
                    <input
                        type="text"
                        required
                        className="w-full mt-2 px-3 py-2 text-gray-500 bg-transparent outline-none border focus:border-gunmetal shadow-sm rounded-lg"
                        onChange={(e)=>setFormData({...formData, username: e.target.value})}
                    />
                </div>
                <div>
                    <label className="font-medium">
                        Password
                    </label>
                    <input
                        type="password"
                        required
                        className="w-full mt-2 px-3 py-2 text-gray-500 bg-transparent outline-none border focus:border-gunmetal shadow-sm rounded-lg"
                        onChange={(e)=>setFormData({...formData, password: e.target.value})}
                    />
                </div>
                <button
                    className="w-full px-4 py-2 text-white font-medium bg-paynesgray hover:bg-gunmetal active:bg-coral rounded-lg duration-150"
                >
                    Sign in
                </button>
            </form>
        </div>
    </main>
  )
}

export default Login