import { createStore } from 'vuex'

import users from './modules/users/index'

export default createStore({
    modules: {
        users,
    },
    state: {
        erro: undefined
    },
    mutations: {
        setarErro: (state, {erro}) => {
            state.erro = [erro];
        },
    },
    actions: {

        setarErro({commit}, payload) {
            commit('setarErro', {payload: payload})
        },
            
    }
})