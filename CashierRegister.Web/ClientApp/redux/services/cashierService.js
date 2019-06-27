import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';

const endpointBase = ENDPOINTS_BY_CONTROLLER.CASHIER;

export const createCashier = (username, password) => {
    return fetch(`${endpointBase}/CreateCashier`,{
        method: 'POST',
        body: JSON.stringify({
            username,
            password
        }),
        headers: {
            "Content-Type": "application/json"
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
        body: JSON.stringify({
            id,
            password
        }),
        headers: {
            "Content-Type": "application/json"
        }
    })
}