import { useState, useMemo, useCallback } from 'react'
import { useDispatch } from 'react-redux'
import { TextField, Button } from '@mui/material'
import styles from './MessageFilter.module.scss'

import GetMessages from '../../api/message/GetMessages.api'

import {
    updateListMessage,
} from '../../stores/slices/AppSlice'

function MessageFilter(props) {
    const dispatch = useDispatch();

    const [messageFilter, setMessageFilter] = useState("")
    function onFilterChanged($event) {
        setMessageFilter($event.currentTarget.value)
    }

    function onSearchClick($event) {
        var model = {
            filter: messageFilter,
        }
        GetMessages(model).then((response) => {
            if (response.data.code === 200) {
                var messages = response.data.value.messages;
                dispatch(updateListMessage(messages));
            }
        });
    }

    return (
        <div className={styles["container"]}>
            <TextField
                className={styles["message-filter"]}
                value={messageFilter}
                onChange={onFilterChanged}
            />
            <Button
                className={styles["message-button"]}
                onClick={onSearchClick }
            >
                Tìm kiếm
            </Button>
        </div>
    )
}

export default MessageFilter
