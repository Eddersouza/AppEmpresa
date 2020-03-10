import React, { useState } from 'react';
import Snackbar from '@material-ui/core/Snackbar';
import MuiAlert from '@material-ui/lab/Alert';
import { makeStyles } from '@material-ui/core/styles';

function Alert(props) {
    return <MuiAlert elevation={6} variant="filled" {...props} />;
}

const useStyles = makeStyles(theme => ({
    root: {
        width: '100%',
        '& > * + *': {
            marginTop: theme.spacing(2),
        },
    },
}));

export default function SnackbarAppEmpresa(props) {
    const classes = useStyles();
    const [openError, setOpenError] = useState(props.openError);
    const [openSuccess, setOpenSuccess] = useState(props.openSuccess)
    const [openWarning, setOpenWarning] = useState(props.openWarning)

    const handleCloseError = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpenError(false);
    };

    const handleCloseSuccess = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpenSuccess(false);
    };

    const handleCloseWarning = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpenWarning(false);
    };
    
    return (
        <div className={classes.root}>
            <Snackbar open={openError} autoHideDuration={2000} onClose={handleCloseError}>
                <Alert onClose={handleCloseError} severity="error">
                    This is a success message!
                </Alert>
            </Snackbar>
            <Snackbar open={openWarning} autoHideDuration={2000} onClose={handleCloseWarning}>
                <Alert onClose={handleCloseWarning} severity="warning">
                    This is a success message!
                </Alert>
            </Snackbar>
            <Snackbar open={openSuccess} autoHideDuration={2000} onClose={handleCloseSuccess}>
                <Alert onClose={handleCloseSuccess} severity="success">
                    This is a success message!
                </Alert>
            </Snackbar>
        </div>
    );
}
