
export default {
    SET_USER: (state, user) => {
        state.user = user
    },
    SET_STATE_LOC: (state, [states]) => {
        state.stateLoc.push(states)
    },
    SET_REMEMBER_PASSWORD: (state, rememberPassword) => {
        state.rememberPassword = rememberPassword
    }

}