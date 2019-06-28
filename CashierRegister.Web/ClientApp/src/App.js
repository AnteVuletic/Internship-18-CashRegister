import React, { Component } from 'react';
import { Switch, Route, Redirect } from "react-router-dom";
import LoginPage from './components/LoginPage/loginPage'
import Error from "./components/Error/error";
import PrivateRoute from './components/PrivateRoute/privateRoute';
import CashRegisters from './components/CashRegister/cashRegisters';


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Switch>
        <Route exact path="/" render={(props) => }
        <Route path="/login" render={(props) => <LoginPage {...props} /> } />
        <PrivateRoute path="/cashRegister" render={(props) => <CashRegisters {...props} />} />
        <Redirect to="/login" />
        <Error />
      </Switch>
    );
  }
}
