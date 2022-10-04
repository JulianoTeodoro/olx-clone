import { isLogged } from '@/helpers/authHandler';
import mutations from './mutations';
import getters from './getters';
import actions from './actions';

const state = {
    user: undefined,
    isLogged: isLogged(),
    stateLoc: undefined,
    rememberPassword: false,
    categorias: undefined

}

export default {
    namespaced: true,
    state,
    getters,
    mutations,
    actions
}

