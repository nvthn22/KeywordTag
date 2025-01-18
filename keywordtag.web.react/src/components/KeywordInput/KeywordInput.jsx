import { useState, useRef } from 'react'
import { TextField, Button } from '@mui/material'
import styles from './KeywordInput.module.scss'
import { useDispatch, useSelector } from 'react-redux'

import AddKeyword from '../../api/keyword/AddKeyword.api'
import { updateUserListKeywords } from '../../stores/slices/AppSlice'

function KeywordInput(props) {
    var dispatch = useDispatch();
    const keywordInput = useRef();
    const listKeywords = useSelector(state => {
        return state.app.keyword.list
    })
    const userId = useSelector(state => state.app.user.id)


    var [keyword, setKeyword] = useState("")
    var [canAdd, setCanAdd] = useState(false)

    function onKeywordChange($event) {
        setKeyword($event.currentTarget.value)
        const included = listKeywords.filter(x => x.name === keyword);
        setCanAdd(keyword.length > 0 && included.length === 0);
    }

    function onAddClick() {
        const inputText = keywordInput.current.value;
        const included = listKeywords.filter(x => x.name === inputText);

        setCanAdd(included.length === 0)

        if (included.length === 0) {
            var model = {
                id: userId,
                name: inputText,
            }
            AddKeyword(model).then(response => {
                console.log(response);
                if (response.data.code === 200) {
                    var newKeywordIds = response.data.value.keywordIds;
                    dispatch(updateUserListKeywords(newKeywordIds));
                }
            });
        }
    }

    return (
        <div className={styles["container"]}>
            <TextField className={styles["keyword-input"]} value={keyword} onChange={onKeywordChange} inputRef={keywordInput}></TextField>
            <Button className={styles["add-button"]} onClick={onAddClick} disabled={!canAdd}>Add</Button>
        </div >
    )
}

export default KeywordInput
