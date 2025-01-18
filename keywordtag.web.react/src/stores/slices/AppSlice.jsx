import { createSlice } from '@reduxjs/toolkit'
import { AppState } from '../AppState'

const appSlice = createSlice({
    name: 'app',
    initialState: AppState,
    reducers: {
        updateTopKeyword: (state, action) => {
            state.keyword.top = action.payload;
        },
        updateMyKeywords: (state, action) => {
            state.keyword.list = action.payload;
        },

        updateListMessage: (state, action) => {
            state.message.list = action.payload;
        },

        updateUserEmail: (state, action) => {
            state.user.email = action.payload;
            localStorage.setItem("email", action.payload.email);
        },
        updateLoginStatus: (state, action) => {
            state.user = action.payload;
            localStorage.setItem("id", action.payload.id);
            localStorage.setItem("email", action.payload.email);
            localStorage.setItem("listKeywords", action.payload.listKeywords);
            localStorage.setItem("listKeywordsTag", action.payload.listKeywordsTag);
        },
        updateUserListKeywords: (state, action) => {
            state.user.listKeywords = action.payload;
            localStorage.setItem("listKeywords", action.payload);
        }
    }
})
export const {
    updateTopKeyword,
    updateMyKeywords,

    updateListMessage,

    updateUserEmail,
    updateLoginStatus,
    updateUserListKeywords,
} = appSlice.actions;

export default appSlice.reducer;
