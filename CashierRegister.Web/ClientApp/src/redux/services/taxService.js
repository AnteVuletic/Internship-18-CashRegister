import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';
import { AUTHORIZATION_HEADER } from '../constants/authorizationHeader';
import { fetchInterceptor } from '../utilities/fetchInterceptor';

const endpointBase = ENDPOINTS_BY_CONTROLLER.TAX;

export const readTax = () => {
    return fetchInterceptor(`${endpointBase}/ReadTaxes`,{
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}
