import OlxAPI from '@/helpers/OlxAPI'
import { doLogin } from '@/helpers/authHandler';
const api = OlxAPI();

export default {

    async getStates({commit}) {
        const slist = await api.getStates();
        commit('SET_STATE_LOC', slist)
    },
    async register({state, dispatch}, params){
        console.log(params)
        const json = await api.register(params.name, params.email, params.password, params.stateLoc);
        if(json.error) {
            dispatch('setarErro', json.error);
        } else {
            doLogin(json.token, state.rememberPassword);
            this.router.push('/');
        }

    }


}