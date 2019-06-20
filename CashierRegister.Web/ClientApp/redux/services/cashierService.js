import { endpointBase } from '../constants/constants';

export const createCashier = (username) => {
    return fetch(`${endpointBase}/CreateCashier`,{
        method: 'POST',
        body: {
            username
        }
    }).then(response => response.json);
}

export const deleteCashier = (id) => {
    return fetch(`${endpointBase}/DeleteCashier/${id}`,{
        method: 'DELETE'
    }).then(response => response.json());
}

export const readCashier = () => {
    return fetch(`${endpointBase}/ReadCashier`)
        .then(response => response.json());
}

export const editCashierPassword = (id, password) =>{
    return fetch(`${endpointBase}/EditCashierPassowrd`,{
        method: 'POST',
        body: {
            id,
            password
        }
    })
}