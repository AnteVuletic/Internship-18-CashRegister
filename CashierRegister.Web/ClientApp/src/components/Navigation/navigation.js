import React from 'react';
import { Link } from 'react-router-dom';
import "../styles/navigation.css";

export default _ =>
<nav>
    <Link to="/">Home</Link>
    <Link to="/products">Products</Link>
    <Link to="/receipts/createReceipt">Receipts</Link>
    <Link to="/login" onClick={() => window.localStorage.removeItem('token')}>Log out</Link>
</nav>