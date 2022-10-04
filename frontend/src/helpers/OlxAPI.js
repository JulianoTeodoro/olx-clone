//import qs from 'qs'
import Cookies from 'js-cookie'
import router from '@/router/index'
const BASEAPI = 'https://localhost:7032'

const apiFetchPost = async (endpoint, body) => {
    if(!body.token) {
        let token = Cookies.get('token');
        if(token) {
            body.token = token;
        }
    }

    //console.log(JSON.stringify(body))
    console.log(body);

    const res = await fetch(BASEAPI+endpoint, {
        method:'POST',
        headers:{
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body:JSON.stringify(body)
    });

    const json = await res.json();
    
    if(json.notallowed) {
        router.push('/login')
        return;
    } 

    router.push('/')
    return json;
}


const apiFetchGet = async (endpoint, body = []) => {
    if(!body.token){
        let token = Cookies.get('token')
        if(token){
            body.token = token
        }
    }

    const res = await fetch(`${BASEAPI+endpoint}`, {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${body.token}`
        }
    })
    const json = await res.json();

    if(json.notallowed){
        return;
    } 

    return json;
}


const OlxAPI = {
    login: async (email, password) => {
        //fazer consulta ao webservice
        
        const json = await apiFetchPost(
            '/Account/login', 
            {email, password}
        );
        return json;
    },

    register: async (Nome, Sobrenome, Email, Password, ConfirmPassword) => {
        const json = await apiFetchPost(
            '/Account/register',
            {Nome, Sobrenome, Email, Password, ConfirmPassword}
        );
        return json;
    },

    categories: async () => {
        const json = await apiFetchGet("/api/Categorias")
        return json;
    },
    states: async () => {
        const json = await apiFetchGet("/api/User/states")
        return json;
    },
    ads: async () => {
        const json = await apiFetchGet("/api/Ads")
        return json;

    }

}

export default () => OlxAPI;