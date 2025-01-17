import { useState, useRef } from 'react';
import { useNavigate } from "react-router-dom";
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Link from '@mui/material/Link';
import Stack from '@mui/material/Stack';
import styles from './LoginPage.module.scss'
import GetPincode from '../../api/login/GetPincode.api'
import Login from '../../api/login/Login.api'
import { Initial } from '../../stores/Applocal'
import { saveUserStatus } from '../../stores/Applocal'
import {
    updateLoginStatus,
    updateUserEmail,
} from '../../stores/slices/AppSlide'
import { useDispatch, useSelector } from 'react-redux'


function LoginPage(props) {
    Initial();

    const dispatch = useDispatch();
    const [pinMessage, setPinMessage] = useState(" ");
    const [loginDisabled, setLoginDisabled] = useState(true);
    const navigate = useNavigate();

    const refEmail = useRef();
    const refPin = useRef();

    const onGetPinClick = ($event) => {
        const emailValue = refEmail.current.value;
        dispatch(updateUserEmail(emailValue))
        GetPincode({
            email: email,
        }).then(result => {
            if (result.data.code === 200) {
                setPinMessage(result.data.message);
                setLoginDisabled(false);
            }
        });
    }

    const onLoginClick = ($event) => {
        const email = refEmail.current.value;
        const pin = refPin.current.value;
        Login({
            email: email,
            pin: pin,
        }).then(result => {
            if (result.data.code === 200) {
                var userLocal = {
                    email: email,
                    id: result.data.value.id,
                    listKeywords: result.data.value.list_keyword,
                    listKeywordsTag: result.data.value.list_keyword_tagged,
                }
                saveUserStatus(userLocal);
                dispatch(updateLoginStatus(userLocal));
                navigate('/main')
            } else {
                setPinMessage(result.data.message);
            }
        });
    }

    const email = useSelector(state => state.app.user.email);

    return (
        <>
            <Stack direction="column" spacing={3}>
                <div className={styles["line-item"]}>
                    <TextField
                        className={styles["text-field"]}
                        label="Email"
                        variant="outlined"
                        inputRef={refEmail}
                        value={email}
                    />
                </div>

                <div className={styles["line-item"]}>
                    <TextField
                        className={styles["text-field"]}
                        label="Pin"
                        variant="outlined"
                        helperText={pinMessage}
                        inputRef={refPin}
                    />

                    <Link
                        className={styles["link-button"]}
                        component="button"
                        variant="body2"
                        onClick={onGetPinClick}>
                        Lấy mã pin
                    </Link>
                </div>



                <div className={styles["line-item"]}>
                    <Button
                        className={styles["button"]}
                        disabled={loginDisabled}
                        onClick={onLoginClick}>
                        Đăng nhập
                    </Button>
                </div>
            </Stack >
        </>

    )
}

export default LoginPage;
