import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';
import { AUTHORIZATION_HEADER } from '../constants/authorizationHeader';
import { fetchInterceptor } from '../utilities/fetchInterceptor';

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
        if(response.token)
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
        if(response.token)
            window.localStorage.setItem("token", response.token);
        return response;
    });
}

export const regenerateToken = (token) => {
    return fetch(`${endpointBase}/RegenerateToken/${token}`,{
    })
    .then(response => response.json())
    .then(response => {
        window.localStorage.setItem("token",response.token);
        window.history.pushState({},'/', window.origin + '/');
        return response;
    });
}

export const getUser = (token) => {
    return fetchInterceptor(`${endpointBase}/GetUser/${token}`,{
        headers: AUTHORIZATION_HEADER,
    }).then(response => response.json());
}