import React from 'react';
import Beadcrumb from './Beadcrumb';
import CompaniesList from './CompaniesList';

const CompaniesPage = () => {
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

    return (
        <>
            <br />
            <Beadcrumb data={beadcrumb} />
            <br />
            <h2>Empresas:</h2>
            <br />
            <CompaniesList />
        </>
    );
};

export default CompaniesPage;