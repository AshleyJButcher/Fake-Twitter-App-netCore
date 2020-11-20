import React from 'react';
import './login.css'
class LoginPage extends React.Component
{
    constructor(props) {
        super(props);
        this.state = {
            username: "",
            password: ""
        };

        this.handleUsernameChange = this.handleUsernameChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        this.props.submitfunc({ Username: this.state.username, Password: this.state.password });
    }
    
    handleUsernameChange(event) {
        this.setState({ username: event.target.value});
    }

    handlePasswordChange(event) {
        this.setState({ password: event.target.value });
    }

    render(){
        return (<div>
            <main className="main">
                <a className="button-twitter" href="https://twitter.com/" target="_blank"></a>
                <form className="login" onSubmit={this.handleSubmit}>
                    <svg className="login-sides">
                        <line className="top-right first" x1="50%" x2="100%" y1="0" y2="0"/>
                        <line className="top-left first" x1="50%" x2="0" y1="0" y2="0"/>
                        <line className="right second" x1="100%" x2="100%" y1="0" y2="100%"/>
                        <line className="left second" x1="0" x2="0" y1="0" y2="100%"/> 
                        <line className="bottom-left third" x1="0" x2="50%" y1="100%" y2="100%"/>
                        <line className="bottom-right third" x1="100%" x2="50%" y1="100%" y2="100%"/>
                    </svg>
                    <fieldset className="login-fieldset">
                        <input type="text" placeholder="Username" className="login-fieldset-field" onChange={this.handleUsernameChange} value={this.state.username}/>
                        <input type="password" placeholder="******" className="login-fieldset-field" onChange={this.handlePasswordChange} value={this.state.password}/>
                        <button type="submit" className="login-fieldset-submit">
                            Login
                           
                            </button>
                    </fieldset>
                </form>
                </main>
        </div>)
    }
}
export default LoginPage;