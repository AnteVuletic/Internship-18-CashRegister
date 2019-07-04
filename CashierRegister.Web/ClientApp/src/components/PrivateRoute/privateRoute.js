import React from 'react';
import { Route } from "react-router-dom";
import { connect } from 'react-redux';
import LoginPage from '../LoginPage/loginPage';

const PrivateRoute = ({ path, exactPath, component: Component, identity }) =>{
    if(path === '')
        return(
            <Route exactPath={exactPath}
                render={(props) =>
                    identity.isAuthorized ?
                    <Component {...props} /> :
                    <LoginPage {...props} />
                } 
            />
        )
    return(
        <Route path={path}
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