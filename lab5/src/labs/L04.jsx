import React from 'react';

function App() {
  const navlinkItems = [
    <li key="1" className="nav-item">
      <a className="nav-link" href="https://github.com">GitHub - для кодинга</a>
    </li>,
    <li key="2" className="nav-item">
      <a className="nav-link" href="https://stackoverflow.com">Stack Overflow - помощь в программировании</a>
    </li>,
    <li key="3" className="nav-item">
      <a className="nav-link" href="https://react.dev">React Documentation</a>
    </li>,
    <li key="4" className="nav-item">
      <a className="nav-link" href="https://store.steampowered.com">Steam - компьютерные игры</a>
    </li>,
    <li key="5" className="nav-item">
      <a className="nav-link" href="https://www.litres.ru">ЛитРес - книги</a>
    </li>
  ];
  
  return (
    <div style={{ padding: '20px' }}>
      <h2>Задание 04: Массивы</h2>
      <h3>Мои любимые ресурсы:</h3>
      <ul className="nav flex-column" style={{ backgroundColor: '#f8f9fa', padding: '15px', borderRadius: '8px' }}>
        {navlinkItems}
      </ul>
    </div>
  );
}

export default App;
