import React from 'react';
import Beadcrumb from './Beadcrumb';

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
            Empresas
        </>
    );
};

export default CompaniesPage;