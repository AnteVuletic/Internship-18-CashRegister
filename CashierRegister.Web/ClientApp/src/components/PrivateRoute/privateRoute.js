import React from 'react';
import { Route } from "react-router-dom";
import LoginPage from '../LoginPage/loginPage';

const PrivateRoute = ({ path, exactPath, component: Component }) =>{
    let token = window.localStorage.getItem('token');
    let isAuthorized = token != null;
    if(path === '')
        return(
            <Route exactPath={exactPath}
                render={(props) =>
                    isAuthorized ?
                    <Component {...props} /> :
                    <LoginPage {...props} />
                } 
            />
        )
    return(
        <Route path={path}
            render={(props) =>
                isAuthorized ?
                <Component {...props} /> :
                <LoginPage {...props} />
            } 
        />
    )    
}

export default PrivateRoute;