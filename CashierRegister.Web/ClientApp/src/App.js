import React, { Component } from 'react';
import { Switch, Route, Redirect } from "react-router-dom";
import LoginPage from './components/LoginPage/loginPage'
import Error from "./components/Error/Error";
import PrivateRoute from './components/PrivateRoute/privateRoute';
import Homepage from './components/Homepage/homepage';


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Switch>
        <PrivateRoute path="/" component={Homepage} {...this.props} /> } />
        <Route path="/login" render={(props) => <LoginPage {...props} /> } />
        <Redirect to="/login" />
        <Error />
      </Switch>
    );
  }
}
