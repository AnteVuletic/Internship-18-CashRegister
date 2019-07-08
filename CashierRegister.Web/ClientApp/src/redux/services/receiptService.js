import { ENDPOINTS_BY_CONTROLLER } from '../constants/constants';
import { AUTHORIZATION_HEADER } from '../constants/authorizationHeader';
import { fetchInterceptor } from '../utilities/fetchInterceptor';

const endpointBase = ENDPOINTS_BY_CONTROLLER.PRODUCT;

export default createReceipt = (cashRegisterId, products) => {
    return fetchInterceptor(`${endpointBase}/CreateReceipt`,{
        method: 'POST',
        body: JSON.stringify({
            cashRegisterId,
            products
        }),
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}

export default deleteReceipt = (receiptId) => {
    return fetchInterceptor(`${endpointBase}/DeleteReceipt/${receiptId}`,{
        method: 'DELETE',
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}

export default receiptsByShift = (shiftId) => {
    return fetchInterceptor(`${endpointBase}/ReceiptsByShift/${shiftId}`,{
        method: 'GET',
        headers: AUTHORIZATION_HEADER()
    }).then(response => response.json());
}