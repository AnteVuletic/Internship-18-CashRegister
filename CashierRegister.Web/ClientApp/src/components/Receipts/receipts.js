import React from 'react';
import { Switch } from 'react-router-dom';
import PrivateRoute from '../PrivateRoute/privateRoute';
import ReceiptNavigation from './receiptNavigation';
import CreateReceipt from './createReceipt';
import HistoryReceipt from './historyReceipt';

const CashRegister = (props) => {
    return(
        <div>
            <ReceiptNavigation></ReceiptNavigation>
            <Switch>
                <PrivateRoute path="/receipts/createReceipt" component={CreateReceipt} {...props} />
                <PrivateRoute path="/receipts" component={HistoryReceipt} {...props} />
            </Switch>
        </div>
    )
}

export default CashRegister;