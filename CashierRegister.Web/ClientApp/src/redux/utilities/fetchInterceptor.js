import * as LoginService from '../services/loginService';

export const fetchInterceptor = (endpoint, details) => {
    try{
        fetch(endpoint, details)
        .then(response => {
            if(!response.ok) throw 'unauthorizedException';
            return response;
        })
    }catch(exception){
        const token = window.sessionStorage.getItem('token');
        if(!token)
            LoginService.regenerateToken(token);
        window.history.pushState({},'/login', window.origin+ '/login');              
    }
}