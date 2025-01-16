import { useState } from 'react';
import { useNavigate } from "react-router-dom";
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Link from '@mui/material/Link';
import Stack from '@mui/material/Stack';
import styles from './LoginPage.module.scss'
import GetPincode from '../../api/login/GetPincode.api'
import Login from '../../api/login/Login.api'

function LoginPage(props) {
    const [email, setEmail] = useState("");
    const [pin, setPin] = useState("");
    const [pinMessage, setPinMessage] = useState(" ");
    const [loginDisabled, setLoginDisabled] = useState(true);
    const navigate = useNavigate();

    const onEmailChange = ($event) => {
        setEmail($event.currentTarget.value)
    }

    const onPinChange = ($event) => {
        setPin($event.currentTarget.value)
    }

    const onGetPinClick = ($event) => {
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
        console.log("email", email);
        console.log("pin", pin);
        Login({
            email: email,
            pin: pin,
        }).then(result => {
            if (result.data.code === 200) {
                navigate('/main')
            }
            console.log("result", result);
        });
    }

    return (
        <>
            <Stack direction="column" spacing={3}>
                <div className={styles["line-item"]}>
                    <TextField
                        className={styles["text-field"]}
                        label="Email"
                        variant="outlined"
                        onChange={onEmailChange} />
                </div>

                <div className={styles["line-item"]}>
                    <TextField
                        className={styles["text-field"]}
                        label="Pin"
                        variant="outlined"
                        helperText={pinMessage}
                        onChange={onPinChange} />

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
