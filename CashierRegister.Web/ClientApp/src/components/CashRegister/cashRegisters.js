import React from 'react';
import { getCashRegisters } from '../../redux/modules/cashRegister';
import { connect } from 'react-redux';
import CashRegister from './cashRegister'

class CashRegisters extends React.Component{
    componentWillMount(){
        getCashRegisters();
    }

    render(){
        const { cashRegisters } = this.props;
        return(
            <main>
                {
                    cashRegisters.map(cashReg => {
                        return <CashRegister id={cashReg.id} location={cashReg.location}/>
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
    getCashRegisters
}

export default connect(
    MapStateToProps,
    MapDispatchToProps
)(CashRegisters);