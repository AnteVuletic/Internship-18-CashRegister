import { combineReducers } from 'redux';

import product from './product';
import error from './error';

export default combineReducers({
    product,
    error
});