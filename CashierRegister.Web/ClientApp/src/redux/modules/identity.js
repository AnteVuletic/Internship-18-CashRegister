import * as loginService from '../services/loginService';
import * as shiftService from '../services/shiftService';
import * as errorActions from "./error";

const LOGIN = "LOGIN";
const LOGIN_SUCCESS = "LOGIN_SUCCESS";
const REGISTER = "REGISTER";
const REGISTER_SUCCESS = "REGISTER_SUCCESS";
const HAS_TOKEN = "HAS_TOKEN";
const HAS_TOKEN_SUCCESS = "HAS_TOKEN_SUCCESS"
const CONNECT_CASHREGISTER = "CONNECT_CASHREGISTER";
const CONNECT_CASHREGISTER_SUCCESS = "CONNECT_CASHREGISTER_SUCCESS";
const CONNECT_CASHREGISTER_FAIL = "CONNECT_CASHREGISTER_FAIL";
const DISCONNECT_CASHREGISTER = "DISCONNECT_CASHREGISTER";
const DISCONNECT_CASHREGISTER_SUCCESS = "CONNECT_CASHREGISTER_SUCCESS";
const DISCONNECT_CASHREGISTER_FAIL = "CONNECT_CASHREGISTER_FAIL";

const initialState = {
    username: '',
    id: -1,
    token: '',
    loading: false,
    error: false,
    cashRegisterId: -1
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

export const connectCashRegister = (cashierId, cashRegisterId) => async dispatch => {
    dispatch({
        type: CONNECT_CASHREGISTER
    });

    try{
        const response = await shiftService.startShift(cashierId, cashRegisterId);
        return dispatch({ type: CONNECT_CASHREGISTER_SUCCESS });
    }catch(error){
        errorActions.showError("Failed to start shift");
        return dispatch({ type: CONNECT_CASHREGISTER_FAIL, error });
    }
}

export const disconnectCashRegister = (cashierId, cashRegisterId) => async dispatch => {
    dispatch({
        type: DISCONNECT_CASHREGISTER
    });

    try{
        const response = await shiftService.endShift(cashierId, cashRegisterId);
        return dispatch({ type: CONNECT_CASHREGISTER_SUCCESS, cashRegisterId });
    }catch(error){
        errorActions.showError("Failed to end shift");
        return dispatch({ type: DISCONNECT_CASHREGISTER_FAIL, error })
    }
}

const reducer = (state = initialState, action) => {
    switch(action.type) {
        case HAS_TOKEN:
            return {
                ...state,
                loading: true
            }
        case HAS_TOKEN_SUCCESS:
            return {
                ...action.user,
                loading: false,
                cashRegisterId: -1
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
                cashRegisterId: -1
            }
        case CONNECT_CASHREGISTER:
            return {
                ...state,
                loading: true
            }
        case CONNECT_CASHREGISTER_SUCCESS:
            return {
                ...state,
                cashRegisterId: action.cashRegisterId,
                loading: false,
                error: false
            }
        case CONNECT_CASHREGISTER_FAIL:
            return {
                ...state,
                loading: false,
                error: true
            }
        case DISCONNECT_CASHREGISTER:
            return {
                ...state,
                loading: true
            }
        case DISCONNECT_CASHREGISTER_SUCCESS:
            return {
                ...state,
                loading: false,
                error: false,
                cashRegisterId: -1
            }
        case DISCONNECT_CASHREGISTER_FAIL:
            return {
                ...state,
                loading: false,
                error: false
            }
        default:
            return {
                ...state
            }
    }

}

export default reducer;