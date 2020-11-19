import React from 'react';
import './main.css'
import Tweet from './Tweet';

const URL = "/";
const ENDPOINT = URL + "api/Tweets/";
class MainPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = { TweetArray: [{ id: 1, text: "" }, { id: 2, text: "" }], value: "" };
        this.AddNew = this.AddNew.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    componentDidMount() {
        const requestOptions = {
            method: "GET",
            headers: {
                'Content-Type': 'application/json'
            }
        };

        fetch(ENDPOINT + this.props.userID, requestOptions)
            .then(response => response.json())
            .then(data => this.setState({ TweetArray: data }));
    }


    AddNew(event) {
        var thearray = this.state.TweetArray;
        var NewID = thearray.length + 1;
        thearray.push({ id: NewID, text: this.state.value });
        this.setState({ TweetArray: thearray, value: "" });

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ "userid": this.props.userID, "text": this.state.value })
        };

        fetch(ENDPOINT, requestOptions);
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    render() {
        const listItems = this.state.TweetArray.map((number) =>
            <Tweet data={number}></Tweet>
        );

        return (<div>
            <div id="myDIV" class="header">
                <h2>Welcome to Fake Twitter: {this.props.username}</h2>
                <input type="text" id="myInput" placeholder="Please Enter some text to tweet..." value={this.state.value} onChange={this.handleChange} />
                <span onClick={this.AddNew} class="addBtn">Add</span>
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