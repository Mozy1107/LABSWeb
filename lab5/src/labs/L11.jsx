import React, { useState } from 'react';

const Alert = () => {
  const handleClick = () => {
    console.log("Я Белов Даниил");
    alert("Я Даниил, мне 19 лет.");
  };

  return (
    <div 
      className="alert alert-info" 
      role="alert"
      onClick={handleClick}
      style={{ cursor: 'pointer' }}
    >
       Нажми на меня, чтобы узнать обо мне!
    </div>
  );
};

const BookCounter = () => {
  const [count, setCount] = useState(3);

  const handleIncrement = () => {
    setCount(count + 1);
  };

  const handleDecrement = () => {
    if (count > 0) {
      setCount(count - 1);
    }
  };

  const handleReset = () => {
    setCount(3);
  };

  return (
    <div style={{ margin: '20px 0', padding: '20px', backgroundColor: '#f8f9fa', borderRadius: '8px' }}>
      <h3> Счетчик просмотренных сериалов</h3>
      <h2 style={{ color: '#667eea', fontSize: '48px' }}>СЕРИЯ: {count}</h2>
      <button className="btn btn-success m-2" onClick={handleIncrement}>
        +1 серия
      </button>
      <button className="btn btn-danger m-2" onClick={handleDecrement}>
        -1 серия
      </button>
      <button className="btn btn-secondary m-2" onClick={handleReset}>
        Сброс
      </button>
    </div>
  );
};

const CodingCounter = () => {
  const [hours, setHours] = useState(0);

  return (
    <div style={{ margin: '20px 0', padding: '20px', backgroundColor: '#e3f2fd', borderRadius: '8px' }}>
      <h3>💻 Счетчик часов сидения за пк</h3>
      <h2 style={{ color: '#28a745', fontSize: '48px' }}>Часов: {hours}</h2>
      <button className="btn btn-primary m-2" onClick={() => setHours(hours + 1)}>
        +1 час
      </button>
      <button className="btn btn-warning m-2" onClick={() => setHours(hours + 5)}>
        +5 часов
      </button>
      <button className="btn btn-secondary m-2" onClick={() => setHours(0)}>
        Новый день
      </button>
    </div>
  );
};

function App() {
  return (
    <div style={{ padding: '20px' }}>
      <h2>Задание 11: События</h2>
      
      <Alert />
      <BookCounter />
      <CodingCounter />
    </div>
  );
}

export default App;
