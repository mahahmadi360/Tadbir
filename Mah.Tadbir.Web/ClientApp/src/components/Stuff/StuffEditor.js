import React, { Component } from 'react';
import { Link, Redirect } from 'react-router-dom';

export class StuffEditor extends Component {
    constructor(props) {
        super(props);
        var { stuff, submitHandler } = props;
        this.state = stuff;
        this.submitHandler = submitHandler;

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value =
            target.type === 'checkbox'
                ? target.checked
                : target.type === 'number'
                ? Number(target.value)
                : target.value;
        const name = target.name;

        this.setState({
            [name]: value,
        });
    }

    showError() {
        alert('خطا در ذخیره اطلاعات');
    }

    handleSubmit(event) {
        console.log(this.state);
        this.submitHandler(this.state)
            .then((e) => {
                if (e.ok) this.setState({ successed: true });
                else this.showError();
            })
            .catch(this.showError);
        event.preventDefault();
    }

    render() {
        if (this.state.successed) {
            return <Redirect to="/stuffs" />;
        } else {
            return (
                <form onSubmit={this.handleSubmit}>
                    <label>
                        نام کالا :
                        <input
                            name="name"
                            type="text"
                            value={this.state.name}
                            onChange={this.handleInputChange}
                        />
                    </label>
                    <br />
                    <label>
                        قیمت:
                        <input
                            name="price"
                            type="number"
                            value={this.state.price}
                            onChange={this.handleInputChange}
                        />
                    </label>
                    <br />
                    <button
                        className="btn btn-primary"
                    >ثبت</button>
                    <div className="btn btn-danger">
                        <Link to={{ pathname: `/stuffs` }}>انصراف</Link>{' '}
                    </div>
                </form>
            );
        }
    }
}
