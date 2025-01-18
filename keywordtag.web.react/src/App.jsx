import { BrowserRouter, Routes, Route } from 'react-router-dom'
import './App.css'
import LoginPage from './pages/login/LoginPage'
import KeywordPage from './pages/keyword/KeywordPage'
import ErrorBoundary from './pages/error/ErrorBoundary'
import AppInitial from './pages/initial/AppInitial'

import { Provider } from 'react-redux'
import { store } from './stores/AppStore'

function App() {

    return (
        <>
            <Provider store={store}>
                <AppInitial />
                <BrowserRouter>
                    <Routes>
                        <Route path="/" element={<LoginPage />} />
                        <Route path="/main" element={<KeywordPage />} />
                    </Routes>
                </BrowserRouter>
            </Provider>
        </>
    )
}

export default App
