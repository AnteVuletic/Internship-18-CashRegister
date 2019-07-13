import React from 'react';
import store from '../../redux';

class ProductElement extends React.Component{
    constructor(props){
        super(props);
        const { 
            id, name, price, countInStorage, exciseTax, excisePercentage, 
            deleteProduct, editProduct, onModified, taxTypes, isReceipt, 
            onSelectedItem, productsOnReceipt
            } = this.props;
        this.state = {
            isEdit: false,
            name,
            price,
            countInStorage,
            exciseTax,
            excisePercentage,
            isNewExcise: false,
            productCount: 1
        }
    }

    updateStateFromStore = () =>{
        const currentReduxState = store.getState();

        const { products } = currentReduxState.product;
        const { id } = this.props;
        const { name, price, countInStorage, exciseTax, excisePercentage } = this.state;

        const productInQuestion = products.find(product => product.product.id == id );
        if(
            productInQuestion.product.name !== name || 
            productInQuestion.product.price !== price || 
            productInQuestion.product.countInStorage !== countInStorage || 
            productInQuestion.product.exciseTax !== exciseTax || 
            productInQuestion.product.excisePercentage !== excisePercentage
        )
            this.setState({
                    ...productInQuestion.product,
                    ...productInQuestion.productTax,
                    isNewExcise: false,
                    productCount: 1
            });
    }
    componentDidMount(){
        this.unsubscribeStore = store.subscribe(this.updateStateFromStore);
    }

    componentWillUnmount(){
        this.unsubscribeStore();
    }

    handleInputChange = (event) =>{
        const value = event.target.value;
        const name = event.target.name;

        if(name==="productCount" && value > this.state.countInStorage)
            this.setState({
                productCount : this.state.countInStorage
            });
        else
            this.setState({
                [name]: value
            });
    }

    handleToggleEdit = () => {
        const { isEdit } = this.state;
        
        this.setState({
            isEdit: !isEdit
        });
    }

    // handleDelete = () => {
    //     const { id, deleteProduct, onModified } = this.props;

    //     deleteProduct(id)
    //         .then(_ => {
    //             onModified();
    //         });
    // }

    handleEditSubmit = (event) => {
        event.preventDefault();
        const { id, editProduct, onModified, taxTypes } = this.props;
        const { name, price, countInStorage, exciseTax, excisePercentage, isNewExcise } = this.state;

        const product = {
            id,
            name,
            price,
            countInStorage
        }

        const productTax = {
            name: exciseTax,
            percentage: taxTypes.find(taxType => taxType.name === exciseTax ).percentage
        }

        if(isNewExcise)
            productTax.percentage = excisePercentage;

        editProduct(product, productTax)
            .then(response => {
                this.setState({
                    isEdit: false
                })
                onModified();
            });
    }

    handleSelectedProduct = () =>{
        const { productCount } = this.state;
        const { id } = this.props;

        this.props.onSelectedItem(id, productCount);
    }

    render(){
        const { id, taxTypes, isReceipt, productsOnReceipt } = this.props;
        const { isEdit, name, price, countInStorage, isNewExcise, exciseTax, excisePercentage, productCount } = this.state;

        const view = 
        <div className="info">
            <span>Id: {id}</span>
            <span>Name: {name}</span>
            <span>Price: {price}</span>
            <span>Count in storage: {countInStorage}</span>
            <span>Excise Tax category: {exciseTax}</span>
            <span>Excise Tax percentage: {excisePercentage}</span>
        </div>;

        const excise = isNewExcise ? 
        <div className="exciseSection">
            <label>Excise tax name:</label>
            <input name="exciseTax" type="text" placeholder="Enter excise tax name" value={exciseTax} onChange={this.handleInputChange} />
            <label>Excise category percentage:</label>
            <input name="excisePercentage" type="number" placeholder="Excise Percentage" value={excisePercentage} onChange={this.handleInputChange} />
        </div> :
        <div className="exciseSection">
            <label>Excise tax: </label>
            <select name="exciseTax" value={exciseTax} onChange={this.handleInputChange}>
                {
                    taxTypes.map((taxType,index)=>{
                        if(taxType.taxType === "Excise")
                            return <option key={index} value={taxType.name}>{taxType.name + " | " + taxType.percentage + "%"}</option>
                    })
                }
            </select>
        </div>;

        const edit = 
        <div className="addForm">
            <button 
                className="exciseToggle"
                onClick={() => this.setState((prevState) => {return { isNewExcise: !prevState.isNewExcise }})}>
                    Toggle excise section
            </button>
            <form onSubmit={this.handleEditSubmit}>
                <div className="formWrapper">
                    <label>Product name:</label>
                    <input name="name" value={name} type="text" placeholder="Enter product name here" minLength="3" onChange={this.handleInputChange} />
                    <label>Product Price:</label>
                    <input name="price" value={price} type="number" placeholder="Price" onChange={this.handleInputChange} />
                    <label>Count in storage:</label>
                    <input name="countInStorage" value={countInStorage} type="number" onChange={this.handleInputChange} />
                    <label>Direct tax:</label>
                    <select name="directTax">
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
        </div>;
        if((countInStorage <= 0 && isReceipt ) || productsOnReceipt.find(product => product.product.id === id ))
            return <div></div>
        return (
            <article className="element">
                {
                    isEdit ?
                    edit :
                    view
                }
                <div className="controls">
                    {
                        isReceipt ? 
                        <div>
                            <label>Count:</label>
                            <input name="productCount" type="number" max={countInStorage} value={productCount} onChange={this.handleInputChange} />
                            <button onClick={this.handleSelectedProduct}>Select</button>
                        </div>:
                        <button onClick={this.handleToggleEdit}>Toggle edit</button>
                    }
                    {/* <button onClick={this.handleDelete}>Delete</button> */}
                </div>
            </article>
        );
    }
};

export default ProductElement;