import axios from 'axios'
import { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { useSignIn } from 'react-auth-kit'

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
          if(signIn(
            {
                token: res.data.token,
                expiresIn: 10,
                tokenType: "Bearer",
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
    <div>
      <form onSubmit={onSubmit}>
        <p>Username</p>
        <input type={"text"} onChange={(e)=>setFormData({...formData, username: e.target.value})} />
        <p>Password</p>
        <input type={"password"} onChange={(e)=>setFormData({...formData, password: e.target.value})} />

        <button>Login</button>
      </form>
      <p>response:</p>
      <p>{result}</p>
    </div>
  )
}

export default Login