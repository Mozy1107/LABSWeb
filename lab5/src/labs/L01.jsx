import React from 'react';

function App() {
  let name = "Даниил";
  let age = 19;
  let city = "Йошкар-Ола";
  
  return (
    <div style={{ padding: '20px', fontFamily: 'Arial, sans-serif' }}>
      <h2>Задание 01: Базовый рендеринг</h2>
      <p>
        <span>{name} is <strong>{age}</strong> years old</span>
      </p>
      <p>
        Живу в городе: <strong>{city}</strong>
      </p>
    </div>
  );
}

export default App;
