import { isLogged } from '@/helpers/authHandler';

const state = {
    user: {
        email: '',
        password: '',
        name: "",
        disabled: false,
        state: ''
    },
    isLogged: isLogged(),

}

const mutations = {
    SET_USER: (state, user) => {
        state.user = user
    },

    SET_DISABLED: (state, disabled) => {
        state.user.disabled = disabled
    }
} 



export default {
    state,
    mutations,
}

