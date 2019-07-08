export const AUTHORIZATION_HEADER = () =>{
    return{
        "Content-Type": "application/json", 
        "Accept": "application/json",
        "Authorization": "Bearer " + window.localStorage.getItem('token')
    };
};