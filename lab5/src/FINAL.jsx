import React, { useState } from 'react';
import PropTypes from 'prop-types';

// Hero Component
const Hero = (props) => {
  return (
    <div className="container m-5">
      <h1 className="display-4">{props.title}</h1>
      <p className="lead">{props.description}</p>
      <a className="btn btn-primary btn-lg" href={props.buttonURL} role="button">
        {props.buttonLabel}
      </a>
    </div>
  );
};

Hero.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
  buttonLabel: PropTypes.string,
  buttonURL: PropTypes.string
};

// Alert Component with conditional rendering and colors
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

  const handleClick = () => {
    if (props.onClick) {
      props.onClick();
    }
  };

  return (
    <div 
      className={`alert ${alertClass}`} 
      role="alert"
      onClick={handleClick}
      style={{ cursor: props.onClick ? 'pointer' : 'default' }}
    >
      {props.text}
    </div>
  );
};

Alert.propTypes = {
  show: PropTypes.bool,
  text: PropTypes.string,
  color: PropTypes.string,
  onClick: PropTypes.func
};

// Bootstrap Card Component
const BootstrapCard = (props) => {
  return (
    <div className="card m-3" style={{ maxWidth: '350px' }}>
      <img className="card-img-top" src={props.imageUrl} alt="Card" />
      <div className="card-body">
        <h5 className="card-title">{props.title}</h5>
        <p className="card-text">{props.description}</p>
        <a href={props.buttonUrl} className="btn btn-primary">
          {props.buttonLabel}
        </a>
      </div>
    </div>
  );
};

BootstrapCard.propTypes = {
  title: PropTypes.string,
  imageUrl: PropTypes.string,
  description: PropTypes.string,
  buttonUrl: PropTypes.string,
  buttonLabel: PropTypes.string
};

// Badge Component with styles
const Badge = (props) => {
  const badgeStyles = {
    backgroundColor: props.bgColor || '#007bff',
    color: props.textColor || 'white',
    border: `3px solid ${props.borderColor || '#0056b3'}`,
    borderRadius: '50%',
    width: '100px',
    height: '100px',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    fontSize: '14px',
    fontWeight: 'bold',
    margin: '10px',
    textAlign: 'center',
    padding: '10px'
  };

  return <div style={badgeStyles}>{props.text}</div>;
};

Badge.propTypes = {
  text: PropTypes.string,
  bgColor: PropTypes.string,
  textColor: PropTypes.string,
  borderColor: PropTypes.string
};

