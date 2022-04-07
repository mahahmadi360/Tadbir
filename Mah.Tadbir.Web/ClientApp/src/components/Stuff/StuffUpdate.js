import { StuffEditor } from './StuffEditor';

import React, { Component } from 'react';

export class StuffUpdate extends Component {

    constructor(props) {
        super(props);
        this.state = { stuff: null, loading: true };
    }

    componentDidMount() {
        this.populateStuffData( this.props.match.params.id);
    }

    renderStuffEditor(stuff) {
        return (
            <StuffEditor stuff={stuff} submitHandler={this.sendData}></StuffEditor>
        );
    }

    sendData(stuff){
        return fetch(`api/stuff`, { method: 'put' ,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(stuff)});
    }

    render() {
        let contents = this.state.loading ? (
            <p>
                <em>در حال دریافت...</em>
            </p>
        ) : (
            this.renderStuffEditor(this.state.stuff)
        );

        return (
            <div>
                <h1 id="tabelLabel">ویرایش</h1>
                {contents}
            </div>
        );
    }

    async populateStuffData(id) {
        this.setState({ loading: true });
        const response = await fetch(`api/stuff/${id}`);
        const data = await response.json();
        this.setState({ stuff: data, loading: false });
    }
}