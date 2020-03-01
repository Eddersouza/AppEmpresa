import React from 'react';
import { makeStyles } from '@material-ui/styles';
import CardTotal from './CardTotal';
import Grid from '@material-ui/core/Grid';
import Beadcrumb from './Beadcrumb';

const useStyles = makeStyles(() => ({
    ink: {
        display: 'flex',
    },
    icon: {
        marginRight: 5,
        width: 20,
        height: 20,
    },
}));

function Home(props) {
    const classes = useStyles();
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