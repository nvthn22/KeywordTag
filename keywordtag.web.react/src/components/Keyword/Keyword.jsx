import { useState, useEffect, useMemo } from 'react';
import { TextField, Button } from '@mui/material'
import styles from './Keyword.module.scss'
import { useDispatch, useSelector } from 'react-redux'
import {
    updateCheckinId,
    updateKeywordSelected,
    updateCheckinOnline
} from '../../stores/slices/AppSlice'
import Checkin from '../../api/checkin/Checkin.api'

function Keyword(props) {
    const dispatch = useDispatch();
    const globalCheckinId = useSelector(state => state.app.keyword.checkinId);
    const globalSelectedId = useSelector(state => state.app.keyword.selectedId);
    const userId = useSelector(state => state.app.user.id);

    const [selfCheckin, setSelfCheckin] = useState(false);
    useMemo(() => {
        const selfCode = props?.value?.code;
        const isCheckin = selfCode !== undefined &&
            globalCheckinId != undefined &&
            selfCode.toLowerCase() === globalCheckinId.toLowerCase();

        setSelfCheckin(isCheckin);
    }, [globalCheckinId]);

    const [selfSelected, setSelfSelected] = useState(false);
    useMemo(() => {
        const selfCode = props?.value?.code;
        const isSelect = selfCode !== undefined &&
            globalSelectedId != undefined &&
            selfCode.toLowerCase() === globalSelectedId.toLowerCase();

        setSelfSelected(isSelect);
    }, [globalSelectedId]);

    function onContainerClick() {
        const code = props?.value?.code
        if (code !== undefined) {
            dispatch(updateKeywordSelected(code));
        }
    }

    function onCheckinClick() {
        const code = props?.value?.code
        if (code !== undefined) {
            dispatch(updateCheckinId(code));
            var model = {
                id: userId,

                keywordId: code,
            }
            Checkin(model).then(response => {
                console.log(response)
                if (response.data.code === 200) {
                    var online = response.data.value.countLast10Minutes
                    var payload = {
                        oldCode: globalCheckinId,
                        newCode: code,
                        online
                    }
                    dispatch(updateCheckinOnline(payload))
                }
            })
        }
    }

    return (
        <div className={
            styles["container"] +
            " " + (selfSelected ? styles["self-selected"] : "") +
            " " + (selfCheckin ? styles["self-checkin"] : "")
        }
            onClick={onContainerClick}
        >
            <div className={styles["keyword"]}>{props?.value?.name}</div>
            <div className={styles["online"]}>{props?.value?.online} online</div>
            <Button className={styles["button"]} onClick={onCheckinClick}>Checkin</Button>

        </div >
    )
}

export default Keyword;
