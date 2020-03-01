import React from 'react';
import { makeStyles } from '@material-ui/styles';

import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import HomeIcon from '@material-ui/icons/Home';
import Link from '@material-ui/core/Link';
import Typography from '@material-ui/core/Typography';
import { Link as RouterLink } from 'react-router-dom';

const useStyles = makeStyles(() => ({
    ink: {
        display: 'flex',
    },
    icon: {
        marginRight: 5,
        width: 20,
        height: 20,
    },
}));

const LinkRouter = props => <Link {...props} component={RouterLink} />;

const Beadcrumb = (props) => {
    const classes = useStyles();

    return (
        <Breadcrumbs aria-label="breadcrumb">
            {props.data.map((value, index) => {
                const last = index === props.data.length - 1;
                const fisrt = index === 0;
                return last && !fisrt ? (
                    <Typography color="textPrimary" key={value}>
                        {value.title}
                    </Typography>
                ) : (
                        <LinkRouter color="inherit" to={value.link} key={value.title} className={classes.link}>
                            {fisrt ? <HomeIcon className={classes.icon} /> : 'null'}
                            {value.title}
                        </LinkRouter>
                    );

            })}
        </Breadcrumbs>
    );
};

export default Beadcrumb;