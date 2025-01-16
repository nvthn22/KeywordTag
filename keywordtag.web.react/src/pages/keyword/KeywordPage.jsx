import { useEffect, useState } from 'react'
import { Stack, Divider, Button } from '@mui/material'
import Keyword from '../../components/Keyword/Keyword'
import KeywordInput from '../../components/KeywordInput/KeywordInput'
import Message from '../../components/Message/Message'
import styles from './KeywordPage.module.scss'
import MessageFilter from '../../components/MessageFilter/MessageFilter'

import GetMessages from '../../api/message/GetMessages.api'
import GetTopKeyword from '../../api/keyword/GetTopKeyword.api'

import { useDispatch, useSelector } from 'react-redux'
import {
    updateTopKeyword,
    updateListMessage,
    updateMyKeywords
} from '../../stores/slices/AppSlide'

function KeywordPage(props) {
    const dispatch = useDispatch();

    // Tải top keyword
    function onRefreshClick($event) {
        GetTopKeyword().then((response) => {
            if (response.data.code === 200) {
                var keywords = [response.data.value]
                dispatch(updateTopKeyword(keywords))
            }
        });
    }

    // Tải messages
    useEffect(() => {
        var model = {
            filter: "",
        }
        GetMessages(model).then((response) => {
            if (response.data.code === 200) {
                var messages = response.data.value.messages;
                dispatch(updateListMessage(messages));
            }
        });
    }, [])
    // End tải messages

    // Tải keyword
    useEffect(() => {
        const messages = [{
            code: "1",
            name: "abc 1",
            online: 1,
        }, {
            code: "2",
            name: "abc 2",
            online: 1,
        }, {
            code: "3",
            name: "abc 3",
            online: 2,
        },]
        dispatch(updateMyKeywords(messages));
    }, [])

    const defaultKeyword = {
        code: "0",
        name: "abc0",
        online: "10",
    }
    const topKeywords = useSelector(state => {
        return state.app.keyword.top
    });
    const test = useSelector(state => {
        return state.app.test
    });
    const messages = useSelector(state => {
        return state.app.message.list
    });

    const myKeywords = useSelector(state => {
        return state.app.keyword.list
    });

    return (
        <Stack direction="row" spacing={1} className={styles["container"]}>
            <Stack direction="column" spacing={2} className={styles["side-left"]}>
                <div className={styles["line-item"]}>
                    <div className={styles["top-keyword-text"]}>Top 1</div>
                    <Button
                        className={styles["top-keyword-refresh"]}
                        onClick={onRefreshClick}>
                        Làm mới
                    </Button>
                </div>

                <Stack direction="column" spacing={2}>
                    {topKeywords.map(k => <Keyword key={k.code} value={k} />)}
                </Stack>

                <div className={styles["custom-keyword-text"]}>Danh sách</div>
                <KeywordInput></KeywordInput>

                <Stack direction="column" spacing={2}>
                    {myKeywords.map(k => <Keyword key={k.code} value={k} />)}
                </Stack>

            </Stack>

            {<Divider orientation="vertical" flexItem className={styles["divider"]} />}

            <Stack direction="column" spacing={2} className={styles["side-right"]}>
                <div className={styles["line-item"]}>
                    <MessageFilter />
                </div>
                <div className={styles["message-buttons"]}>
                    <div>Mô tả</div>
                    <Button className={styles["tag-button"]}>Tag</Button>
                </div>

                <Stack direction="column" spacing={2}>
                    {messages.map(m => <Message key={m.code} value={m} />)}
                </Stack>

            </Stack>
        </Stack>
    )
}

export default KeywordPage;
