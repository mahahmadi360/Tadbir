import { StuffEditor } from './StuffEditor';

import React, { Component } from 'react';

export class StuffInsert extends Component {

    constructor(props) {
        super(props);
        this.state = { stuff: null, loading: false };
    }

    renderStuffEditor(stuff) {
        return (
            <StuffEditor stuff={stuff} submitHandler={this.sendData}></StuffEditor>
        );
    }

    sendData(stuff){
        return fetch(`api/stuff`, { method: 'post' ,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(stuff)});
    }

    render() {
        let contents = this.state.loading ? (
            <p>
                <em>در حال دریافت...</em>
            </p>
        ) : (
            this.renderStuffEditor({})
        );

        return (
            <div>
                <h1 id="tabelLabel">ایجاد</h1>
                {contents}
            </div>
        );
    }
}