// Main App Component
function App() {
  const [clickCount, setClickCount] = useState(0);
  const [showAlert, setShowAlert] = useState(true);

  const planets = ['Mars', 'Venus', 'Jupiter', 'Earth', 'Saturn', 'Neptune'];
  
  const movies = [
    { title: 'Марти Великолепный', year: 2024 },
    { title: 'Форест Гамп', year: 1994 },
    { title: 'Зелёная книга', year: 2018 }
  ];

  const handleAlertClick = () => {
    setClickCount(clickCount + 1);
    console.log(`Alert clicked ${clickCount + 1} times!`);
  };

  const toggleAlert = () => {
    setShowAlert(!showAlert);
  };

  return (
    <div style={{ padding: '20px' }}>
      <h1 style={{ textAlign: 'center', color: '#667eea', marginBottom: '30px' }}>
        🎓 Финальный проект - React Lab 5
      </h1>

      {/* Hero Section */}
      <Hero
        title="Добро пожаловать в React!"
        description="React - самая популярная библиотека для создания пользовательских интерфейсов. Изучайте компоненты, props, state и многое другое!"
        buttonLabel="Перейти на официальный сайт"
        buttonURL="https://react.dev/"
      />

      {/* Alerts Section */}
      <div className="container m-5">
        <h2>Оповещения с условным рендерингом</h2>
        <button className="btn btn-secondary mb-3" onClick={toggleAlert}>
          {showAlert ? 'Скрыть' : 'Показать'} оповещение
        </button>
        
        <Alert 
          text={`Привет! Ты кликнул ${clickCount} раз(а). Кликни еще!`}
          color="blue" 
          show={showAlert}
          onClick={handleAlertClick}
        />
        
        <Alert 
          text="✅ Успешно изучены все основы React!"
          color="green" 
          show={true}
        />
        
        <Alert 
          text="⚠️ Не забудь практиковаться каждый день!"
          color="yellow" 
          show={true}
        />
      </div>

      {/* Cards Section */}
      <div className="container m-5">
        <h2>Bootstrap Cards с Props</h2>
        <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
          <BootstrapCard
            title="Bob Dylan"
            imageUrl="Dylan.png?raw=true"
            description="Bob Dylan - американский певец, автор песен и художник, оказавший огромное влияние на популярную музыку."
            buttonUrl="https://en.wikipedia.org/wiki/Bob_Dylan"
            buttonLabel="Узнать больше"
          />
          
          <BootstrapCard
            title="React.js"
            imageUrl="Dylan.png?raw=true"
            description="React - JavaScript библиотека для создания пользовательских интерфейсов. Разработана Facebook."
            buttonUrl="https://react.dev/"
            buttonLabel="Документация"
          />
          
          <BootstrapCard
            title="JavaScript"
            imageUrl="Dylan.png?raw=true"
            description="JavaScript - язык программирования, который делает веб-страницы интерактивными и динамичными."
            buttonUrl="https://developer.mozilla.org/en-US/docs/Web/JavaScript"
            buttonLabel="MDN Docs"
          />
        </div>
      </div>

      {/* List with map() */}
      <div className="container m-5">
        <h2>Планеты солнечной системы (map)</h2>
        <ul className="list-group" style={{ maxWidth: '500px' }}>
          {planets.map((planet, index) => (
            <li key={index} className="list-group-item">
              🪐 {planet}
            </li>
          ))}
        </ul>
      </div>

      {/* Objects with map() */}
      <div className="container m-5">
        <h2>Любимые фильмы (map objects)</h2>
        <ul className="list-group" style={{ maxWidth: '500px' }}>
          {movies.map((movie, index) => (
            <li key={index} className="list-group-item">
              <strong>{movie.title}</strong> ({movie.year})
            </li>
          ))}
        </ul>
      </div>

      {/* Badges with styles */}
      <div className="container m-5">
        <h2>Технологии (Styled Badges)</h2>
        <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
          <Badge 
            text="React" 
            bgColor="#61dafb" 
            textColor="#000" 
            borderColor="#00d8ff" 
          />
          <Badge 
            text="JavaScript" 
            bgColor="#f7df1e" 
            textColor="#000" 
            borderColor="#f0db4f" 
          />
          <Badge 
            text="HTML5" 
            bgColor="#e34c26" 
            textColor="#fff" 
            borderColor="#f06529" 
          />
          <Badge 
            text="CSS3" 
            bgColor="#264de4" 
            textColor="#fff" 
            borderColor="#2965f1" 
          />
          <Badge 
            text="Bootstrap" 
            bgColor="#7952b3" 
            textColor="#fff" 
            borderColor="#6610f2" 
          />
        </div>
      </div>

      {/* Footer */}
      <div className="container m-5" style={{ textAlign: 'center', padding: '20px', backgroundColor: '#f8f9fa', borderRadius: '10px' }}>
        <h3>🎉 Все задания выполнены!</h3>
        <p>Этот проект демонстрирует все изученные концепции React:</p>
        <ul style={{ listStyle: 'none', padding: 0 }}>
          <li>✅ Базовый рендеринг и JSX</li>
          <li>✅ Работа с объектами и массивами</li>
          <li>✅ Функциональные компоненты</li>
          <li>✅ Props и PropTypes</li>
          <li>✅ Условный рендеринг</li>
          <li>✅ Стилизация компонентов</li>
          <li>✅ Обработка событий</li>
          <li>✅ State (useState)</li>
          <li>✅ Map для массивов и объектов</li>
        </ul>
      </div>
    </div>
  );
}

export default App;
