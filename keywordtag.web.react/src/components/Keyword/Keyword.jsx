import { useState } from 'react';
import { TextField, Button } from '@mui/material'
import styles from './Keyword.module.scss'

function Keyword(props) {

    return (
        <div className={styles["container"]}>
            <div className={styles["keyword"]}>{props?.value?.name}</div>
            <div className={styles["online"]}>{props?.value?.online} online</div>
            <Button className={styles["button"]}>Checkin</Button>
        </div >
    )
}

export default Keyword;
