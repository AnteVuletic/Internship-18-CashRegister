const ENDPOINT_BASE = "https://localhost:44343/api/";

export const ENDPOINTS_BY_CONTROLLER = {
    CASHIER_REGISTER: `${ENDPOINT_BASE}/CashierRegister`,
    CASHIER: `${ENDPOINT_BASE}/Cashier`,
    PRODUCT: `${ENDPOINT_BASE}/Product`,
    RECEIPT: `${ENDPOINT_BASE}/Receipt`,
    LOGIN: `${ENDPOINT_BASE}/Login`
}