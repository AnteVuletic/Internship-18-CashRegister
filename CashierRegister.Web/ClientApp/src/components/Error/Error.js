import React from "react";
import { connect } from "react-redux";
import { hideError } from "../../redux/modules/error";

const Error = ({ isVisible, message, onClose }) => {
  if (!isVisible) {
    return null;
  }
  return (
    <div className="error">
      <div>{message}</div>
      <div onClick={onClose}>x</div>
    </div>
  );
};

const mapStateToProps = state => ({
  isVisible: state.error.isVisible,
  message: state.error.message
});

const mapDispatchToProps = {
  onClose: hideError
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Error);