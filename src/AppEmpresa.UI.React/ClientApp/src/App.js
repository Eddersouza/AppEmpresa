import React from 'react';
import './App.css';
import { Route } from 'react-router';
import LayoutApp  from './components/Layout';
import Home from './components/Home';

function App() {
  return (
    <LayoutApp>
    <Route exact path='/' component={Home} />
    {/* <Route path='/counter' component={Counter} />
    <Route path='/fetch-data' component={FetchData} /> */}
  </LayoutApp>
  );
}

export default App;
