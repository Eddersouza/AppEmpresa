import React, { useState, useEffect } from 'react';
import Button from '@material-ui/core/Button';
import AddToPhotosIcon from '@material-ui/icons/AddToPhotos';
import Grid from '@material-ui/core/Grid';
import axios from 'axios';
import { LaunchErrorResponse } from './Shared/CustomToast.js'

import Beadcrumb from './Beadcrumb';
import CompaniesList from './CompaniesList';

const companiesList = [];

const CompaniesPage = (props) => {
    const [companies, setcompanies] = useState(companiesList);

    const beadcrumb = [
        {
            title: 'App Empresa',
            link: '/'
        },
        {
            title: 'Empresas',
            link: ''
        }
    ];

    const goToCompany = () => {
        props.history.push('/empresa/nova')
    }

    function getCompanies() {
        axios.get("api/empresas")
            .then(res => {                
                setcompanies(res.data.data.items);
            })
            .catch((error) =>  {                
                LaunchErrorResponse(error.response)
            })
    }

    useEffect(() => {
        getCompanies();
    }, []);

    return (
        <>
            <br />
            <Beadcrumb data={beadcrumb} />
            <br />
            <h2>
                <Grid container spacing={3}>
                    <Grid item xs={12} sm={8}>
                        Empresas:
                </Grid>
                    <Grid item xs={12} sm={4} align='center'>
                        <Button
                            variant="contained"
                            color="primary"
                            startIcon={<AddToPhotosIcon />}
                            onClick={goToCompany}
                        >
                            Nova Empresa
                        </Button>
                    </Grid>
                </Grid>
            </h2>
            <br />
            <CompaniesList companies={companies} />
        </>
    );
};

export default CompaniesPage;