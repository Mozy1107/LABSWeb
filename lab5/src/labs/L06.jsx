import React from 'react';

function App() {
  // Наш массив объектов с фильмами
  const movies = [
    { title: 'Железный человек', year: 2008, genre: 'Фантастика/Боевик' },
    { title: 'Мстители: Война бесконечности', year: 2018, genre: 'Фантастика/Приключения' },
    { title: 'Первый мститель', year: 2011, genre: 'Боевик/Приключения' },
    { title: 'Марти Великолепный', year: 2024, genre: 'Драма' },
    { title: 'Форест Гамп', year: 1994, genre: 'Драма' }
  ];

  return (
    <div style={{ padding: '20px', fontFamily: 'Arial' }}>
      <h1>Мой список фильмов</h1>
      <ul>
        {/* Используем .map(), чтобы пройтись по каждому фильму и создать <li> */}
        {movies.map((movie, index) => {
          return (
            <li key={index} style={{ marginBottom: '10px' }}>
              <strong>{movie.title}</strong> ({movie.year}) — <i>{movie.genre}</i>
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default App;