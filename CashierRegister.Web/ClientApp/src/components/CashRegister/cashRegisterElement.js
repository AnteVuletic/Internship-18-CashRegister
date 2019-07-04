import React from 'react';

class CashRegisterElement extends React.Component{
    constructor({ id, location, deleteCashRegister, editCashRegister, onModified, connectCashRegister, disconnectCashRegister, identity }){
        super({ id, location, deleteCashRegister, editCashRegister, onModified, connectCashRegister, disconnectCashRegister, identity });
        this.state = {
            isEdit: false,
            location
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
        const { id, deleteCashRegister, onModified } = this.props;

        deleteCashRegister(id)
            .then(_ => {
                onModified();
            });
    }

    handleEditSubmit = (event) => {
        event.preventDefault();
        const { id, editCashRegister, onModified } = this.props;
        const { location } = this.state;

        editCashRegister(id,location)
            .then(response => {
                this.setState({
                    isEdit: false
                })
                onModified();
            });
    }

    render(){
        const { id, connectCashRegister, disconnectCashRegister, identity } = this.props;
        const { isEdit, location } = this.state;
        const connectOrDisconnect = identity.cashRegisterId === -1 ?
        <button onClick={() => connectCashRegister(id)}>
            Connect
        </button> :
        <button onClick={() => disconnectCashRegister(id)}>
            Disconnect
        </button>
        const view = 
        <div>
            <span>{id}</span>
            <span>{location}</span>
        </div>;
        const edit = 
        <form onSubmit={this.handleEditSubmit}>
            <input name="location" type="text" placeholder="Enter location here" value={location} minLength="3" onChange={this.handleInputChange} />
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
                {connectOrDisconnect}
            </article>
        );
    }
};

export default CashRegisterElement;