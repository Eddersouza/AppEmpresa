import React from 'react';
import { makeStyles } from '@material-ui/styles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardHeader from '@material-ui/core/CardHeader';
import Grid from '@material-ui/core/Grid';
import { red } from '@material-ui/core/colors';
import CardTotal from './CardTotal';

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

    return (
        <div>
            <Grid container spacing={3}>
                <Grid item xs={12} sm={6}>
                    <CardTotal title="Empresas" quantity="15" />
                </Grid>
                <Grid item xs={12} sm={6}>
                    <CardTotal title="Fornecedores" quantity="5"/>
                </Grid>

            </Grid>
        </div>
    );
}

export default Home;