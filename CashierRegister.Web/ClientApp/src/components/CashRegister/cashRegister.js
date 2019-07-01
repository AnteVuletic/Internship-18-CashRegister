import React from 'react';
import { Switch } from 'react-router-dom';
import PrivateRoute from '../PrivateRoute/privateRoute';
import CashRegisterList from './cashRegisterList';

const CashRegister = (props) => {
    return(
        <Switch>
            <PrivateRoute path="/all" component={CashRegisterList} {...props} />
        </Switch>
    )
}

export default CashRegister;