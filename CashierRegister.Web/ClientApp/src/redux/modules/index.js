import { combineReducers } from 'redux';

import product from './product';
import error from './error';
import cashRegister from './cashRegister';
import cashier from './cashier';
import identity from './identity';
import receipt from './receipt';

export default combineReducers({
    product,
    error,
    cashRegister,
    cashier,
    identity,
    receipt
});