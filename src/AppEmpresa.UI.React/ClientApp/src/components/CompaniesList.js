import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const useStyles = makeStyles({
    table: {
        width: "100%",
    },
    col_cnpj: {
        width: "150px"
    }
});

function createData(cnpj, companyName, stateDescription) {
    return { cnpj, companyName, stateDescription };
}

const rows = [
    createData('23.217.580/0001-79', 'Empresa Santa Catarina', 'Santa Catarina'),
    createData('17.973.206/0001-09', 'Empresa Paraná', 'Paraná'),
    createData('66.047.520/0001-68', 'Empresa São Paulo', 'São Paulo'),
    createData('29.432.037/0001-70', 'Empresa Rio de Janeiro', 'Rio de Janeiro'),
    createData('82.011.059/0001-40', 'Empresa Espirito Santo', 'Espirito Santo')
];

const CompaniesList = (props) => {
    const classes = useStyles();

    return (
        <TableContainer component={Paper}>
            <Table className={classes.table} aria-label="Tabela de Empresas">
                <TableHead>
                    <TableRow>
                        <TableCell className={classes.col_cnpj}>CNPJ</TableCell>
                        <TableCell>Empresa</TableCell>
                        <TableCell>Estado</TableCell>
                        <TableCell>&nbsp;</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map(row => (
                        <TableRow key={row.cnpj}>
                            <TableCell>{row.cnpj}</TableCell>
                            <TableCell>{row.companyName}</TableCell>
                            <TableCell>{row.stateDescription}</TableCell>
                            <TableCell>&nbsp;</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default CompaniesList;