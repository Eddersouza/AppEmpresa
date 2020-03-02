import React from 'react';
import './App.css';
import { Route } from 'react-router';
import LayoutApp from './components/Layout';
import Home from './components/Home';
import CompaniesPage from './components/CompaniesPage';
import CompanyPage from './components/CompanyPage';

function App() {
  return (
    <LayoutApp>
      <Route exact path='/' component={Home} />
      <Route path='/empresas' component={CompaniesPage} />
      <Route path='/empresa' component={CompanyPage} />
      {/*<Route path='/fetch-data' component={FetchData} /> */}
    </LayoutApp>
  );
}

export default App;
