import { createStore } from 'vuex'

import users from './modules/users/index'
import ads from './modules/ads/index'

export default createStore({
    modules: {
        users,
        ads
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