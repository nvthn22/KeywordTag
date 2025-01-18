import { host } from '../hostvariables'
import axios from 'axios'

export default async function GetTopKeywords() {
    const url = host + "/keyword/gettopkeywords";
    const response = axios({
        method: "get",
        url: url,
        mode: "no-cors",
    });
    return response;
}