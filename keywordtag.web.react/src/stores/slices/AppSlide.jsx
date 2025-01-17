import { createSlice } from '@reduxjs/toolkit'
import { AppState } from '../AppState'

const appSlice = createSlice({
    name: 'app',
    initialState: AppState,
    reducers: {
        updateTopKeyword: (state, action) => {
            state.keyword.top = action.payload;
        },
        updateListMessage: (state, action) => {
            state.message.list = action.payload;
        },
        updateMyKeywords: (state, action) => {
            state.keyword.list = action.payload;
        },

        updateUserEmail: (state, action) => {
            state.user.email = action.payload
        },
        updateLoginStatus: (state, action) => {
            state.user = action.payload;
        }
    }
})

export const {
    updateTopKeyword,
    updateListMessage,
    updateMyKeywords,
    updateLoginStatus,
    updateUserEmail,
} = appSlice.actions;

export default appSlice.reducer;
