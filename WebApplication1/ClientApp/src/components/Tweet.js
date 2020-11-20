import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import * as icons from '@fortawesome/free-solid-svg-icons'
import './tweet.css'

const URL = "/";
const ENDPOINT = URL + "api/Tweets/";
class Tweet extends React.Component {
    constructor(props) {
        super(props);
        this.Delete = this.Delete.bind(this);
    }

    Delete(value) {
        const requestOptions = {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' }
        };

        fetch(ENDPOINT + this.props.data.id, requestOptions);
    }

    render() {
        return (<li>
            <p className='TweetText'>{this.props.data.text}</p>
            <button type='button' onClick={this.Delete}>
                <FontAwesomeIcon icon={icons.faTrash} />
            </button>
        </li>);
    }


}

export default Tweet;