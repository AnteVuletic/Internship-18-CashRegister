import React from 'react';
import Navigation from '../Navigation/navigation';
import { Switch } from 'react-router-dom';
import CashRegister from '../CashRegister/cashRegister';
import Products from '../Products/products';
import PrivateRoute from '../PrivateRoute/privateRoute';

const Homepage = (props) => {
    return(
        <div>
            <Navigation {...props} />
            <Switch>
                <PrivateRoute path="/products" component={Products} {...props} />
                <PrivateRoute exactPath="/" component={CashRegister} {...props} />
            </Switch>
        </div>
    )
}

export default Homepage;