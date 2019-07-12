import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';
import { AUTHORIZATION_HEADER } from '../constants/authorizationHeader';
import { fetchInterceptor } from '../utilities/fetchInterceptor';

const endpointBase = ENDPOINTS_BY_CONTROLLER.PRODUCT;

export const fetchProducts = () => {
    return fetchInterceptor(`${endpointBase}/ReadProducts`,{
        headers: AUTHORIZATION_HEADER()
    })
    .then(response => response.json());
}

export const editProduct = (product, productTax) => {
    return fetchInterceptor(`${endpointBase}/EditProduct`,{
        method: 'POST',
        body: JSON.stringify({
            product,
            productTax
        }),
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}

export const createProduct = (product, productTax) =>{
    return fetchInterceptor(`${endpointBase}/CreateProduct`,{
        method: 'POST',
        body: JSON.stringify({
            product,
            productTax
        }),
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}

export const deleteProduct = (productId) => {
    return fetchInterceptor(`${endpointBase}/DeleteProduct/${productId}`,{
        method: 'DELETE',
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json())
}

export const getFilteredProducts = (filter) => {
    return fetchInterceptor(`${endpointBase}/ProductsByName/${filter}`,{
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}

export const getProductById = (id) => {
    return fetchInterceptor(`${endpointBase}/GetProductById/${id}`,{
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}