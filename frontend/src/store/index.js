import { createStore } from 'vuex'

import users from './modules/users/index'
import login from '../pages/Login/_store/index'
import signup from '../pages/Signup/_store/index'

export default createStore({
    modules: {
        users,
        login,
        signup
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