import React from 'react';
import './App.css';
import { Route, Switch } from 'react-router';
import LayoutApp from './components/Layout';
import Home from './components/Home';
import CompaniesPage from './components/CompaniesPage';
import CompanyPage from './components/CompanyPage';

function App() {
  return (
    <LayoutApp>
      <Switch>
        <Route exact path='/' component={Home} />
        <Route path='/empresas' component={CompaniesPage} />
        <Route path='/empresa/nova' component={CompanyPage} />
        <Route path='/empresa/:cnpj' component={CompanyPage} />
      </Switch>
    </LayoutApp>
  );
}

export default App;
