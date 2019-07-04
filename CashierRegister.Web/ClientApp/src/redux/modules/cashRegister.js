import * as CashRegisterService from '../services/cashRegisterService';
import * as errorActions from "./error";

const GET_CASHREGISTERS = "GET_CASHREGISTERS";
const GET_CASHREGISTERS_SUCCESS = "GET_CASHREGISTERS_SUCCESS";
const GET_CASHREGISTERS_FAIL = "GET_CASHREGISTERS_FAIL";
const POST_CASHREGISTER = "POST_CASHREGISTER";
const POST_CASHREGISTER_SUCCESS = "POST_CASHREGISTER_SUCCESS";
const POST_CASHREGISTER_FAIL = "POST_CASHREGISTER_FAIL";
const DELETE_CASHREGISTER = "DELETE_CASHREGISTER";
const DELETE_CASHREGISTER_SUCCESS = "DELETE_CASHREGISTER_SUCECSS";
const DELETE_CASHREGISTER_FAIL = "DELETE_CASHREGISTER_FAIL";
const EDIT_CASHREGISTER = "EDIT_CASHREGISTER";
const EDIT_CASHREGISTER_SUCCESS = "EDIT_CASHREGISTER_SUCCESS";
const EDIT_CASHREGISTER_FAIL = "EDIT_CASHREGISTER_FAIL";

const initialState = {
    loading: false,
    cashRegisters: [],
    error: null
}

export const getCashRegisters = () => async dispatch => {
    dispatch({
        type: GET_CASHREGISTERS
    });

    try {
        const response = await CashRegisterService.readCashRegister();
        return dispatch({ type: GET_CASHREGISTERS_SUCCESS, cashRegisters: response });
    }
    catch (error) {
        dispatch(errorActions.showError("Getting cash registers error"));
        return dispatch({ type: GET_CASHREGISTERS_FAIL, error });
    }
}

export const createCashRegister = (location) => async dispatch => {
    dispatch({
        type: POST_CASHREGISTER
    });

    try {
        const response = await CashRegisterService.createCashRegister(location);
        return dispatch({ type: POST_CASHREGISTER_SUCCESS });
    }
    catch (error) {
        dispatch(errorActions.showError("Posting cash register error"));
        return dispatch({ type: POST_CASHREGISTER_FAIL, error });
    }
}

export const deleteCashRegister = (id) => async dispatch => {
    dispatch({
        type: DELETE_CASHREGISTER
    });

    try {
        const response = await CashRegisterService.deleteCashRegister(id);
        return dispatch({ type: POST_CASHREGISTER_SUCCESS });
    }
    catch (error) {
        dispatch(errorActions.showError("Deleting cash register error"));
        return dispatch({ type: POST_CASHREGISTER_FAIL, error });
    }
}

export const editCashRegister = (id, location) => async dispatch =>{
    dispatch({
        type: EDIT_CASHREGISTER
    });

    try {
        await CashRegisterService.editCashRegister(id, location);
        const response = await CashRegisterService.readCashRegister();
        return dispatch({ type: EDIT_CASHREGISTER_SUCCESS, cashRegisters: response });
    }
    catch (error) {
        dispatch(errorActions.showError("Editing cash register error"));
        return dispatch({ type: EDIT_CASHREGISTER_FAIL, error });
    }
}

const reducer = (state = initialState, action ) =>{
    switch(action.type){
        case GET_CASHREGISTERS: {
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case GET_CASHREGISTERS_SUCCESS: {
            return {
                cashRegisters: action.cashRegisters,
                loading: false,
                error: null
            }
        }
        case GET_CASHREGISTERS_FAIL: {
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case DELETE_CASHREGISTER: {
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case DELETE_CASHREGISTER_SUCCESS: {
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case DELETE_CASHREGISTER_FAIL: {
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case POST_CASHREGISTER: {
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case POST_CASHREGISTER_SUCCESS: {
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case POST_CASHREGISTER_FAIL: {
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case EDIT_CASHREGISTER: {
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case EDIT_CASHREGISTER_SUCCESS: {
            return {
                ...state.cashRegisters,
                loading: false,
                error: null
            }
        }
        case EDIT_CASHREGISTER_FAIL: {
            return {
                ...state,
                loading: false,
                error: action.error
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