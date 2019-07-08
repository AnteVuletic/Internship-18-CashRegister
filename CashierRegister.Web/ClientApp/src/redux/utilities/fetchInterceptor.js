import * as LoginService from '../services/loginService';

export const fetchInterceptor = function(endpoint, details) {
        return fetch(endpoint, details)
        .then(response => {
            if(!response.ok){
                const token = window.localStorage.getItem('token');
                if(token !== undefined || token !== null){
                    return LoginService.regenerateToken().then(_ =>{
                        return fetch(endpoint,details);
                    });   
                }
            }else{
                return response;
            }
        })
        .catch(error => {
            window.localStorage.removeItem('token');
            window.location.assign('/login');
        })
        .then(response => response);
}