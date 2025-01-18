import { host } from '../hostvariables'
import axios from 'axios'

export default async function GetUserKeyword(model) {
    const url = host + "/keyword/getuserkeywords";
    const response = axios({
        method: "post",
        url: url,
        mode: "no-cors",
        data: {
            keywordIds: model.keywordIds
        }
    });
    return response;
}