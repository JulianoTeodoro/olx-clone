//import qs from 'qs'
import Cookies from 'js-cookie'
import router from '@/router/index'
const BASEAPI = 'http://alunos.b7web.com.br:501'


const apiFetchPost = async (endpoint, body) => {
    if(!body.token){
        let token = Cookies.get('token')
        if(token){
            body.token = token
        }
    }

    const res = await fetch(BASEAPI+endpoint, {
        method: 'POST',
        headers: {
           'Accept': 'application/json',
           'Content-Type': 'application/json'   
       },
       body: JSON.stringify(body)

    })
    const json = await res.json();
    if(json.notallowed){
        router.push('/login')
        return;
    } 

    router.push('/')
    return json;
}

/*const apiFetchGet = async (endpoint, body = []) => {
    if(!body.token){
        let token = Cookies.get('token')
        if(token){
            body.token = token
        }
    }

    const res = await fetch(`${BASEAPI+endpoint}?${qs.stringify(body)}`)
    const json = await res.json();

    if(json.notallowed){
        this.router.push('/login')
        return;
    } 

    return json;
}
*/

const OlxApi = {
    login: async (email, password) => {
        //fazer consulta ao webservice
        const json = await apiFetchPost(
            '/user/signin',
            {email, password}
        );
        return json;
    }
}

export default () => OlxApi;