import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';
import { AUTHORIZATION_HEADER } from '../constants/authorizationHeader';
import { fetchInterceptor } from '../utilities/fetchInterceptor';

const endpointBase = ENDPOINTS_BY_CONTROLLER.CASHIER_REGISTER;

export const createCashRegister = (location) => {
    return fetchInterceptor(`${endpointBase}/CreateCashRegister`, {
        method: 'POST',
        body: JSON.stringify({
            location
        }),
        headers: AUTHORIZATION_HEADER
    }).then(response => response.json() );
}

export const readCashRegister = () => {
    return fetchInterceptor(`${endpointBase}/ReadCashRegister`, {
        headers: AUTHORIZATION_HEADER
    }).then(response => response.json() );
}

export const deleteCashRegister = (id) => {
    return fetchInterceptor(`${endpointBase}/DeleteCashRegister/${id}`, {
        method: 'DELETE',
        headers: AUTHORIZATION_HEADER
    }).then(response => response.json() );
}

export const editCashRegister = (id, location) => {
    return fetchInterceptor(`${endpointBase}/EditCashRegister`, {
        method: 'POST',
        headers: AUTHORIZATION_HEADER,
        body: JSON.stringify({
            id,
            location
        })
    }).then(response => response.json() );
}