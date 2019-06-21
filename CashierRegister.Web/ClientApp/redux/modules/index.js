import { combineReducers } from 'redux';

import product from './product';
import error from './error';
import cashRegister from './cashRegister';
import cashier from './cashier';

export default combineReducers({
    product,
    error,
    cashRegister,
    cashier
});