import React from 'react';
import { Route, Redirect } from "react-router-dom";
import { connect } from 'react-redux';

const PrivateRoute = ({ component: Component,identity , ...rest }) =>{
    return(
        <Route {...rest}
            render={
                identity.isAuthorized ?
                <Component {...rest} /> :
                <Redirect to='/login' />
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