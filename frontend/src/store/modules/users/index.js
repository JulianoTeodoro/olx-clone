import { isLogged } from '@/helpers/authHandler';
import mutations from './mutations';
import getters from './getters';
import actions from './actions';

const state = {
    user: {
        email: '',
        password: '',
        name: "",
        disabled: false,
        state: ''
    },
    isLogged: isLogged(),
    stateLoc: [],
    rememberPassword: false,

}

export default {
    namespaced: true,
    state,
    getters,
    mutations,
    actions
}

