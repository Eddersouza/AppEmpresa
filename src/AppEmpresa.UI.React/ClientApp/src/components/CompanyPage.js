import React, { useState } from 'react';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import { makeStyles } from '@material-ui/core/styles';
import FormControl from '@material-ui/core/FormControl';
import InputLabel from '@material-ui/core/InputLabel';
import Select from '@material-ui/core/Select';
import Button from '@material-ui/core/Button';
import SaveIcon from '@material-ui/icons/Save';
import BlockIcon from '@material-ui/icons/Block';
import ClearIcon from '@material-ui/icons/Clear';

import Beadcrumb from './Beadcrumb';

function createState(code, stateName) {
    return { code, stateName };
}

const states = [
    createState("SC", "Santa Catarina"),
    createState("PR", "Paraná"),
    createState("RS", "Rio Grande do Sul"),
    createState("SP", "São Paulo"),
    createState("RJ", "Rio de Janeiro")
];

const useStyles = makeStyles(theme => ({
    formControl: {
        margin: theme.spacing(1),
        flexGrow: 1,
        //minWidth: 120,
    },
    selectEmpty: {
        marginTop: theme.spacing(2),
    },
    button: {
        margin: theme.spacing(1),
    },
}));

const beadcrumb = [
    {
        title: 'App Empresa',
        link: '/'
    },
    {
        title: 'Empresas',
        link: '/empresas'
    },
    {
        title: 'Nova Empresa',
        link: ''
    }
];

const CompanyPage = () => {
    const [selectedState, setselectedState] = useState('');
    const classes = useStyles();
    const handleChange = event => {
        setselectedState(event.target.value);
    };
    return (
        <>
            <br />
            <Beadcrumb data={beadcrumb} />
            <br />
            <h2>Nova Empresa:</h2>

            <form noValidate autoComplete="off">
                <Grid container spacing={6}>
                    <Grid item xs={12} sm={6}>
                        <FormControl fullWidth className={classes.formControl}>
                            <TextField fullWidth id="txtCnpj" label="CNPJ" />
                        </FormControl>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <FormControl fullWidth className={classes.formControl}>
                            <InputLabel htmlFor="age-native-simple">Estado</InputLabel>
                            <Select
                                native
                                value={selectedState}
                                onChange={handleChange}
                                inputProps={{
                                    name: 'selSelectedState',
                                    id: 'age-native-simple',
                                }}
                            >
                                <option value="" />
                                {states.map((value, index) => {
                                    return (<option key={value.code} value={value.code}>{value.stateName}</option>)
                                })}
                            </Select>
                        </FormControl>
                    </Grid>
                </Grid>
                <Grid container spacing={5}>
                    <Grid item xs={12} sm={12}>
                        <FormControl fullWidth className={classes.formControl}>
                            <TextField fullWidth id="txtCompanyName" label="Nome da Empresa" />
                        </FormControl>
                    </Grid>
                </Grid>
                <Grid container spacing={5}>
                    <Grid item xs={12} sm={12}>
                        &nbsp;
                    </Grid>
                </Grid>
                <Grid container spacing={5}>
                    <Grid item xs={12} sm={12} align='right'>
                        <Button
                            variant="contained"
                            color="secondary"
                            className={classes.button}
                            startIcon={<BlockIcon />}
                        >Cancelar</Button>
                        <Button
                            variant="contained"
                            className={classes.button}
                            startIcon={<ClearIcon />}
                        >Limpar</Button>
                        <Button
                            variant="contained"
                            color="primary"
                            className={classes.button}
                            startIcon={<SaveIcon />}
                        >Salvar</Button>
                    </Grid>
                </Grid>
            </form>
        </>
    );
};

export default CompanyPage;