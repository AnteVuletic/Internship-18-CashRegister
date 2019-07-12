import React from 'react';
import { removeProduct, clearReceipt, createReceipt } from '../../redux/modules/receipt';
import { getProducts } from '../../redux/modules/product';
import { connect } from 'react-redux';
import ProductList from '../Products/productList';
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

    handleCreateReceipt = () => {
        const { productsOnReceipt, identity, createReceipt } = this.props;
        createReceipt(identity, productsOnReceipt).then(() => {
            this.props.clearReceipt();
            this.props.getProducts();
        }); 
    }

    render(){
        const { productsOnReceipt,identity } = this.props;
        if(identity.cashRegisterId == -1){
            window.location = "/";
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