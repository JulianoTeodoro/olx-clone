export default {
    isAuthenticated: state => state.filter(t => t.isLogged === true)
}