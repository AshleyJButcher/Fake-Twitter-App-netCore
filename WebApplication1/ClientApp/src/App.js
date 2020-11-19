import './App.css';
import React from 'react';
import './components/Login'
import './components/Main'
import LoginPage from './components/Login';
import MainPage from './components/Main';

const URL = "/";
const ENDPOINT = URL + "api/Login/";
class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = { isLoggedIn: false, UserID: -1, Username: "" };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(data) {

           const requestOptions = {
             method: 'POST',
             headers: { 'Content-Type': 'application/json' },
               body: JSON.stringify({ "Username": data.Username, "Password": data.Password })
        };

         fetch(ENDPOINT, requestOptions)
             .then(response => response.json())
             .then(outputdata => {
                 if (outputdata && outputdata.id) {
                     this.setState({ isLoggedIn: true, UserID: outputdata.id, Username: outputdata.username})
                 } else {
                     alert(outputdata.message);
                 }

             });
    }

    render() {
        const isLoggedIn = this.state.isLoggedIn;
        return (
            <div className="App">
                {
                    (!isLoggedIn ? <LoginPage isLoggedIn={this.state.isLoggedIn} submitfunc={this.handleSubmit} /> : <MainPage userID={this.state.UserID} username={this.state.Username} />)
                }
            </div>
        );
    }
}

export default App;