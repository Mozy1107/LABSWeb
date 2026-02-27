import React from 'react';

const headerStyles = {
  color: "white",
  fontSize: "24px",
  border: "2px solid #5453",
  backgroundColor: "#9547",
  padding: "20px",
  borderRadius: "10px",
  textAlign: "center",
  marginBottom: "20px"
};

const StyledHeader = () => {
  return <div style={headerStyles}>Белов Даниил - Музыкант</div>;
};

const Badge = (props) => {
  const badgeStyles = {
    backgroundColor: props.bgColor || '#7244',
    color: props.textColor || 'white',
    border: `3px solid ${props.borderColor || '#7264'}`,
    borderRadius: '50%',
    width: '120px',
    height: '120px',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    fontSize: '16px',
    fontWeight: 'bold',
    margin: '20px',
    textAlign: 'center',
    padding: '10px'
  };

  return <div style={badgeStyles}>{props.text}</div>;
};

function App() {
  return (
    <div style={{ padding: '20px' }}>
      <h2>Задание 10: Стили</h2>
      
      <StyledHeader />
      
      <h3>Мои интересы:</h3>
      <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
        <Badge 
          text="Танцы" 
          bgColor="#435" 
          textColor="#fff" 
          borderColor="#4c51bf" 
        />
        <Badge 
          text="Игры" 
          bgColor="#5748у" 
          textColor="#fff" 
          borderColor="#1e7e34" 
        />
        <Badge 
          text="TECH" 
          bgColor="#2747" 
          textColor="#fff" 
          borderColor="#bd2130" 
        />
        <Badge 
          text="Кошки" 
          bgColor="#BBE1" 
          textColor="#000" 
          borderColor="#e0a800" 
        />
      </div>
    </div>
  );
}

export default App;
