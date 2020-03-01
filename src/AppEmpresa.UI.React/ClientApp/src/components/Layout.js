import React from 'react';
import { fade, makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import { Link } from 'react-router-dom';

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
  },
  menu: {
    position: 'relative',
    borderRadius: theme.shape.borderRadius,
    '&:hover': {
      backgroundColor: fade(theme.palette.common.white, 0.25),
    },
    marginRight: theme.spacing(2),
    marginLeft: 0,
    width: '100%',
    [theme.breakpoints.up('sm')]: {
      marginLeft: theme.spacing(3),
      width: 'auto',
    },
    padding: '15px'
  },
  link: {
    color: '#fff',
    textDecoration: 'none',
    '&:hover': {
      textDecoration: 'none',
    },
  }
}));

function LayoutApp(props) {
  const classes = useStyles();

  const preventDefault = event => event.preventDefault();
  return (
    <>
      <div className={classes.root}>
        <AppBar position="static">
          <Toolbar>
            <Typography variant="h6" className={classes.title}>
              <Link to='/' className={classes.link} >
                App Empresa
              </Link>
            </Typography>
            <div className={classes.menu}>
              <Typography >
                <Link to='/empresas' className={classes.link} >
                  Empresas
              </Link>
              </Typography>
            </div>
          </Toolbar>
        </AppBar>
      </div>
      <Container>
        {props.children}
      </Container>
    </>
  );
}

export default LayoutApp;