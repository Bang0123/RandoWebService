import React from 'react';

export class Section extends React.Component {
    render() {

        const sectionStyle = {
            // backgroundColor: "#282c34",
        };

        const titleStyle = {
            textAlign: 'center',
            color: 'white'
        };

        return (
            <section style={sectionStyle}>
                <h2 style={titleStyle}>{this.props.title}</h2>
                {this.props.children}
            </section>
        );
    }
}


