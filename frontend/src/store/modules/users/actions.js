import OlxAPI from '@/helpers/OlxAPI'
import { doLogin } from '@/helpers/authHandler';
const api = OlxAPI();

export default {

    setarErro({commit}, payload) {
        commit('setarErro', {payload: payload})
    },
    async getStates({commit}) {
        const slist = await api.getStates();
        commit('SET_STATE_LOC', slist)
    },

    async register({state, dispatch}, params){
        return api.register(params.Nome, params.Sobrenome, params.Email, params.Password, params.Password)
        .then((response) => {
            doLogin(response.token.Token, state.rememberPassword);
            this.router.push('/');
        })
        .catch((error) => {
            dispatch('setarErro', error);
        })
    },
    async login({state, dispatch, commit}, params){
        const json = await api.login(params.email, params.password);
        if(json.error) {
            dispatch('setarErro', json.error);
        } else {
            doLogin(json.token.Token, state.rememberPassword);
            commit("SET_USER", json.usuario) 
            localStorage.setItem("usuario", JSON.stringify({ email: params.email, password: params.password }));
            this.router.push('/');
        }

    },

    async categorias({commit, dispatch}) {
        const json = await api.categories();
        if(json.error) {
            dispatch('setarErro', json.error);
        }
        else {
            commit("SET_CATEGORIAS", json)
        }
    },

    async states({commit}, dispatch) {
        const json = await api.states();
        if(json.error) {
            dispatch('setarErro', json.error);
        }
        else {
            commit("SET_STATE_LOC", json.states)
        }
    }



    
}