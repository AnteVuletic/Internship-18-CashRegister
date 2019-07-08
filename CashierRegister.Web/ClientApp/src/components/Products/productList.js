import React from 'react';
import { getProducts, deleteProduct, editProduct, postProduct, readTaxes } from '../../redux/modules/product';
import { connect } from 'react-redux';
import ProductElement from './productElement';
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
            filteredProducts: this.props.products
        }
    }
    componentWillMount(){
        this.props.getProducts();
        this.props.readTaxes();
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

        this.setState({
            filteredProducts: products.filter(product => product.product.name.includes(event.target.value))
        });       
    }

    render(){
        const { deleteProduct, editProduct, taxTypes} = this.props;
        const { isAddForm, isNewExcise, searchQuery, filteredProducts } = this.state;
        
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
                    taxTypes.map((taxType,index)=>{
                        if(taxType.taxType ==="Excise")
                            return <option key={index} value={taxType.name}>{taxType.name + " | " + taxType.percentage + "%"}</option>
                    })
                }
            </select>
        </div>;
        const addForm = isAddForm ?
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
                                taxTypes.map((taxType,index)=>{
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
                <button
                    className="addButton"
                    onClick={() => 
                        this.setState((prevState) => {return { isAddForm: !prevState.isAddForm}})}>
                        Toggle add form
                </button>
                <input name="searchQuery" className="search" placeholder="Enter your serach here" value={searchQuery} onChange={this.handleSearchChange}></input>
                {
                    filteredProducts.map((product,index) => {
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
                                    taxTypes={taxTypes}
                                    />
                    })
                }
            </main>
        );
    }
}

const MapStateToProps = state => ({
    products: state.product.products,
    taxTypes: state.product.taxTypes
});

const MapDispatchToProps = {
    getProducts,
    editProduct,
    deleteProduct,
    postProduct,
    readTaxes
}

export default connect(
    MapStateToProps,
    MapDispatchToProps
)(ProductList);