import {
    SETAR_ERRO,
    SET_EMAIL,
    SET_PASSWORD,
    SET_REMEMBER_PASSWORD,
    SET_DISABLED,
} from './mutation-type'

export default {
    [SETAR_ERRO]: (state, {erro}) => {
        state.erro = erro;
    },
    [SET_EMAIL]: (state, email) => {
        state.user.email = email
    },
    [SET_PASSWORD]: (state, password) => {
        state.user.password = password
    },
    [SET_REMEMBER_PASSWORD]: (state, rememberPassword) => {
        state.rememberPassword = rememberPassword
    },
    [SET_DISABLED]: (state, disabled) => {
        state.disabled = disabled
    }
}