import React from 'react';
import CardTotal from './CardTotal';
import Grid from '@material-ui/core/Grid';
import Beadcrumb from './Beadcrumb';

function Home(props) {
    const beadcrumb = [
        {
            title: 'App Empresa',
            link: '/'
        }
    ];

    return (
        <div>
            <br />
            <Beadcrumb data={beadcrumb} />
            <Grid container spacing={3}>
                <Grid item xs={12} sm={6}>
                    <CardTotal title="Empresas" quantity="15" />
                </Grid>
                <Grid item xs={12} sm={6}>
                    <CardTotal title="Fornecedores" quantity="5" />
                </Grid>
            </Grid>
        </div>
    );
}

export default Home;