import React, { useState, useEffect } from 'react';
import Button from '@material-ui/core/Button';
import AddToPhotosIcon from '@material-ui/icons/AddToPhotos';
import Grid from '@material-ui/core/Grid';

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

    async function getCompanies() {
        let response = await fetch("api/empresas")

        let data = await response.json();

        return data;
    }

    useEffect(() => {
        getCompanies()
            .then(res => {
                setcompanies(res.data.items)
            })
            .catch((error) => console.log(error))
    }, [setcompanies]);

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