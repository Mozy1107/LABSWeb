import React from 'react';

function App() {
  const animals = ['Кошки', 'Львы', 'Баобаб'];
  const hobbies = ['Кодинг', 'Компьютерные игры', 'МЮЗИНГ'];
  
  const animalsInHTML = animals.map((animal, index) => {
    return <li key={index} style={{ padding: '5px 0' }}>{animal}</li>;
  });
  
  const hobbiesInHTML = hobbies.map((hobby, index) => {
    return <li key={index} style={{ padding: '5px 0' }}>{hobby}</li>;
  });
  
  return (
    <div style={{ padding: '20px' }}>
      <h2>Задание 05: Map для массивов</h2>
      
      <div style={{ marginBottom: '30px' }}>
        <h3>Мои любимый скот:</h3>
        <ul style={{ backgroundColor: '#1847', padding: '15px', borderRadius: '8px' }}>
          {animalsInHTML}
        </ul>
      </div>
      
      <div>
        <h3>Мои хобби:</h3>
        <ul style={{ backgroundColor: '#7428', padding: '15px', borderRadius: '8px' }}>
          {hobbiesInHTML}
        </ul>
      </div>
    </div>
  );
}

export default App;
