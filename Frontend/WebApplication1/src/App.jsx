import './App.css'
import { Routes, Route, BrowserRouter } from 'react-router-dom'
import Homepage from './pages/HomePage'

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Homepage />}></Route>
        </Routes>
      </BrowserRouter>
    </>
  )

}

export default App
