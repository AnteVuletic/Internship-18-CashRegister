import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';
import { AUTHORIZATION_HEADER } from '../constants/authorizationHeader';
import { fetchInterceptor } from '../utilities/fetchInterceptor';

const endpointBase = ENDPOINTS_BY_CONTROLLER.CASHIER;
export const createCashier = (username, password) => {
    return fetchInterceptor(`${endpointBase}/CreateCashier`,{
        method: 'POST',
        body: JSON.stringify({
            username,
            password
        }),
        headers: AUTHORIZATION_HEADER
    }).then(response => response.json);
}

export const deleteCashier = (id) => {
    return fetchInterceptor(`${endpointBase}/DeleteCashier/${id}`,{
        method: 'DELETE',
        headers: AUTHORIZATION_HEADER
    }).then(response => response.json())
}

export const readCashier = () => {
    return fetchInterceptor(`${endpointBase}/ReadCashier`, {
        headers: AUTHORIZATION_HEADER
    }).then(response => response.json());
}

export const editCashierPassword = (id, password) =>{
    return fetchInterceptor(`${endpointBase}/EditCashierPassowrd`,{
        method: 'POST',
        body: JSON.stringify({
            id,
            password
        }),
        headers: AUTHORIZATION_HEADER
    }).then(response => response.json());
}