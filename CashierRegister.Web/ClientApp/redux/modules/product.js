import * as ProductService from '../services/productService';
import * as errorActions from "./error";

const GET_PRODUCTS = "GET_PRODUCTS";
const GET_PRODUCTS_SUCCESS = "GET_PRODUCTS_SUCCESS";
const GET_PRODUCTS_FAIL = "GET_PRODUCTS_FAIL";
const EDIT_PRODUCT = "EDIT_PRODUCT";
const EDIT_PRODUCT_SUCCESS = "EDIT_PRODUCT_SUCCESS";
const EDIT_PRODUCT_FAIL = "EDIT_PRODUCT_FAIL";
const POST_PRODUCT = "POST_PRODUCT";
const POST_PRODUCT_SUCCESS = "POST_PRODUCT_SUCCESS";
const POST_PRODUCT_FAIL = "POST_PRODUCT_FAIL";
const DELETE_PRODUCT = "DELETE_PRODUCT";
const DELETE_PRODUCT_SUCCESS = "DELETE_PRODUCT_SUCECSS";
const DELETE_PRODUCT_FAIL = "DELETE_PRODUCT_FAIL";

const initialState = {
    loading: false,
    products: [],
    error: null
}

export const getProducts = () => dispatch =>{
    dispatch({
        type: GET_PRODUCTS
    });

    return ProductService.fetchProducts()
    .then(response => dispatch({ type: GET_PRODUCTS_SUCCESS, products: response}))
    .catch(error => {
        dispatch(errorActions.showError("Error getting products"));
        return dispatch({ type: GET_PRODUCTS_FAIL, error });
    });
}

export const editProduct = (productId, name, price) => dispatch =>{
    dispatch({
        type: EDIT_PRODUCT
    });

    return ProductService.editProduct(productId, name, price)
        .then(_ => dispatch({ type: EDIT_PRODUCT_SUCCESS }))
        .catch(error => { 
            dispatch(errorActions.showError("Error editing product"));
            return dispatch({ type: EDIT_PRODUCT_FAIL, error });
        });
}

export const deleteProduct = (productId) => dispatch =>{
    dispatch({
        type: DELETE_PRODUCT
    });

    return ProductService.deleteProduct(productId)
        .then(_ => dispatch({ type: DELETE_PRODUCT_SUCCESS }))
        .catch(error => {
            dispatch(errorActions.showError("Error deleting product"));
            return dispatch({ type: DELETE_PRODUCT_FAIL, error });
        })
}

export const postProduct = (productId, name, price) => dispatch =>{
    dispatch({
        type: POST_PRODUCT
    });

    return ProductService.postProduct(productId, name, price)
        .then(response => dispatch({ type: POST_PRODUCT_SUCCESS, product: response }))
        .catch(error => {
            dispatch(errorActions.showError("Error posting product"));
            return dispatch({ type: POST_PRODUCT_FAIL, error });
        });
}

const reducer = (state = initialState, action ) =>{
    switch(action.type){
        case GET_PRODUCTS:{
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case GET_PRODUCTS_SUCCESS:{
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case GET_PRODUCTS_FAIL:{
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case EDIT_PRODUCT:{
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case EDIT_PRODUCT_SUCCESS:{
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case EDIT_PRODUCT_FAIL:{
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case DELETE_PRODUCT:{
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case DELETE_PRODUCT_SUCCESS:{
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case DELETE_PRODUCT_FAIL:{
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
        case POST_PRODUCT:{
            return {
                ...state,
                loading: true,
                error: null
            }
        }
        case POST_PRODUCT_SUCCESS:{
            return {
                ...state,
                loading: false,
                error: null
            }
        }
        case POST_PRODUCT_FAIL:{
            return {
                ...state,
                loading: false,
                error: action.error
            }
        }
    }
}

export default reducer;