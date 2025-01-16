import { useState } from 'react'
import { TextField, Button } from '@mui/material'
import styles from './KeywordInput.module.scss'

function KeywordInput(props) {

    return (
        <div className={styles["container"]}>
            <TextField className={styles["keyword-input"]}></TextField>
            <Button className={styles["add-button"]}>Add</Button>
        </div>
    )
}

export default KeywordInput
