import React from 'react';
import axios from 'axios';
import {produce} from 'immer';
import Calendar, { MonthView } from 'react-calendar';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";


class AddPerson extends React.Component {
    state = {
       
            firstname: '',
            lastname: '' ,
            dob: ''
        }   

    onTextChange = e=> {
     const nextState = produce(this.state, draft => {
         draft[e.target.name] = e.target.value;
     })
     this.setState(nextState);
    }

   

    onAddPerson = async() => {
        const {firstname,lastname,dob}= this.state;
        console.log(firstname, lastname, dob);
        await axios.post('/api/people/addperson', {firstname,lastname,dob}  );
        this.props.history.push('/');
    }


    render() { 
        const {firstname, lastname, dob} = this.state;
        return (
            <div style = {{minHeight: 1000}}>
             <div className = "col-md-6 offset-md-3 jumbotron">
                 <h4> Add a New Person</h4>
                 <input  name="firstname" value={firstname} type="text" className='form-control'onChange={this.onTextChange} placeholder="First Name" />
                 <input  name="lastname" value={lastname} type="text" className='form-control'onChange={this.onTextChange} placeholder="Last Name" />
                 <br/>
                 
                 <DatePicker
                   onChange = {date=> this.setState({dob: date})}
                   selected = {this.state.dob}
                   className="form-control"
                   placeholderText="Date of Birth"
                   />
                 {/* 
                 <span>Select DOB:</span>
                 <Calendar
                    onChange={date=> this.setState({dob: date})}
                    value={this.state.dob}    
                    className="form-control"               
                /> */}
                 <br/>
                 <button className="btn btn-success btn-block" onClick={this.onAddPerson}>Submit</button>
             </div>
            </div>
          );
    }
}
 
export default AddPerson;