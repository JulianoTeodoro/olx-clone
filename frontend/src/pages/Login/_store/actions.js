import * as type from './mutation-type'
import {doLogin} from '@/helpers/authHandler'
import OlxAPI from '@/helpers/OlxAPI'

export default {

    setarErro({commit}, payload) {
        commit(type.SETAR_ERRO, {payload: payload})
    },

    setRememberPassword({commit}, payload){
        commit(type.SET_REMEMBER_PASSWORD, payload)
    },
    setDisabled({commit}, payload){
        commit(type.SET_DISABLED, payload)
    },
    setEmail({commit}, payload) {
        commit(type.SET_EMAIL, payload)
    },
    setPassword({commit}, payload) {
        commit(type.SET_PASSWORD, payload)
    },

     async auth({state, dispatch}, params){
        const api = OlxAPI();
        console.log(params);
        const json = await api.login(params.email, params.password);

        if(json.error) {
            dispatch('setarErro', json.error);
        } else {
            doLogin(json.token, state.rememberPassword);
            this.router.push('/');
        }

    }


}