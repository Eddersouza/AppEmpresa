import React from 'react';
import { toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

let messageItens = [];

const Msg = ({ closeToast }) => (
    <ul>
        {messageItens.map((item) => {
            return <li>{item}</li>
        })}
    </ul>
)

export function LaunchErrorResponse(response){
    if (response.status === 400)
    ToastWarning(response.data.warningMessages);
else
    ToastError(response.data.errorMessages);
}

export function ToastError(messages) {
    messageItens = messages;
    toast.error(<Msg />, {
        position: toast.POSITION.TOP_LEFT,
        autoClose: 1000 + (messages.length * 1000)
    });
}

export function ToastWarning(messages) {
    messageItens = messages;
    toast.warn(<Msg />, {
        position: toast.POSITION.TOP_LEFT,
        autoClose: 1000 + (messages.length * 1000)
    });
}