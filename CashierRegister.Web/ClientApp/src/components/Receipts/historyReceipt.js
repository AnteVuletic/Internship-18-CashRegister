import React from 'react';
import { getReceiptsByDate } from '../../redux/modules/receipt';
import { connect } from 'react-redux';
import '../styles/forms.css';

class HistoryReceipt extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            date: {}
        }
    }

    handleDateChange = (event) =>{
        this.setState({
            date: event.target.value
        });
    }

    handleDateSubmit = () => {
        const { date } = this.state;
        const { getReceiptsByDate } = this.props;

        getReceiptsByDate(date);
    }

    render(){
        const { date } = this.state;
        const { receipts, receipt } = this.props;
        if(receipt.loading){
            return <div className="lds-dual-ring"></div>
        }
        return(
            <div>
                <div className="date-picker">
                    <label>Pick date:</label>
                    <input type="date" value={date} onChange={this.handleDateChange} />
                    <button onClick={this.handleDateSubmit}>Search</button>
                </div>
                <div className="receipts-result">
                    {
                        receipts.map((receiptDto, index) => {
                            const { receipt, productReports } = receiptDto;
                            return(
                                <article key={index}>
                                    <span>Receipt ID:{receipt.id}</span>
                                    <span>Time created:{receipt.dateTimeCreated}</span>
                                    <span>Direct tax amount:{receipt.directTaxAtCreation}</span>
                                    <span>Excise tax amount:{receipt.exciseTaxAtCreation}</span>
                                    <span>Pre tax total:{receipt.preTaxPriceAtCreation}</span>
                                    <span>Post tax total:{receipt.postTaxPriceAtCreation}</span>
                                    <span>Cashier identification:{receipt.cashRegisterCashier.cashierId}</span>
                                    <span>Cash register identification:{receipt.cashRegisterCashier.cashRegisterId}</span>
                                    <div className="products-section">
                                    {
                                        productReports.map((productReport,productIndex)=>{
                                            return(
                                                <div key={productIndex}>
                                                    <span>Product Name:{productReport.name}</span>
                                                    <span>Excise percentage:{productReport.excisePercentage}</span>
                                                    <span>Amount of products:{productReport.productCount}</span>
                                                    <span>Product price:{productReport.productPrice}</span>
                                                </div>
                                            )
                                        })
                                    }
                                    </div>
                                </article>
                            )
                        })
                    }
                </div>
            </div>
        );
    }
}

const MapStateToProps = state => ({
    receipts: state.receipt.receipts,
    receipt: state.receipt
});

const MapDispatchToProps = {
    getReceiptsByDate
}

export default connect(
    MapStateToProps,
    MapDispatchToProps
)(HistoryReceipt);