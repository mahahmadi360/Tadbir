import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { StuffData } from './components/Stuff/StuffData';
import { StuffUpdate } from './components/Stuff/StuffUpdate';
import { StuffInsert } from './components/Stuff/StuffInsert';
import {InvoiceList} from './components/Invoice/InvoiceList';
import {InvoiceView} from './components/Invoice/InvoiceView';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/stuffs' component={StuffData} />
        <Route path='/stuffs/edit/:id' component={StuffUpdate} />
        <Route path='/stuffs/create' component={StuffInsert} />
        <Route exact path='/invoices' component={InvoiceList} />
        <Route path='/invoices/view/:id' component={InvoiceView} />
        {/* <Route path='/invoices/edit/:id' component={InvoiceEdit} /> */}
        {/* <Route path='/invoices/create' component={InvoiceCreate} /> */}
      </Layout>
    );
  }
}
