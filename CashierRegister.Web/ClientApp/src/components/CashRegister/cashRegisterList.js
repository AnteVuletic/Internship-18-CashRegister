import React from 'react';
import { getCashRegisters, deleteCashRegister, editCashRegister, createCashRegister } from '../../redux/modules/cashRegister';
import { connectCashRegister,disconnectCashRegister, hasToken, checkStartedShift } from '../../redux/modules/identity'
import { connect } from 'react-redux';
import CashRegisterElement from './cashRegisterElement'
import '../styles/forms.css';

class CashRegisterList extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            location: '',
            isAddForm: false
        }
    }
    componentDidMount(){
        this.props.getCashRegisters();
        if(this.props.identity.cashierId === -1)
            this.props.hasToken(window.localStorage.getItem('token'))
                .then(() => {
                    this.props.checkStartedShift(this.props.identity.cashierId);
                });
    }

    handleModified = () =>{
        this.props.getCashRegisters();
    }

    handleInputChange = (event) => {
        event.preventDefault();
        this.setState({
            [event.target.name] : event.target.value
        });
    }

    handleAddCashierRegister = (event) => {
        event.preventDefault();
        this.props.createCashRegister(this.state.location)
            .then(response => {
                this.props.getCashRegisters();
            });
    }

    render(){
        const { cashRegisters, deleteCashRegister, editCashRegister, connectCashRegister, disconnectCashRegister, identity } = this.props;
        const { isAddForm } = this.state;
        const addForm = isAddForm ?
            <form className="addForm" onSubmit={this.handleAddCashierRegister}>
                <div className="formWrapper">
                    <input name="location" type="text" placeholder="Enter location here" minLength="3" onChange={this.handleInputChange} />
                </div>
                <input className="submit" type="submit" value="Submit"/> 
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
                    cashRegisters.map((cashReg,index) => {
                        return <CashRegisterElement
                                    key={index} 
                                    id={cashReg.id} 
                                    location={cashReg.location}
                                    deleteCashRegister={deleteCashRegister}
                                    editCashRegister={editCashRegister}
                                    onModified={this.handleModified}
                                    connectCashRegister={connectCashRegister}
                                    disconnectCashRegister={disconnectCashRegister}
                                    identity={identity}
                                    />
                    })
                }
            </main>
        );
    }
}

const MapStateToProps = state => ({
    cashRegisters: state.cashRegister.cashRegisters,
    identity: state.identity
});

const MapDispatchToProps = {
    getCashRegisters,
    deleteCashRegister,
    editCashRegister,
    createCashRegister,
    connectCashRegister,
    disconnectCashRegister,
    hasToken,
    checkStartedShift
}

export default connect(
    MapStateToProps,
    MapDispatchToProps
)(CashRegisterList);