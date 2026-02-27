import React from 'react';
import PropTypes from 'prop-types';

const Alert = (props) => {
  if (props.show === false) {
    return null;
  }

  const colorClasses = {
    'red': 'alert-danger',
    'yellow': 'alert-warning',
    'green': 'alert-success',
    'blue': 'alert-info'
  };

  const alertClass = colorClasses[props.color] || 'alert-primary';

  return (
    <div className={`alert ${alertClass}`} role="alert">
      {props.text}
    </div>
  );
};

Alert.propTypes = {
  show: PropTypes.bool,
  text: PropTypes.string,
  color: PropTypes.string
};

function App() {
  return (
    <div style={{ padding: '20px' }}>
      <h2>Задание 09: Условный рендеринг</h2>
      
      <Alert 
        text=" Я любить музыку и всё" 
        color="blue" 
        show={true} 
      />
      
      <Alert 
        text="ТЕХНИКА - МОЯ ЖИЗНЬ" 
        color="green" 
        show={true} 
      />
      
      <Alert 
        text="Но и ещё танцы" 
        color="yellow" 
        show={true} 
      />
      
      <Alert 
        text="Это сообщение скрыто" 
        color="red" 
        show={false} 
      />
      
      <p style={{ marginTop: '20px', color: '#666' }}>
        Последнее сообщение скрыто (show=false)
      </p>
    </div>
  );
}

export default App;
