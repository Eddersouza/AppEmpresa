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
import axios from 'axios';
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { useParams } from "react-router-dom";
import { LaunchErrorResponse, LaunchSucessResponse } from './Shared/CustomToast.js'

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

    let { cnpj } = useParams();

    function createCompanyDataObject(CNPJ, CompanyName, StateCode) {
        return { CNPJ, CompanyName, StateCode };
    }

    const getStates = () => {
        axios.get("api/parametros/estados")
            .then(res => {
                setstates(res.data.data.items)
            })
            .catch((error) => LaunchErrorResponse(error.response))

        return;
    }

    function gotoCompaniesPage() {
        props.history.push('/empresas');
    }

    const handleCancelClick = () => props.history.push('/empresas');
    const handleClearClick = event => {
        setcnpjValue('');
        setcompanyNameValue('');
        setselectedState('');
    };

    const handleCNPJChange = event => setcnpjValue(event.target.value);
    const handleCompanyNameChange = event => setcompanyNameValue(event.target.value);
    const handleStateChange = event => {
        console.log(event.target.value)
        setselectedState(event.target.value);
    }

    const handleCreateCompanyClick = gotoCompanies => {
        let companyData = createCompanyDataObject(cnpjValue, companyNameValue, selectedState);
        let action = null;
        if (cnpj) {
            console.log("put")
            action = axios.put('/api/empresas/' + cnpj, companyData);
        }
        else {
            console.log("post")
            action = axios.post('/api/empresas', companyData);
        }

        action.then(res => {

            LaunchSucessResponse('Estado cadastrado com sucesso.');

            if (gotoCompanies)
                gotoCompaniesPage();
        })
            .catch(error => {
                console.log(error.response)

                LaunchErrorResponse(error.response);
            })

    };

    const populatePage = () => {
        if (cnpj) {
            axios.get('/api/empresas/' + cnpj)
                .then(res => {
                    let company = res.data.data;
                    setcnpjValue(company.cnpj);
                    setcompanyNameValue(company.companyName);
                    setselectedState(company.stateCode);
                    console.log(company);
                })
                .catch(error => {
                    LaunchErrorResponse(error.response)
                })
        }
    }

    useEffect(() => {
        getStates();
        populatePage();
    }, []);

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
                            onClick={() => handleCreateCompanyClick(false)}
                        >Salvar e continuar na Página</Button>
                        <Button
                            variant="contained"
                            color="primary"
                            className={classes.button}
                            startIcon={<SaveIcon />}
                            onClick={() => handleCreateCompanyClick(true)}
                        >Salvar</Button>
                    </Grid>
                </Grid>
            </form>
            <ToastContainer />
        </>
    );
};

export default CompanyPage;