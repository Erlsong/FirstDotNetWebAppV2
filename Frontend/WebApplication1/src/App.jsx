import './App.css'
import { Routes, Route, BrowserRouter, useNavigate } from 'react-router-dom'
import Homepage from './pages/HomePage'
import TestingStage from './pages/TestingStage'
import TestingNav from './components/TestingNav'
import LoginPage from './pages/LoginPage'
import RegisterPage from './pages/RegisterPage'
import UserPage from './pages/UserPage'

function App() {

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Homepage />}></Route>
          <Route path='/Testing' element={<TestingStage />}></Route>
          <Route path='/Login' element={<LoginPage />}></Route>
          <Route path='/Register' element={<RegisterPage />}></Route>
          <Route path='/user/:id' element={<UserPage />}></Route>
        </Routes>
      </BrowserRouter>
    </>
  )

}

export default App
