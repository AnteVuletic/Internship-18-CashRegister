import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';

const endpointBase = ENDPOINTS_BY_CONTROLLER.PRODUCT;

export const fetchProducts = () => {
    return fetch(`${endpointBase}/ReadProducts`).then(response => response.json());
}

export const editProduct = (productId, name, price) => {
    return fetch(`${endpointBase}/EditProduct`,{
        method: 'POST',
        body: JSON.stringify({
            productId,
            name,
            price
        }),
        headers: {
            "Content-Type": "application/json"
        }
    }).then(response => response.json());
}

export const createProduct = (name, price ) =>{
    return fetch(`${endpointBase}/CreateProduct`,{
        method: 'POST',
        body: JSON.stringify({
            name,
            price
        }),
        headers: {
            "Content-Type": "application/json"
        }
    }).then(response => response.json());
}

export const deleteProduct = (productId) => {
    return fetch(`${endpointBase}/DeleteProduct/${productId}`,{
        method: 'DELETE'
    });
}