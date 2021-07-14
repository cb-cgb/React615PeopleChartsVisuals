import React, { Component } from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './Pages/Home';
import AddPerson from './Pages/AddPerson';
import AddMany from './Pages/AddMany';


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/addperson' component={AddPerson} />
        <Route exact path='/addmanyppl' component={AddMany} />
      </Layout>
    );
  }
}
