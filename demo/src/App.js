import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

 

function List() {
  const products = [
    { title: 'wings', id: 1 },
    { title: 'feather', id: 2 },
    { title: 'beak', id: 3 },
  ];

  const listItems = products.map(product =>
    <li key={product.id} className='features'>{product.title}</li>
  )

  return (
    <ul>{listItems}</ul>
  )
}


function AboutMe() {
  return (
    <>
      <h1>About</h1>
      <p>Hello there.<br />How do you do?</p>

      <h1>pinguino 🐧🐧</h1>
      <List />
      
    </>
  )
}


function MyButton({count, onClick}) { 
  return ( 
    <button onClick={onClick}>
      you have {count} fishies 🐟
    </button>
  )
}


function ResetButton({onClick}) { 
  return ( 
    <button onClick={onClick}>
      Reset count
    </button>
  )
}
function App() {
  const [count, setCount] = useState(0);

  function handleClick() {
    setCount(count + 1);
  }
  function Reset() { 
    setCount(0); 
  }

  return (
    <div className="App">

      <AboutMe />
      <MyButton count = {count} onClick={handleClick}/>
      <ResetButton onClick={Reset}/>

    </div>
  );
}

export default App;
