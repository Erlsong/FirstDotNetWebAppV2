import './App.css'
import { Routes, Route } from 'react-router-dom'
import TestingStage from './components/TestingStage.jsx'
import UserCardGrid from './components/UserCardGrid.jsx'

function App() {
  return (
    <>
      <UserCardGrid />
      <TestingStage />
    </>
  )

}

export default App
