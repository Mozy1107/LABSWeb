import { useState } from 'react';

// Импорт всех лабораторных
import Lab01 from './labs/L01';
import Lab02 from './labs/L02';
import Lab03 from './labs/L03';
import Lab04 from './labs/L04';
import Lab05 from './labs/L05';
import Lab06 from './labs/L06';
import Lab07 from './labs/L07';
import Lab08 from './labs/L08';
import Lab09 from './labs/L09';
import Lab10 from './labs/L10';
import Lab11 from './labs/L11';

function App() {
  const [lab, setLab] = useState('01');

  // Объект с компонентами лабораторных
  const labs = {
    '01': <Lab01 />,
    '02': <Lab02 />,
    '03': <Lab03 />,
    '04': <Lab04 />,
    '05': <Lab05 />,
    '06': <Lab06 />,
    '07': <Lab07 />,
    '08': <Lab08 />,
    '09': <Lab09 />,
    '10': <Lab10 />,
    '11': <Lab11 />,
  };

  // Жёстко зафиксированный порядок, чтобы листалось корректно
  const labNumbers = ['01','02','03','04','05','06','07','08','09','10','11'];
  const currentIndex = labNumbers.indexOf(lab);

  const handlePrev = () => {
    if (currentIndex > 0) setLab(labNumbers[currentIndex - 1]);
  };

  const handleNext = () => {
    if (currentIndex < labNumbers.length - 1) setLab(labNumbers[currentIndex + 1]);
  };

  return (
    <div style={{ padding: '20px' }}>
      <h1>Лабораторная работа</h1>

      <div style={{ marginBottom: '20px' }}>
        <button onClick={handlePrev} disabled={currentIndex === 0}>← Назад</button>
        <span style={{ margin: '0 15px' }}>Задание {lab}</span>
        <button onClick={handleNext} disabled={currentIndex === labNumbers.length - 1}>Вперёд →</button>
      </div>

      {labs[lab]}
    </div>
  );
}

export default App;
