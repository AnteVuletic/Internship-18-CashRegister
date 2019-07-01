import React from 'react';
import { getCashRegisters, deleteCashRegister, editCashRegister } from '../../redux/modules/cashRegister';
import { connect } from 'react-redux';
import CashRegisterElement from './cashRegisterElement'

class CashRegisterList extends React.Component{
    componentWillMount(){
        this.props.getCashRegisters();
    }

    handleModified = () =>{
        this.props.getCashRegisters();
    }

    render(){
        const { cashRegisters, deleteCashRegister, editCashRegister } = this.props;
        return(
            <main>
                {
                    cashRegisters.map(cashReg => {
                        return <CashRegisterElement 
                                    id={cashReg.id} 
                                    location={cashReg.location}
                                    deleteCashRegister={deleteCashRegister}
                                    editCashRegister={editCashRegister}
                                    onModified={this.handleModified}/>
                    })
                }
            </main>
        );
    }
}

const MapStateToProps = state => ({
    cashRegisters: state.cashRegister.cashRegisters
});

const MapDispatchToProps = {
    getCashRegisters,
    deleteCashRegister,
    editCashRegister
}

export default connect(
    MapStateToProps,
    MapDispatchToProps
)(CashRegisterList);