import React from "react";

import dylanImage from "./img/Dylan.png"; 

function App() {
  const data = {
    cardTitle: "Bob Dylan",
    cardDescription: "Bob Dylan (born Robert Allen Zimmerman, May 24, 1941) is an American singer/songwriter, author, and artist who has been an influential figure in popular music and culture for more than five decades.",
    button: {
      url: "https://en.wikipedia.org/wiki/Bob_Dylan",
      label: "Go to wikipedia"
    }
  };

  return (
    <div style={{ display: "flex", justifyContent: "center", paddingTop: "50px" }}>
      <div className="card" style={{ width: "18rem", border: "1px solid #ced4da", borderRadius: "0.25rem", overflow: "hidden" }}>
        
        <img 
          src={dylanImage} 
          className="card-img-top" 
          alt="Bob Dylan" 
          style={{ width: "100%" }}
        />
        
        <div className="card-body" style={{ padding: "1.25rem" }}>
          <h5 className="card-title">{data.cardTitle}</h5>
          <p className="card-text" style={{ fontSize: "0.9rem", color: "#555" }}>
            {data.cardDescription}
          </p>
          <a href={data.button.url} className="btn btn-primary" style={{ backgroundColor: "#007bff", color: "white", padding: "10px", textDecoration: "none", borderRadius: "5px", display: "inline-block" }}>
            {data.button.label}
          </a>
        </div>
      </div>
    </div>
  );
}

export default App;