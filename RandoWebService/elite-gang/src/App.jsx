import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Section, Maths, JsonTests } from './components'

class App extends React.Component {
    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                    <p>
                        Edit <code>src/App.js</code> and save to reload.
                    </p>
                    <a
                        className="App-link"
                        href="https://reactjs.org"
                        target="_blank"
                        rel="noopener noreferrer"
                    >
                        Learn React
                    </a>
                </header>
                <Section title="mAfS">
                    <Maths />
                </Section>
                <Section title="Jason tests">
                    <JsonTests />
                </Section>
            </div>
        );
    }
}

export default App;