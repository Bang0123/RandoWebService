import React from 'react';

export class Maths extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            mafsNumber: 2,
            calcResult: null
        };

        this.reqUrl = 'https://localhost:5001/api/Maths';
        this.isEven = this.isEven.bind(this);
        this.isOdd = this.isOdd.bind(this);
        this.addInts = this.addInts.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    async isEven() {
        let res = await fetch(`${this.reqUrl}/isEven?num=${this.state.mafsNumber}`);
        let value = await res.json() ? "true" : "false";

        this.setState({
            calcResult: value
        });
    }

    async isOdd() {
        let res = await fetch(`${this.reqUrl}/isOdd?num=${this.state.mafsNumber}`);
        let value = await res.json() ? "true" : "false";
        
        this.setState({
            calcResult: value
        });
    }

    async addInts() {
        let res = await fetch(`${this.reqUrl}/addInts?num1=${this.state.mafsNumber}&num2=${this.state.mafsNumber}`);
        let value = await res.json();

        this.setState({
            calcResult: value
        });
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
        event.preventDefault();
    }

    render() {

        const titleStyle = {
            textAlign: 'center',
            color: 'white'
        };

        return (
            <div>
                <button onClick={this.isEven}>isEven</button>
                <button onClick={this.isOdd}>isOdd</button>
                <button onClick={this.addInts}>addInts</button>
                <input type="number" name="mafsNumber" value={this.state.mafsNumber}
                    onChange={this.handleInputChange}/>
                    <h3 style={titleStyle}>{this.state.calcResult}</h3>
            </div>
        );
    }
}