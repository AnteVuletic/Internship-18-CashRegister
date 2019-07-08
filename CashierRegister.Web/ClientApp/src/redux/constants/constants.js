const ENDPOINT_BASE = "http://localhost:51952/api";

export const ENDPOINTS_BY_CONTROLLER = {
    CASHIER_REGISTER: `${ENDPOINT_BASE}/CashierRegister`,
    CASHIER: `${ENDPOINT_BASE}/Cashier`,
    PRODUCT: `${ENDPOINT_BASE}/Product`,
    RECEIPT: `${ENDPOINT_BASE}/Receipt`,
    LOGIN: `${ENDPOINT_BASE}/Login`,
    SHIFT: `${ENDPOINT_BASE}/Shift`,
    TAX: `${ENDPOINT_BASE}/Tax`
}