import { endpointBase } from '../constants/constants';

export const fetchProducts = () => {
    return fetch(`${endpointBase}/ReadProducts`).then(response => response.json());
}

export const editProduct = (productId, name, price) => {
    return fetch(`${endpointBase}/EditProduct`,{
        method: 'POST',
        body:{
            productId,
            name,
            price
        }
    }).then(response => response.json());
}

export const createProduct = (name, price ) =>{
    return fetch(`${endpointBase}/CreateProduct`,{
        method: 'POST',
        body: {
            name,
            price
        }
    }).then(response => response.json());
}

export const deleteProduct = (productId) => {
    return fetch(`${endpointBase}/DeleteProduct/${productId}`,{
        method: 'DELETE'
    });
}