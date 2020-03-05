import React, { useState, useEffect } from 'react';
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

const CompanyPage = (props) => {
    const [states, setstates] = useState([]);
    const [cnpjValue, setcnpjValue] = useState('');
    const [companyNameValue, setcompanyNameValue] = useState('');

    const [selectedState, setselectedState] = useState('');

    const classes = useStyles();

    async function getStates() {
        let response = await fetch("api/parametros/estados")

        let data = await response.json();

        return data;
    }

    const handleCancelClick = () => props.history.push('/empresas');
    const handleClearClick = event => {
        setcnpjValue('');
        setcompanyNameValue('');
        setselectedState('');
    };
    const handleCNPJChange = event => setcnpjValue(event.target.value);
    const handleCompanyNameChange = event => setcompanyNameValue(event.target.value);
    const handleStateChange = event => setselectedState(event.target.value);


    useEffect(() => {
        getStates()
            .then(res => {
                setstates(res.data.items)
            })
            .catch((error) => console.log(error))
    }, [setstates]);

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
                            <TextField fullWidth
                                id="txtCnpj"
                                label="CNPJ"
                                value={cnpjValue}
                                onChange={handleCNPJChange} />
                        </FormControl>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <FormControl fullWidth className={classes.formControl}>
                            <InputLabel htmlFor="age-native-simple">Estado</InputLabel>
                            <Select
                                native
                                value={selectedState}
                                onChange={handleStateChange}
                                inputProps={{
                                    name: 'selSelectedState',
                                    id: 'age-native-simple',
                                }}
                            >
                                <option value="" />
                                {states.map((value, index) => {
                                    return (<option key={value.code} value={value.code}>{value.name}</option>)
                                })}
                            </Select>
                        </FormControl>
                    </Grid>
                </Grid>
                <Grid container spacing={5}>
                    <Grid item xs={12} sm={12}>
                        <FormControl fullWidth className={classes.formControl}>
                            <TextField fullWidth
                                id="txtCompanyName"
                                label="Nome da Empresa"
                                value={companyNameValue}
                                onChange={handleCompanyNameChange} />
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
                            onClick={handleCancelClick}
                        >Cancelar</Button>
                        <Button
                            variant="contained"
                            className={classes.button}
                            startIcon={<ClearIcon />}
                            onClick={handleClearClick}
                        >Limpar</Button>
                        <Button
                            variant="outlined"
                            color="primary"
                            className={classes.button}
                            startIcon={<SaveIcon />}
                        >Salvar e continuar na Página</Button>
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