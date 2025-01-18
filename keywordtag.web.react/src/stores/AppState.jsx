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
        selectedId: "",
        checkinId: "",
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
