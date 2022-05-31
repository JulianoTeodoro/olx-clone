import { isLogged } from '@/helpers/authHandler';
import actions from './actions';
const state = {
        isLogged: isLogged(),
        rememberPassword: false,
}

const mutations = {
    SET_REMEMBER_PASSWORD: (state, rememberPassword) => {
        state.rememberPassword = rememberPassword
    }

}

export default {
    state,
    mutations,
    actions
}