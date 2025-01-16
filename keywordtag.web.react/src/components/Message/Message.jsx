import { useState } from 'react'
import { TextField } from '@mui/material'
import styles from './Message.module.scss'

function Message(props) {

    return (
        <>
            <div className={styles["text"]}>{props?.value?.name}</div>
        </>
    )
}

export default Message
