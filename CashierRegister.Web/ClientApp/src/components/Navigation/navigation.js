import React from 'react';
import { Link } from 'react-router-dom';
import "./navigation.css";

export default _ =>
<nav>
    <Link to="/">Home</Link>
    <Link to="/products">Products</Link>
    <Link to="/receipts">Receipts</Link>
</nav>