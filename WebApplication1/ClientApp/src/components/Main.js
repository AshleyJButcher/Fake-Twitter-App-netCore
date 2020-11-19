import React from 'react';
import './main.css'

const URL = "/";
const ENDPOINT = URL + "api/Tweets/1";
class MainPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = { TweetArray: [{ id: 1, text: "" }, { id: 2, text: "" }], value: "" };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    componentDidMount() {
        const requestOptions = {
            method: "GET",
            headers: {
                'Content-Type': 'application/json'
            }
        };

        fetch(ENDPOINT, requestOptions)
            .then(response => response.json())
            .then(data => this.setState({ TweetArray: data }));
    }


    handleSubmit(event) {
        var thearray = this.state.TweetArray;
        thearray.push({ id: thearray.length +1, text: this.state.value });
        this.setState({ TweetArray: thearray });
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    render() {
        const listItems = this.state.TweetArray.map((number) =>
            <li>{number.text}</li>
        );

        return (<div>
            <div id="myDIV" class="header">
                <h2>Welcome to Fake Twitter: {this.props.username}</h2>
                <input type="text" id="myInput" placeholder="Please Enter some text to tweet..." value={this.state.value} onChange={this.handleChange} />
                <span onClick={this.handleSubmit} class="addBtn">Add</span>
            </div>

            <ul id="myUL">
                {
                    listItems
                }
            </ul>
        </div>)
    }
}

export default MainPage;