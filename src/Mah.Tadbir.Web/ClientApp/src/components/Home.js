import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, world!</h1>
        <p>عملیات مورد نظر خود را انتخاب کنید</p>
        <button className="btn btn-primary">
                                    <Link
                                        to={{
                                            pathname: `/stuffs`,
                                        }}
                                    >
                                        لیست اقلام
                                    </Link>
                                </button>
                                <button className="btn btn-primary">
                                    <Link
                                        to={{
                                            pathname: `/invoices`,
                                        }}
                                    >
فاکتور ها                                    </Link>
                                </button>
      </div>
    );
  }
}
