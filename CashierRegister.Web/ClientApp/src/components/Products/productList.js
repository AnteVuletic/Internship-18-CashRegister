import React from 'react';
import { getProducts, deleteProduct, editProduct, postProduct } from '../../redux/modules/product';
import { getAndPushProduct } from '../../redux/modules/receipt';
import { connect } from 'react-redux';
import ProductElement from './productElement';
import store from '../../redux';
import { getFilteredProducts } from '../../redux/services/productService';
import '../styles/forms.css';

class ProductList extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            productName: '',
            productPrice: 0,
            countInStorage: 0,
            exciseTax: '',
            directTax: '',
            excisePercentage: 0,
            isAddForm: false,
            isNewExcise: this.props.taxTypes.filter(taxType => taxType.taxType === "Excise").length === 0,
            searchQuery: '',
            productsInState: [],
            taxTypesInState: [],
            filteredProducts: [],
            isReceipt: this.props.isReceipt ? true : false
        }
    }
    updateStateFromStore = () =>{
        const currentReduxState = store.getState();

        const { products, taxTypes } = currentReduxState.product;
        const { productsInState, taxTypesInState } = this.state;

        if(productsInState !== products || taxTypesInState !== taxTypes)
            this.setState((prevState) => {
                return {
                    ...prevState,
                    productsInState: products,
                    taxTypesInState: taxTypes
                };
            });
    }
    componentDidMount(){
        this.props.getProducts();
        this.unsubscribeStore = store.subscribe(this.updateStateFromStore);
    }

    componentWillUnmount(){
        this.unsubscribeStore();
    }

    handleModified = () =>{
        this.props.getProducts();
    }

    handleInputChange = (event) => {
        event.preventDefault();
        this.setState({
            [event.target.name] : event.target.value
        });
    }

    handleAddProduct = (event) => {
        event.preventDefault();
        const { productName, productPrice, countInStorage, exciseTax, excisePercentage, isNewExcise} = this.state;
        
        const product = {
            name: productName,
            price: productPrice,
            countInStorage
        }

        const tax = {
            name: exciseTax
        }
        if(isNewExcise)
            tax.percentage = excisePercentage;

        this.props.postProduct(product,tax)
            .then(response => {
                this.props.getProducts();
            });
    }

    handleSearchChange = (event) => {
        this.handleInputChange(event);
        const { products } = this.props;
        const searchFilter = event.target.value;

        if(searchFilter.length >= 3){
            getFilteredProducts(searchFilter).then(filteredProducts => {
                if(filteredProducts.length !== 0)
                    this.setState({
                        filteredProducts
                    });
                else
                    this.setState({
                        filteredProducts: []
                    });
            });
        }
        else
            this.setState({
                filteredProducts: []
            });
    }

    handleItemSelected = (id, productCount) => {
        this.props.getAndPushProduct(id, productCount);
    }

    handleProductFilter = () => {
        const { deleteProduct, editProduct, productsOnReceipt } = this.props;
        const { productsInState, filteredProducts, taxTypesInState, searchQuery, isReceipt} = this.state;
        if(searchQuery.length < 3 )
            return productsInState.map((product,index) => {
                        return <ProductElement
                                    key={index} 
                                    id={product.product.id} 
                                    name={product.product.name}
                                    price={product.product.price}
                                    countInStorage={product.product.countInStorage}
                                    exciseTax={product.productTax.name}
                                    excisePercentage={product.productTax.percentage}
                                    deleteProduct={deleteProduct}
                                    editProduct={editProduct}
                                    onModified={this.handleModified}
                                    taxTypes={taxTypesInState}
                                    isReceipt={isReceipt}
                                    onSelectedItem={this.handleItemSelected}
                                    productsOnReceipt={productsOnReceipt}
                                    />
            });
        
        return filteredProducts.map((product,index) => {
            return <ProductElement
                        key={index} 
                        id={product.product.id} 
                        name={product.product.name}
                        price={product.product.price}
                        countInStorage={product.product.countInStorage}
                        exciseTax={product.productTax.name}
                        excisePercentage={product.productTax.percentage}
                        deleteProduct={deleteProduct}
                        editProduct={editProduct}
                        onModified={this.handleModified}
                        taxTypes={taxTypesInState}
                        isReceipt={isReceipt}
                        onSelectedItem={this.handleItemSelected}
                        productsOnReceipt={productsOnReceipt}
                        />
        });
    }

    render(){
        const { isAddForm, isNewExcise, searchQuery, taxTypesInState, isReceipt} = this.state;
        const { products, taxTypes, product } = this.props;
        if(product.loading){
            return <div className="lds-dual-ring"></div>
        }
        
        const displayProducts = this.handleProductFilter();

        const excise = isNewExcise ? 
        <div className="exciseSection">
            <label>Excise tax name:</label>
            <input name="exciseTax" type="text" placeholder="Enter excise tax name" onChange={this.handleInputChange} />
            <label>Excise category percentage:</label>
            <input name="excisePercentage" type="number" placeholder="Excise Percentage" onChange={this.handleInputChange} />
        </div> :
        <div className="exciseSection">
            <label>Excise tax: </label>
            <select name="exciseTax" onChange={this.handleInputChange}>
                {
                    taxTypesInState.map((taxType,index)=>{
                        if(taxType.taxType ==="Excise")
                            return <option key={index} value={taxType.name}>{taxType.name + " | " + taxType.percentage + "%"}</option>
                    })
                }
            </select>
        </div>;
        const addForm = isAddForm && !isReceipt ?
            <div className="addForm">
                <button 
                    className="exciseToggle"
                    onClick={() => this.setState((prevState) => {return { isNewExcise: !prevState.isNewExcise }})}>
                        Toggle excise section
                </button>
                <form onSubmit={this.handleAddProduct}>
                    <div className="formWrapper">
                        <label>Product name:</label>
                        <input name="productName" type="text" placeholder="Enter product name here" minLength="3" onChange={this.handleInputChange} />
                        <label>Product Price:</label>
                        <input name="productPrice" type="number" placeholder="Price" onChange={this.handleInputChange} />
                        <label>Count in storage:</label>
                        <input name="countInStorage" type="number" onChange={this.handleInputChange} />
                        <label>Direct tax:</label>
                        <select name="directTax" onChange={this.handleInputChange}>
                            {
                                taxTypesInState.map((taxType,index)=>{
                                    if(taxType.taxType === "Direct")
                                        return <option key={index} value={taxType.name}>{taxType.name + " | " + taxType.percentage + "%"}</option>
                                })
                            }
                        </select>
                        {excise}
                    </div>
                    <input className="submit" type="submit" value="Submit"/> 
                </form>
            </div> :
            '';
        return(
            <main>
                {addForm}
                {
                    !isReceipt ? <button
                        className="addButton"
                        onClick={() => 
                            this.setState((prevState) => {return { isAddForm: !prevState.isAddForm}})}>
                            Toggle add form
                    </button> : ''
                }
                <input name="searchQuery" className="search" placeholder="Enter your serach here" value={searchQuery} onChange={this.handleSearchChange}></input>
                {
                    displayProducts
                }
            </main>
        );
    }
}

const MapStateToProps = state => ({
    products: state.product.products,
    taxTypes: state.product.taxTypes,
    productsOnReceipt: state.receipt.productsOnNewReceipt,
    product: state.product
});

const MapDispatchToProps = {
    getProducts,
    editProduct,
    deleteProduct,
    postProduct,
    getAndPushProduct
}

export default connect(
    MapStateToProps,
    MapDispatchToProps
)(ProductList);