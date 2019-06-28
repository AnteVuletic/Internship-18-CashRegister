import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';

const endpointBase = ENDPOINTS_BY_CONTROLLER.LOGIN;

export const loginCashier = (username, password) => {
    return fetch(`${endpointBase}/LoginCashier`,{
        method: 'POST',
        body: JSON.stringify({
            username,
            password
        }),
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(response => response.json())
    .then(response => {
        window.localStorage.setItem("token", response.token);
        return response;
    });
}

export const registerCashier = (username, password) => {
    return fetch(`${endpointBase}/RegisterCashier`,{
        method: 'POST',
        body: JSON.stringify({
            username,
            password
        }),
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(response => response.json())
    .then(response => {
        window.localStorage.setItem("token", response.token);
        return response;
    });
}

export const regenerateToken = (token) => {
    return fetch(`${endpointBase}/RegenerateToken`,{
        method: 'POST',
        body: JSON.stringify({
            token
        }),
        headers: {
            "Content-Type": "application/json"
        }
    }).then(response => response.json())
    .then(response => {
        window.localStorage.setItem("token",response.token);
        return response;
    });
}