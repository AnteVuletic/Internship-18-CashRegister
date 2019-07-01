import * as CashierService from '../services/cashierService';
import * as errorActions from "./error";

const GET_CASHIERS = "GET_CASHIERS";
const GET_CASHIERS_SUCCESS = "GET_CASHIERS_SUCCESS";
const GET_CASHIERS_FAIL = "GET_CASHIERS_FAIL";
const EDIT_CASHIER = "EDIT_CASHIER";
const EDIT_CASHIER_SUCCESS = "EDIT_CASHIER_SUCCESS";
const EDIT_CASHIER_FAIL = "EDIT_CASHIER_FAIL";
const POST_CASHIER = "POST_CASHIER";
const POST_CASHIER_SUCCESS = "POST_CASHIER_SUCCESS";
const POST_CASHIER_FAIL = "POST_CASHIER_FAIL";
const DELETE_CASHIER = "DELETE_CASHIER";
const DELETE_CASHIER_SUCCESS = "DELETE_CASHIER_SUCECSS";
const DELETE_CASHIER_FAIL = "DELETE_CASHIER_FAIL";

const initialState = {
    loading: false,
    cashier: [],
    error: null
}

export const getCashiers = () => async dispatch =>{
    dispatch({
        type: GET_CASHIERS
    });

    try {
        const response = await CashierService.readCashier();
        return dispatch({ type: GET_CASHIERS_SUCCESS, cashiers: response });
    }
    catch (error) {
        dispatch(errorActions.showError("Getting cashiers error"));
        return dispatch({ type: GET_CASHIERS_FAIL, error });
    }
}

export const createCashier = (username, password) => async dispatch =>{
    dispatch({
        type: POST_CASHIER
    });

    try {
        const result = await CashierService.createCashier(username, password);
        return dispatch({ type: POST_CASHIER_SUCCESS });
    }
    catch (error) {
        dispatch(errorActions.showError("Error creating cashier"));
        return dispatch({ type: POST_CASHIER_FAIL, error });
    }
        
}

export const deleteCashier = (id) => async dispatch =>{
    dispatch({
        type: DELETE_CASHIER
    });

    try {
        const response = await CashierService.deleteCashier(id);
        return dispatch({ type: DELETE_CASHIER_SUCCESS });
    }
    catch (error) {
        dispatch(errorActions.showError("Error deleting cashier"));
        return dispatch({ type: DELETE_CASHIER_FAIL, error });
    }
}

export const editCashierPassword = (id, password) => async dispatch =>{
    dispatch({
        type: EDIT_CASHIER
    });

    try {
        const response = await CashierService.editCashierPassword(id, password);
        return dispatch({ type: EDIT_CASHIER_SUCCESS });
    }
    catch (error) {
        dispatch(errorActions.showError("Error editing cashier"));
        return dispatch({ type: DELETE_CASHIER_FAIL, error });
    }
}

const reducer = (state = initialState, action ) =>{
    switch(action.type){
        case GET_CASHIERS:{
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case GET_CASHIERS_SUCCESS:{
            return {
                cashiers: action.cashiers,
                loading: false,
                error: null
            }
        }
        case GET_CASHIERS_FAIL:{
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case EDIT_CASHIER:{
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case EDIT_CASHIER_SUCCESS:{
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case EDIT_CASHIER_FAIL:{
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case DELETE_CASHIER:{
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case DELETE_CASHIER_SUCCESS:{
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case DELETE_CASHIER_FAIL:{
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case POST_CASHIER:{
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case POST_CASHIER_SUCCESS:{
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case POST_CASHIER_FAIL:{
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