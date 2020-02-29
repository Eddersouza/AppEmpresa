import React from 'react';
import { makeStyles } from '@material-ui/styles';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import Grid from '@material-ui/core/Grid';

import CardTotal from './CardTotal';
import Link from '@material-ui/core/Link';
import HomeIcon from '@material-ui/icons/Home';
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
            <div>
                <Breadcrumbs aria-label="breadcrumb">
                    <Link color="inherit" href="/" className={classes.link}>
                        <HomeIcon className={classes.icon} />
                        App Empresas
                    </Link>
                </Breadcrumbs>
            </div>
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