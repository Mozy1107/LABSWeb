import React from 'react';
import PropTypes from 'prop-types';

// 1. Импортируем локальные изображения из папки src/img/
import dylanImg from './img/Dylan.png';
import hendrixImg from './img/Hendrix.webp';
import mccartneyImg from './img/McCartney.webp';

// Компонент карточки, стилизованный под скриншот
const BootstrapCard = (props) => {
  return (
    <div className="card" style={{ 
      width: '18rem', 
      border: '1px solid #e5e5e5', 
      borderRadius: '4px', 
      overflow: 'hidden',
      fontFamily: 'sans-serif' 
    }}>
      {/* Изображение передается как переменная в фигурных скобках */}
      <img 
        src={props.imageUrl} 
        className="card-img-top" 
        alt={props.title} 
        style={{ width: '100%', display: 'block' }} 
      />
      <div className="card-body" style={{ padding: '20px' }}>
        <h5 className="card-title" style={{ 
          fontSize: '1.25rem', 
          margin: '0 0 15px 0', 
          fontWeight: 'bold' 
        }}>
          {props.title}
        </h5>
        <p className="card-text" style={{ 
          fontSize: '0.95rem', 
          lineHeight: '1.5', 
          color: '#333',
          margin: '0 0 20px 0' 
        }}>
          {props.description}
        </p>
        <a 
          href={props.buttonUrl} 
          className="btn btn-primary" 
          style={{ 
            display: 'inline-block', 
            backgroundColor: '#007bff', 
            color: 'white', 
            padding: '8px 16px', 
            textDecoration: 'none', 
            borderRadius: '4px',
            fontSize: '0.9rem'
          }}
        >
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

function App() {
  return (
    <div style={{ padding: '40px', backgroundColor: '#f8f9fa', minHeight: '100vh' }}>
      <h2 style={{ marginBottom: '30px' }}>Задание 08: Исполнители</h2>
      
      <div style={{ display: 'flex', flexWrap: 'wrap', gap: '25px' }}>
        {/* Карточка Боба Дилана с локальным фото */}
        <BootstrapCard
          title="Bob Dylan"
          imageUrl={dylanImg}
          description="Bob Dylan (born Robert Allen Zimmerman, May 24, 1941) is an American singer-songwriter, author, and artist who has been an influential figure in popular music and culture for more than five decades."
          buttonUrl="https://en.wikipedia.org/wiki/Bob_Dylan"
          buttonLabel="Go to wikipedia"
        />
        
        {/* Карточка Пола Маккартни с локальным фото */}
        <BootstrapCard
          title="Paul McCartney"
          imageUrl={mccartneyImg}
          description="Sir James Paul McCartney is an English singer, songwriter and musician who gained worldwide fame with the Beatles."
          buttonUrl="https://en.wikipedia.org/wiki/Paul_McCartney"
          buttonLabel="Learn more"
        />
        
        {/* Карточка Джими Хендрикса с локальным фото */}
        <BootstrapCard
          title="Jimi Hendrix"
          imageUrl={hendrixImg}
          description="James Marshall 'Jimi' Hendrix was an American guitarist, singer and songwriter. He is widely regarded as one of the most influential."
          buttonUrl="https://en.wikipedia.org/wiki/Jimi_Hendrix"
          buttonLabel="Read more"
        />
      </div>
    </div>
  );
}

export default App;