import React from 'react';
import { connect } from 'react-redux';
import { loginCashier, registerCashier, hasToken } from '../../redux/modules/identity';
import '../styles/forms.css';

class LoginPage extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            username: '',
            password: '',
            passwordRepeated: '',
            isLogin: true,
            hasLoginFailed: false,
            isPasswordMissmatch: false
        }
    }

    componentWillMount(){
        let token = window.localStorage.getItem("token");
        if(token){
            this.props.hasToken(token)
                .then(_ => {
                    this.props.history.push("/")
                });
        }
    }

    handleInputChange = (event) =>{
        const value = event.target.value;
        const name = event.target.name;

        this.setState({
            [name]: value
        });
    }

    handleSubmit = (event) =>{
        event.preventDefault();
        const { username, password, passwordRepeated, isLogin } = this.state;
        
        if(isLogin){
            this.props.loginCashier(username, password)
                .then(response =>{
                    this.props.history.push('/');
                })
                .catch(error => {
                    this.setState({
                        hasLoginFailed: true
                    });
                });
            return;
        }
        if(password !== passwordRepeated && isLogin) {
            this.setState({
                isPasswordMissmatch: true
            });
            return;
        }
        this.props.registerCashier(username,password)
            .then(response => {
                this.props.history.push('/');
            });
    }

    render(){
        const { isLogin, hasLoginFailed, isPasswordMissmatch } = this.state;
        const { loading } = this.props.identity;
        if(loading){
            return <div className="lds-dual-ring">

            </div>
        }
        const passwordMissmatchWarningMessage = isPasswordMissmatch&&!isLogin ? <div>Password missmatch try again</div> : "";
        const loginFailedWarningMessage = hasLoginFailed&&isLogin ? <div>Login has failed try again</div> : "";
    const registerRepeatPasswordInput = !isLogin ? <input name="repeatPassword" type="text" placeholder="Repeat password" onChange={this.handleInputChange} /> : "";
        return(
            <div className="login">
                <header className="login__header">
                    {passwordMissmatchWarningMessage}
                    {loginFailedWarningMessage}
                </header>
                <form onSubmit={this.handleSubmit} className="login__body">
                    <input name="username" type="text" placeholder="Enter username" onChange={this.handleInputChange} />
                    <input name="password" type="text" placeholder="Enter password" onChange={this.handleInputChange} />
                    {registerRepeatPasswordInput}
                    <input type="submit" className="login__submit" value="Submit" />
                </form>
                <footer className="login__footer">
                    <button onClick={()=> this.setState({isLogin: true}) }>Login</button>
                    <button onClick={()=> this.setState({isLogin: false})}>Register</button>
                </footer>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    identity: state.identity
});

const mapDispatchToProps = {
    loginCashier,
    registerCashier,
    hasToken
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(LoginPage);