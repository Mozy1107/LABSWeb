import React from 'react';

function App() {
  const customer = {
    first_name: "Даниил",
    last_name: "Белов",
    age: 19,
    city: "Йошкар-Ола",
    email: "daniilbelov845@gmail.com",
    phone: "+79877178545"
  };
  
  return (
    <div style={{ padding: '20px', fontFamily: 'Arial, sans-serif' }}>
      <h2>Задание 02: Рендеринг объектов</h2>
      <h1>My name is {customer.first_name}</h1>
      <h2>My last name is {customer.last_name}</h2>
      <div style={{ marginTop: '20px', padding: '15px', backgroundColor: '#f0f0f0', borderRadius: '8px' }}>
        <p><strong>Возраст:</strong> {customer.age} лет</p>
        <p><strong>Город:</strong> {customer.city}</p>
        <p><strong>Email:</strong> {customer.email}</p>
        <p><strong>Телефон:</strong> {customer.phone}</p>
      </div>
    </div>
  );
}

export default App;
