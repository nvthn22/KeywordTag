import { configureStore } from '@reduxjs/toolkit';
import appReducer from './slices/AppSlide'

export const store = configureStore({
    reducer: {
        app: appReducer,
    }
})
