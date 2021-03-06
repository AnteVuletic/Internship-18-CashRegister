import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';
import { AUTHORIZATION_HEADER } from '../constants/authorizationHeader';
import { fetchInterceptor } from '../utilities/fetchInterceptor';

const endpointBase = ENDPOINTS_BY_CONTROLLER.SHIFT;

export const startShift = (cashierId, cashRegisterId) => {
    return fetchInterceptor(`${endpointBase}/StartShift`,{
        method: 'POST',
        headers: AUTHORIZATION_HEADER(),
        body: JSON.stringify({
            cashierId,
            cashRegisterId
        })
    });
}

export const endShift = (cashierId, cashRegisterId) => {
    return fetchInterceptor(`${endpointBase}/EndShift`,{
        method: 'POST',
        headers: AUTHORIZATION_HEADER(),
        body: JSON.stringify({
            cashierId,
            cashRegisterId
        })
    });
}

export const editShift = (cashierId, cashRegisterId, startOfShift, endOfShift) => {
    return fetchInterceptor(`${endpointBase}/EditShift`,{
        method: 'POST',
        headers: AUTHORIZATION_HEADER(),
        body: JSON.stringify({
            cashierId,
            cashRegisterId,
            startOfShift,
            endOfShift
        })
    });
}

export const checkStartedShiftForCashier = (cashierId) => {
    return fetchInterceptor(`${endpointBase}/CheckStartedShiftForCashier/${cashierId}`,{
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}