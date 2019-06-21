import { endpointBase } from '../constants/constants';

export const createCashRegister = (location) => {
    return fetch(`${endpointBase}/CreateCashRegister`, {
        method: 'POST',
        body: {
            location
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