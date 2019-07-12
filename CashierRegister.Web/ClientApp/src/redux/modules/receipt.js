import * as ReceiptService from '../services/receiptService';
import * as ProductService from '../services/productService';
import * as errorActions from "./error";

const GET_AND_PUSH_PRODUCT = "GET_AND_PUSH_PRODUCT";
const GET_AND_PUSH_PRODUCT_SUCCESS = "GET_AND_PUSH_PRODUCT_SUCCESS";
const GET_AND_PUSH_PRODUCT_FAIL = "GET_AND_PUSH_PRODUCT_FAIL";
const REMOVE_PRODUCT = "REMOVE_PRODUCT";
const CLEAR_RECEIPT = "CLEAR_RECEIPT";
const GET_RECEIPTS_BY_DATE = "GET_RECEIPTS_BY_DATE";
const GET_RECEIPTS_BY_DATE_SUCCESS = "GET_RECEIPTS_BY_DATE_SUCCESS";
const GET_RECEIPTS_BY_DATE_FAIL = "GET_RECEIPTS_BY_DATE_FAIL";
const CREATE_RECEIPT = "CREATE_RECEIPT";
const CREATE_RECEIPT_SUCCESS = "CREATE_RECEIPT_SUCCESS";
const CREATE_RECEIPT_FAIL = "CREATE_RECEIPT_FAIL";

const initialState = {
    productsOnNewReceipt: [],
    receipts: [],
    error: false,
    loading: false
}

export const getAndPushProduct = (id, productCount) => async dispatch => {
    dispatch({
        type: GET_AND_PUSH_PRODUCT
    });
    try{
        const response = await ProductService.getProductById(id);
        return dispatch({ type: GET_AND_PUSH_PRODUCT_SUCCESS, product: {...response, productCount}})
    }catch (error) {
        dispatch(errorActions.showError("Error getting product with ID: " + id));
        return dispatch({ type: GET_AND_PUSH_PRODUCT_FAIL, error });
    }
}

export const removeProduct = (id) =>{
    return {
        type: REMOVE_PRODUCT,
        productIdToRemove: id
    }
}

export const clearReceipt = () =>{
    return {
        type: CLEAR_RECEIPT
    }
}

export const createReceipt = (identity, productsOnNewReceipt) => async dispatch =>{
    dispatch({
        type: CREATE_RECEIPT
    });

    try{
        const response = await ReceiptService.createReceipt(identity, productsOnNewReceipt);
        await dispatch({ type: CREATE_RECEIPT_SUCCESS })
        return response;
    }catch(error){
        dispatch(errorActions.showError("Error creating receipt"));
        return dispatch({ type: CREATE_RECEIPT_FAIL, error });
    }
}

const reducer = (state = initialState, action ) =>{
    switch(action.type){
        case GET_AND_PUSH_PRODUCT: {
            return{
                ...state,
                loading: true
            }
        }
        case GET_AND_PUSH_PRODUCT_SUCCESS: {
            return{
                ...state,
                productsOnNewReceipt: [...state.productsOnNewReceipt, action.product],
                loading: false
            }
        }
        case GET_AND_PUSH_PRODUCT_FAIL: {
            return{
                ...state,
                loading: false,
                error: true
            }
        }
        case REMOVE_PRODUCT: {
            const newProducts = state.productsOnNewReceipt.filter(product => product.product.id !== action.productIdToRemove);
            return{
                ...state,
                productsOnNewReceipt: newProducts,
                loading: false,
                error: false
            }
        }
        case CREATE_RECEIPT: {
            return {
                ...state,
                loading: true,
                error: false
            }
        }
        case CREATE_RECEIPT_SUCCESS: {
            return {
                ...state,
                loading: false,
                error: false
            }
        }
        case CREATE_RECEIPT_FAIL: {
            return {
                ...state,
                loading: false,
                error: true
            }
        }
        case CLEAR_RECEIPT: {
            return {
                ...state,
                productsOnNewReceipt: []
            }
        }
        default: {
            return{
                ...state
            }
        }
    }
}

export default reducer;