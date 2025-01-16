import { host } from '../hostvariables'
import axios from 'axios'

export default async function GetMessages(model) {
    const url = host + "/message/msg";
    const response = axios({
        method: "post",
        url: url,
        mode: "no-cors",
        data: {
            "filter": model.filter,
        },
    });
    return response;
}
