const AppState = {
    user: {
        email: "",
        id: null,
        logged: false,
        listKeywords: "",
        listKeywordsTag: "",
    },
    keyword: {
        top: [],
        input: "",
        selected: null,
        checkin: null,
        list: [],
    },
    message: {
        filter: "",
        list: [],
        selected: null,
    },
    test: "test 123"
}

export { AppState }
