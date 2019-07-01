import React from 'react';
import Navigation from '../Navigation/navigation';
import { Switch } from 'react-router-dom';
import CashRegister from '../CashRegister/cashRegister';
import PrivateRoute from '../PrivateRoute/privateRoute';

const Homepage = (props) => {
    return(
        <div>
            <Navigation {...props} />
            <Switch>
                <PrivateRoute path="/cashRegister" component={CashRegister} {...props} />
            </Switch>
        </div>
    )
}

export default Homepage;