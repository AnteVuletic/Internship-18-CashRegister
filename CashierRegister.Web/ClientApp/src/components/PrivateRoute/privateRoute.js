import React from 'react';
import { Route } from "react-router-dom";
import { connect } from 'react-redux';
import LoginPage from '../LoginPage/loginPage';

const PrivateRoute = ({ path, exactPath, component: Component, identity }) =>{
    return(
        <Route path={path} exactPath={exactPath}
            render={(props) =>
                identity.isAuthorized ?
                <Component {...props} /> :
                <LoginPage {...props} />
             } 
        />
    )
}

const MapStateToProps = state => ({
    identity: state.identity
});

export default connect(
    MapStateToProps
)(PrivateRoute);