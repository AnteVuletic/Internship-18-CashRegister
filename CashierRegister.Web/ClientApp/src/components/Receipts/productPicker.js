import React from 'react';
import '../styles/forms.css';

class ProductPicker extends React.Component{
    constructor(props){
        super(props);
        const { products } = this.props;
        this.state = {
            currentHighlighted: {}
        }
    }
    render(){
        const { products } = this.props;
        return(
            <div>
                {
                    products.map((product,index)=>{
                        return(
                            <div key={index} className="info">
                                <span>Id: {product.product.id}</span>
                                <span>Name: {product.product.name}</span>
                                <span>Price: {product.product.price}</span>
                                <span>Count in storage: {product.product.countInStorage}</span>
                                <span>Excise Tax category: {product.tax.name}</span>
                                <span>Excise Tax percentage: {product.tax.percentage}</span>
                            </div>
                        )
                    })
                }
            </div>
        );
    }
}

export default ProductPicker;