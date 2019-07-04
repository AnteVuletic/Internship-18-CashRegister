import React from 'react';
import { getProducts, deleteProduct, editProduct, postProduct } from '../../redux/modules/product';
import { connect } from 'react-redux';
import ProductElement from './productElement';
import './products.css';

class ProductList extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            productName: '',
            productPrice: 0,
            countInStorage: 0,
            isAddForm: false
        }
    }
    componentWillMount(){
        this.props.getProducts();
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
        const { productName, productPrice, countInStorage } = this.state;

        this.props.postProduct(productName, productPrice, countInStorage)
            .then(response => {
                this.props.getProducts();
            });
    }

    render(){
        const { deleteProduct, editProduct, products } = this.props;
        const { isAddForm } = this.state;
        const addForm = isAddForm ?
            <form className="addForm" onSubmit={this.handleAddProduct}>
                <input name="productName" type="text" placeholder="Enter product name here" minLength="3" onChange={this.handleInputChange} />
                <label>Product Price:</label>
                <input name="productPrice" type="number" placeholder="Price" onChange={this.handleInputChange} />
                <label>Count in storage:</label>
                <input name="countInStorage" type="number" onChange={this.handleInputChange} />
                <input type="submit" value="Submit"/> 
            </form> :
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
                {
                    products.map((product,index) => {
                        return <ProductElement
                                    key={index} 
                                    id={product.id} 
                                    name={product.name}
                                    price={product.price}
                                    countInStorage={product.countInStorage}
                                    deleteProduct={deleteProduct}
                                    editProduct={editProduct}
                                    onModified={this.handleModified}
                                    />
                    })
                }
            </main>
        );
    }
}

const MapStateToProps = state => ({
    products: state.product.products
});

const MapDispatchToProps = {
    getProducts,
    editProduct,
    deleteProduct,
    postProduct
}

export default connect(
    MapStateToProps,
    MapDispatchToProps
)(ProductList);