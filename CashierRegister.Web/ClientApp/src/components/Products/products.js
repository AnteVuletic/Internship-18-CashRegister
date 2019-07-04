import React from 'react';
import { Switch } from 'react-router-dom';
import PrivateRoute from '../PrivateRoute/privateRoute';
import ProductList from './productList';

const CashRegister = (props) => {
    return(
        <Switch>
            <PrivateRoute path="/products" component={ProductList} {...props} />
        </Switch>
    )
}

export default CashRegister;