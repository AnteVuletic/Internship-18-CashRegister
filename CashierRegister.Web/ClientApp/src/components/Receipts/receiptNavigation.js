import React from 'react';
import { Link } from 'react-router-dom';
import "../styles/navigation.css";

export default _ =>
<nav className="subNavigation">
    <Link to="/receipts/createReceipt">Create receipt</Link>
    <Link to="/receipts">History</Link>
</nav>