import * as loginService from '../services/loginService';

const LOGIN = "LOGIN";
const LOGIN_SUCCESS = "LOGIN_SUCCESS";
const REGISTER = "REGISTER";
const REGISTER_SUCCESS = "REGISTER_SUCCESS";
const HAS_TOKEN = "HAS_TOKEN";
const HAS_TOKEN_SUCCESS = "HAS_TOKEN_SUCCESS"

const initialState = {
    username: '',
    id: -1,
    token: '',
    loading: false,
    isAuthorized: false
}

export const loginCashier = (username, password) => async dispatch => {
    dispatch({
        type: LOGIN
    });

    const response = await loginService.loginCashier(username, password);
    return dispatch({ type: LOGIN_SUCCESS, user: response });
}

export const registerCashier = (username, password) => async dispatch => {
    dispatch({
        type: REGISTER
    });

    const response = await loginService.registerCashier(username, password);
    return dispatch({ type: REGISTER_SUCCESS, user: response });
}

export const hasToken = (token) => async dispatch => {
    dispatch({
        type: HAS_TOKEN
    });

    const response = await loginService.getUser(token);
    return dispatch({ type: HAS_TOKEN_SUCCESS, user: response });
}

const reducer = (state = initialState, action) => {
    switch(action.type) {
        case HAS_TOKEN:
            return {
                ...state,
                loading: true
            }
        case HAS_TOKEN_SUCCESS:
            console.log(action.user)
            return {
                ...action.user,
                isAuthorized: true,
                loading: false
            }
        case LOGIN:
            return {
                ...state,
                loading: true
            }
        case LOGIN_SUCCESS:
            return {
                ...action.user,
                loading: false,
                isAuthorized: true
            }
        case REGISTER:
            return {
                ...state,
                loading: true
            }
        case REGISTER_SUCCESS:
            return {
                ...action.user,
                loading: false,
                isAuthorized: true
            }
        default:
            return {
                ...state
            }
    }

}

export default reducer;