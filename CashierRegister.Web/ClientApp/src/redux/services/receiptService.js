import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';
import { AUTHORIZATION_HEADER } from '../constants/authorizationHeader';
import { fetchInterceptor } from '../utilities/fetchInterceptor';

const endpointBase = ENDPOINTS_BY_CONTROLLER.RECEIPT;

export const createReceipt = (identity, products) => {
    return fetchInterceptor(`${endpointBase}/CreateReceipt`,{
        method: 'POST',
        body: JSON.stringify({
            receipt: {
                cashRegisterCashier:{
                    cashierId: identity.cashierId,
                    cashRegisterId: identity.cashRegisterId
                }
            },
            productsOnReceipt: products 
        }),
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}