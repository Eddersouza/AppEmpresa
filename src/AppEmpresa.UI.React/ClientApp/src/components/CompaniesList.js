import React, { useState } from 'react';
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
import DeleteForeverIcon from '@material-ui/icons/DeleteForever';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { useHistory } from "react-router-dom";

const useStyles = makeStyles({
    table: {
        width: "100%",
    },
    col_cnpj: {
        width: "150px"
    }
});


const CompaniesList = (props) => {
    const [openDialogDelete, setOpenDialogDelete] = useState(false);
    const [selectedCompany, setSelectedCompany] = useState({});
    const classes = useStyles();
    const history = useHistory();

    const goEditCompanyPage = (cnpj) => {
        let path = '/empresa/' + cnpj;
        history.push(path)
    }

    const handleClickOpenDialogDelete = (company) => {
        setSelectedCompany(company);
        setOpenDialogDelete(true);
    };

    const handleCloseDialogDelete = () => {
        setSelectedCompany({});
        setOpenDialogDelete(false);
    };

    return (
        <>
            <Dialog
                open={openDialogDelete}
                onClose={handleCloseDialogDelete}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">{"Comfirme a Exclusão"}</DialogTitle>
                <DialogContent>
                    <DialogContentText id="alert-dialog-description">
                        Deseja excluir a empresa <br />
                        {selectedCompany.cnpj} - {selectedCompany.companyName}?
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseDialogDelete} color="primary">
                        Cancelar
                    </Button>
                    <Button onClick={handleCloseDialogDelete} color="primary" autoFocus>
                        Excluir
                    </Button>
                </DialogActions>
            </Dialog>
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
                                    <Button
                                        color="secondary"
                                        onClick={() => handleClickOpenDialogDelete(row)}
                                        title={'Excluir ' + row.companyName}
                                        variant="outlined"
                                    >
                                        <DeleteForeverIcon />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </>
    );
};

export default CompaniesList;