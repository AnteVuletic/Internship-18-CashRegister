import React from 'react';

class ProductElement extends React.Component{
    constructor({ id, name, price, countInStorage, deleteProduct, editProduct, onModified}){
        super({ id, name, price, countInStorage, deleteProduct, editProduct, onModified});
        this.state = {
            isEdit: false,
            name,
            price,
            countInStorage
        }
    }

    handleInputChange = (event) =>{
        const value = event.target.value;
        const name = event.target.name;

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

    handleDelete = () => {
        const { id, deleteProduct, onModified } = this.props;

        deleteProduct(id)
            .then(_ => {
                onModified();
            });
    }

    handleEditSubmit = (event) => {
        event.preventDefault();
        const { id, editProduct, onModified } = this.props;
        const { name, price, countInStorage } = this.state;

        editProduct(id,name,price,countInStorage)
            .then(response => {
                this.setState({
                    isEdit: false
                })
                onModified();
            });
    }

    render(){
        const { id } = this.props;
        const { isEdit, name, price, countInStorage } = this.state;
        const view = 
        <div>
            <span>{id}</span>
            <span>{name}</span>
            <span>{price}</span>
            <span>{countInStorage}</span>
        </div>;
        const edit = 
        <form className="addForm" onSubmit={this.handleEditSubmit}>
            <input name="name" type="text" value={name} placeholder="Enter product name here" minLength="3" onChange={this.handleInputChange} />
            <label>Product Price:</label>
            <input name="price" type="number" value={price} placeholder="Price" onChange={this.handleInputChange} />
            <label>Count in storage:</label>
            <input name="countInStorage" type="number" value={countInStorage} onChange={this.handleInputChange} />
            <input type="submit" value="Submit"/> 
        </form>
        return (
            <article>
                {
                    isEdit ?
                    edit :
                    view
                }
                <button onClick={this.handleToggleEdit}>Toggle edit</button>
                <button onClick={this.handleDelete}>Delete</button>
            </article>
        );
    }
};

export default ProductElement;