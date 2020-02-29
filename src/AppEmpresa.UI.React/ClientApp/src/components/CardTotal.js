import React from 'react'
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardHeader from '@material-ui/core/CardHeader';
import { makeStyles } from '@material-ui/styles';


const useStyles = makeStyles(() => ({
    total_label: {
        flexGrow: 1,
        textAlign: 'center',
        textSizeAdjust: 'xx-large',
        fontSize: "500%"
    },
    card:{
        margin:'15%',
    }
}));

const CardTotal = (props) => {
    const classes = useStyles();

    return (
        <Card className={classes.card}>
            <CardHeader title={props.title} subheader="Total" >
            </CardHeader>
            <CardContent>
                <div className={classes.total_label}>
                    {props.quantity}
                </div>
            </CardContent>
        </Card>
    )
}

export default CardTotal;
