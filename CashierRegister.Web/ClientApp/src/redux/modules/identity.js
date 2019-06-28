import * as loginService from '../services/loginService';

const LOGIN = "LOGIN";
const LOGIN_SUCCESS = "LOGIN_SUCCESS";
const REGISTER = "REGISTER";
const REGISTER_SUCCESS = "REGISTER_SUCESS";

const initialState = {
    username: '',
    id: -1,
    token: '',
    loading: false,
    isAuthorized: false
}

export const loginCashier = (username, password) => dispatch => {
    dispatch({
        type: LOGIN
    });

    return loginService.loginCashier(username,password)
        .then(response => dispatch({ type: LOGIN_SUCCESS, user: response }));
}

export const registerCashier = (username, password) => dispatch => {
    dispatch({
        type: REGISTER
    });

    return loginService.registerCashier(username, password)
        .then(response => dispatch({ type: REGISTER_SUCCESS, user: response }));
}

const reducer = (state = initialState, action) => {
    switch(action.Type){
        case LOGIN: {
            return {
                ...state,
                loading: true
            }
        }
        case LOGIN_SUCCESS: {
            return {
                ...action.user,
                loading: false,
                isAuthorized: true
            }
        }
        case REGISTER: {
            return {
                ...state,
                loading: true
            }
        }
        case REGISTER_SUCCESS: {
            return {
                ...action.user,
                loading: false,
                isAuthorized: true
            }
        }
        default: {
            return {
                ...state
            }
        }
    }
}

export default reducer;