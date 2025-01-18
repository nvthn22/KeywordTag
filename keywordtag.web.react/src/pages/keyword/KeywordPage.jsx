import { useEffect, useState } from 'react'
import { Stack, Divider, Button } from '@mui/material'
import Keyword from '../../components/Keyword/Keyword'
import KeywordInput from '../../components/KeywordInput/KeywordInput'
import Message from '../../components/Message/Message'
import styles from './KeywordPage.module.scss'
import MessageFilter from '../../components/MessageFilter/MessageFilter'

import GetMessages from '../../api/message/GetMessages.api'
import GetTopKeywords from '../../api/keyword/GetTopKeywords.api'
import GetUserKeywords from '../../api/keyword/GetUserKeywords.api'

import { useDispatch, useSelector } from 'react-redux'
import {
    updateTopKeyword,
    updateListMessage,
    updateMyKeywords
} from '../../stores/slices/AppSlice'

function KeywordPage(props) {
    const dispatch = useDispatch();

    const topKeywords = useSelector(state => state.app.keyword.top);
    const userKeywordIds = useSelector(state => {
        return state.app.user.listKeywords
    });
    const messages = useSelector(state => state.app.message.list);
    const myKeywords = useSelector(state => state.app.keyword.list);

    const test = useSelector(state => {
        return state.app.test
    });

    // Tải top keyword
    function onRefreshClick($event) {
        GetTopKeywords().then((response) => {
            if (response.data.code === 200) {
                var keywords = response.data.value
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

    // Tải keyword của người dùng
    useEffect(() => {
        var model = {
            keywordIds: userKeywordIds
        }

        GetUserKeywords(model).then((response) => {
            if (response.data.code === 200) {
                var userKeywords = response.data.value.keywords
                dispatch(updateMyKeywords(userKeywords));
            }
        });
    }, [userKeywordIds])

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
