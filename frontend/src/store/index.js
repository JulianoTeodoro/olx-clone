import { createStore } from 'vuex'

import user from '../resources/user/index'
import login from '../pages/Login/_store/index'

export default createStore({
    modules: {
        user,
        login
    }
})