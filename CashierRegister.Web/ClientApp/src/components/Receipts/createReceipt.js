import React from 'react';
import ReactDOM from 'react-dom';
import { removeProduct, clearReceipt, createReceipt } from '../../redux/modules/receipt';
import { getProducts } from '../../redux/modules/product';
import { connect } from 'react-redux';
import ProductList from '../Products/productList';
import { Printd } from 'printd';
import '../styles/forms.css';

class CreateReceipt extends React.Component{
    constructor(props){
        super(props);
        const { productsOnReceipt, removeProduct, clearReceipt, identity, createReceipt  } = this.props;
    }

    handleProductRemove = (id) => {
        this.props.removeProduct(id );
    }

    handleClear = () => {
        this.props.clearReceipt();
    }

    handlePrint = (receiptDto) => {
        const { receipt, productReports } = receiptDto;
        return(
            <article>
                <span>Receipt ID:{receipt.id}</span>
                <span>Time created:{receipt.dateTimeCreated}</span>
                <span>Direct tax amount:{receipt.directTaxAtCreation}</span>
                <span>Excise tax amount:{receipt.exciseTaxAtCreation}</span>
                <span>Pre tax total:{receipt.preTaxPriceAtCreation}</span>
                <span>Post tax total:{receipt.postTaxPriceAtCreation}</span>
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
        );
    }

    handleCreateReceipt = () => {
        const { productsOnReceipt, identity, createReceipt } = this.props;
        createReceipt(identity, productsOnReceipt)
        .then((response) =>{
            const printStyle = `
                span{
                    display: block;
                }
            `;
            const receiptPrint = new Printd;
            const elementToPrint = this.handlePrint(response);
            let receiptDomElement = document.createElement("div");
            ReactDOM.render(elementToPrint, receiptDomElement)
            receiptPrint.print(receiptDomElement,[printStyle]);
        })
        .then(() => {
            this.props.clearReceipt();
            this.props.getProducts();
        }); 
    }

    render(){
        const { productsOnReceipt,identity } = this.props;
        if(identity.cashRegisterId == -1){
            return(
                <div>
                    Make sure you connect to cash register first.
                    <button onClick={()=>{
                        window.location = "/";
                    }}>Go to cash register</button>
                </div>
            )
        }
        return(
        <div className="create-receipt-wrapper">
            <div className="search-on-receipt">
                <ProductList isReceipt={true} {...this.props}></ProductList>
            </div>
            <div className="receipt-section">
                <h1 className="receipt-title">New receipt</h1>
                {
                    productsOnReceipt.map((productOnReceipt,index)=>{
                        return(
                            <article key={index}>
                                <span>Id: {productOnReceipt.product.id}</span>
                                <span>Name: {productOnReceipt.product.name}</span>
                                <span>Price per unit: {productOnReceipt.product.price}</span>
                                <span>Excise tax: {productOnReceipt.productTax.percentage}</span>
                                <span>Product count: {productOnReceipt.productCount}</span>
                                <span>Product total: {productOnReceipt.product.price * productOnReceipt.productCount}</span>
                                <span>Direct tax: 25%</span>
                                <button onClick={() => this.handleProductRemove(productOnReceipt.product.id)}>Remove</button>
                            </article>
                        )
                    })
                }
                <footer className="receipt-actions">
                    <button onClick={this.handleCreateReceipt} disabled={productsOnReceipt <= 0}>Create receipt</button>
                    <button onClick={this.handleClear}>Clear</button>
                </footer>
            </div>
        </div>
        );
    }
}

const MapStateToProps = state => ({
    productsOnReceipt: state.receipt.productsOnNewReceipt,
    identity: state.identity
});

const MapDispatchToProps = {
    removeProduct,
    clearReceipt,
    createReceipt,
    getProducts
}

export default connect(
    MapStateToProps,
    MapDispatchToProps
)(CreateReceipt);