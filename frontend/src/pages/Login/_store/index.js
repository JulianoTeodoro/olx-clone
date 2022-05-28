import mutations from './mutations';
import actions from './actions';
import { isLogged } from '@/helpers/authHandler';

const state = {
    user: {
        email: '',
        password: '',
    },
        disabled: false,
        rememberPassword: false,
        erro: undefined,
        isLogged: isLogged()  

}

export default {
    state,
    mutations,
    actions
    
}