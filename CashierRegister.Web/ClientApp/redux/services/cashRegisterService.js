import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';

const endpointBase = ENDPOINTS_BY_CONTROLLER.CASHIER_REGISTER;

export const createCashRegister = (location) => {
    return fetch(`${endpointBase}/CreateCashRegister`, {
        method: 'POST',
        body: JSON.stringify({
            location
        }),
        headers: {
            "Content-Type": "application/json"
        }
    }).then(response => response.json() );
}

export const readCashRegister = () => {
    return fetch(`${endpointBase}/ReadCashRegister`)
        .then(response => response.json() );
}

export const deleteCashRegister = (id) => {
    return fetch(`${endpointBase}/DeleteCashRegister/${id}`,{
        method: 'DELETE'
    }).then(response => response.json() );
}