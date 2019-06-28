import React from 'react';
import { Link } from 'react-router-dom';

export default _ =>
<nav>
    <Link to="/">Home</Link>
    <Link to="/cashRegisters">Cash registers</Link>
    <Link to="/products">Products</Link>
    <Link to="/receipts">Receipts</Link>
</nav>