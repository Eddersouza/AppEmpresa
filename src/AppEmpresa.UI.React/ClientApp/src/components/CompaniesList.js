import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
import EditIcon from '@material-ui/icons/Edit';
import { useHistory} from "react-router-dom";

const useStyles = makeStyles({
    table: {
        width: "100%",
    },
    col_cnpj: {
        width: "150px"
    }
});

const CompaniesList = (props) => {
    const classes = useStyles();
    const history = useHistory();
    
    const goEditCompanyPage = (cnpj) => {
        let path = '/empresa/' + cnpj;
        history.push(path)
    }

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
                    {props.companies.map(row => (
                        <TableRow key={row.cnpj}>
                            <TableCell>{row.cnpj}</TableCell>
                            <TableCell>{row.companyName}</TableCell>
                            <TableCell>{row.stateDescription}</TableCell>
                            <TableCell>
                                <Button
                                    color="primary"
                                    onClick={() => goEditCompanyPage(row.cnpj)}
                                    title={'Editar ' + row.companyName}
                                    variant="outlined"
                                >
                                    <EditIcon />
                                </Button>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default CompaniesList;