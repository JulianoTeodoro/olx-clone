const stateInitial = {
    email: ''
}

export default (state = stateInitial, action) => {
    
    if(action.type === 'SET_EMAIL'){
        return {...state, email: action.payload.email}
    }

    return state;
}