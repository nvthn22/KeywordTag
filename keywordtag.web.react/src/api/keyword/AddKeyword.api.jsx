import { host } from '../hostvariables'
import axios from 'axios'

export default async function AddKeyword(model) {
    const url = host + "/keyword/addkeyword";
    const response = axios({
        method: "post",
        url: url,
        mode: "no-cors",
        data: {
            id: model.id,
            name: model.name,
        }
    });
    return response;
}