import { useDispatch } from 'react-redux'
import { updateLoginStatus } from './slices/AppSlide'

function Initial() {
    var dispatch = useDispatch();

    //Kiểm tra nếu người dùng đã đăng nhập, có mã userId và email ở local
    var id = localStorage.getItem("id");
    var email = localStorage.getItem("email");
    var listKeywords = localStorage.getItem("listKeywords");
    var listKeywordsTag = localStorage.getItem("listKeywordsTag");


    if (id === null || email === null) {
        var nologin = {
            email: "",
            id: null,
            logged: false,
            listKeywords: ";",
            listKeywordsTag: ";",
        }
        dispatch(updateLoginStatus(nologin))
    } else {
        var haslogin = {
            logged: true,
            id: id,
            email: email,
            listKeywords: listKeywords,
            listKeywordsTag: listKeywordsTag,
        }
        dispatch(updateLoginStatus(haslogin))
    }
    // End kiểm tra đăng nhập
}

function saveLoginStatus(model) {
    localStorage.setItem("id", model.id);
    localStorage.setItem("email", model.email);
}

function saveUserStatus(model) {
    localStorage.setItem("id", model.id);
    localStorage.setItem("email", model.email);
    localStorage.setItem("listKeywords", model.listKeywords);
    localStorage.setItem("listKeywordsTag", model.listKeywordsTag);
}

export {
    Initial,
    saveLoginStatus,
    saveUserStatus
}
