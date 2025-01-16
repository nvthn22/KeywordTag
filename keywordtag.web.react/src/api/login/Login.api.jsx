import { host } from '../hostvariables'
import axios from 'axios'

export default async function LoginApi(model) {
    const url = host + "/account/login";
    const response = axios({
        method: "post",
        url: url,
        mode: "no-cors",
        data: {
            "email": model.email,
            "pin": model.pin,
        },
    });
    return response;
}