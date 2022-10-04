
export default {
    SET_USER: (state, user) => {
        state.user = user
    },
    SET_STATE_LOC: (state, states) => {
        state.stateLoc = states;
    },
    SET_REMEMBER_PASSWORD: (state, rememberPassword) => {
        state.rememberPassword = rememberPassword
    },

    SET_CATEGORIAS: (state, categorias) => {
        state.categorias = categorias;
    },


}