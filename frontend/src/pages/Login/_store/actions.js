import { doLogin } from '@/helpers/authHandler'
import OlxAPI from '@/helpers/OlxAPI'
const api = OlxAPI()

export default {

    
        async login({state, dispatch}, params){
            const json = await api.login(params.email, params.password);
            if(json.error) {
                dispatch('setarErro', json.error);
            } else {
                doLogin(json.token, state.rememberPassword);
                this.router.push('/');
            }
    
        }
    
    
    
}