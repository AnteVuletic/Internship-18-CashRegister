const SHOW_ERROR = "SHOW_ERROR";
const HIDE_ERROR = "HIDE_ERROR";

const initialState = {
  isVisible: false,
  message: ""
};

export const showError = message => {
  return {
    type: SHOW_ERROR,
    message
  };
};

export const hideError = () => {
  return {
    type: HIDE_ERROR
  };
};

const reducer = (state = initialState, action) => {
  switch (action.type) {
    case SHOW_ERROR:
      return {
        ...state,
        isVisible: true,
        message: action.message
      };
    case HIDE_ERROR:
      return {
        ...state,
        isVisible: false,
        message: ""
      };
    default:
      return state;
  }
};

export default reducer;
