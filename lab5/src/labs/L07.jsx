import React from 'react';

const PrintHello = () => {
  return <h1>I Love React and Coding!</h1>;
};

const AboutMe = () => {
  return (
    <div style={{ backgroundColor: '#f0f0f0', padding: '20px', borderRadius: '8px', marginTop: '20px' }}>
      <h2>Обо мне</h2>
      <p>Меня зовут Белов  Даниил, мне 19 лет.</p>
      <p>Я из города Йошкар-Ола.</p>
      <p>Я люблю музыку и танцы.</p>
    </div>
  );
};

const Contacts = () => {
  return (
    <div style={{ backgroundColor: '#e3f2fd', padding: '20px', borderRadius: '8px', marginTop: '20px' }}>
      <h3>Контакты</h3>
      <p> Email: daniilbelov845@gmail.com</p>
      <p> Телефон: +79877178545</p>
    </div>
  );
};

function App() {
  return (
    <div style={{ padding: '20px' }}>
      <h2>Задание 07: Функциональные компоненты</h2>
      <PrintHello />
      <AboutMe />
      <Contacts />
    </div>
  );
}

export default App;
