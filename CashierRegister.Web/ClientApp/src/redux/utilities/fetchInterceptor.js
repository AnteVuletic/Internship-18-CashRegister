import * as LoginService from '../services/loginService';

export const fetchInterceptor = function(endpoint, details) {
        return fetch(endpoint, details)
        .then(response => {
            if(!response.ok){
                const token = window.localStorage.getItem('token');
                if(token !== undefined || token !== null){
                    return LoginService.regenerateToken(token)        
                    .then(_ => {
                        return fetch(endpoint,details)
                    })
                    .then(response => {
                        return response;
                    });
                }
                window.history.pushState({},'/login', window.origin + '/login');
            }
            return response;
        });
}