import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import * as icons from '@fortawesome/free-solid-svg-icons'
import './tweet.css'

class Tweet extends React.Component {
    constructor(props) {
        super(props);
        this.Editing = this.Editing.bind(this);
        this.Delete = this.Delete.bind(this);
    }

    Editing(value) {
        alert("implement me");
    }

    Delete(value) {
        alert("implement me");
    }

    render() {
        return (<li>
            <p className='TweetText'>{this.props.data.text}</p>
            <button type='button' >
                <FontAwesomeIcon icon={icons.faEdit} onclick={this.Editing}/>
            </button>
            <button type='button' onclick={this.Delete}>
                <FontAwesomeIcon icon={icons.faTrash} />
            </button>
        </li>);
    }


}

export default Tweet;