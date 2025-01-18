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
    saveLoginStatus,
    saveUserStatus
}
