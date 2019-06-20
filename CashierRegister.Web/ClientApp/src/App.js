import React, { Component } from 'react';
import { Switch, Route, Redirect } from "react-router-dom";
import Error from "./components/Error";


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Switch>

        <Error />
      </Switch>
    );
  }
}
