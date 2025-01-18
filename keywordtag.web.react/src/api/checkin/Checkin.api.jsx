import { host } from '../hostvariables'
import axios from 'axios'

export default async function Checkin(model) {
    const url = host + "/keyword/checkin";
    const response = axios({
        method: "post",
        url: url,
        mode: "no-cors",
        data: {
            id: model.id,
            keywordId: model.keywordId
        }
    });
    return response;
}