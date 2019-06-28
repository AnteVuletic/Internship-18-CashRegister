export const AUTHORIZATION_HEADER = {
    "Content-Type": "application/json", 
    "Accept": "application/json",
    "Authorization": "Bearer " + localStorage.getItem('token')
};