import { host } from '../hostvariables'
import axios from 'axios'

export default async function GetTopKeyword() {
    const url = host + "/keyword/gettopkeyword";
    const response = axios({
        method: "get",
        url: url,
        mode: "no-cors",
    });
    return response;
}