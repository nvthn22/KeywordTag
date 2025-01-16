import { host } from '../hostvariables'
import axios from 'axios'

export default async function GetPincode(model) {
    const url = host + "/account/getpincode";
    const response = axios({
        method: "post",
        url: url,
        mode: "no-cors",
        data: {
            "email": model.email,
        },
    });
    return response;
}