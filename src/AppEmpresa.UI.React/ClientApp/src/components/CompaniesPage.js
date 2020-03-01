import React, { useState, useEffect } from 'react';
import Beadcrumb from './Beadcrumb';
import CompaniesList from './CompaniesList';

function createData(cnpj, companyName, stateDescription) {
    return { cnpj, companyName, stateDescription };
}

const companiesList = [
    // createData('23.217.580/0001-79', 'Empresa Santa Catarina', 'Santa Catarina'),
    // createData('17.973.206/0001-09', 'Empresa Paraná', 'Paraná'),
    // createData('66.047.520/0001-68', 'Empresa São Paulo', 'São Paulo'),
    // createData('29.432.037/0001-70', 'Empresa Rio de Janeiro', 'Rio de Janeiro'),
    // createData('82.011.059/0001-40', 'Empresa Espirito Santo', 'Espirito Santo')
];


const CompaniesPage = () => {
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
            <h2>Empresas:</h2>
            <br />
            <CompaniesList companies={companies} />
        </>
    );
};

export default CompaniesPage;