import { endpointBase } from '../constants/constants';

export const createCashier = (username) => {
    return fetch(`${endpointBase}/CreateCashier`,{
        username
    }).then(response => response.json);
}

export const deleteCashier = (id) => {
    return fetch(`${endpointBase}/DeleteCashier/${id}`,{
        method: 'DELETE'
    }).then(response => response.json());
}

export const readCashier = (id) => {
    return fetch(`${endpointBase}/ReadCashier/${id}`)
        .then(response => response.json());
}