import React from 'react';
import axios from 'axios';
import ReactBootstrapSlider from 'react-bootstrap-slider';
import "bootstrap-slider/dist/css/bootstrap-slider.css"
//import "bootstrap/dist/css/bootstrap.css";


class AddMany extends React.Component {
    state = {
       
            agerange: [0,100],
            pplcount:0
        }   

    onCountSliderStop = e=> {
        this.setState({pplcount: e.target.value});
    }

    onAgeRangeSliderStop = e=> {
        this.setState({agerange: e.target.value});

    }

    onAddPeople = async() => {
        const {pplcount}= this.state;
        const [minage,maxage]  = this.state.agerange;
        await axios.post('/api/people/addmany', {minage,maxage,pplcount}  );
        this.props.history.push('/');
    }


    render() { 
     
        return (
            <div style = {{minHeight: 1000}}>
             <div className = "col-md-6 offset-md-3 jumbotron">
                 <h4> Add Random People</h4>
            
                 <span>Slide to specify count for people to be generated:</span>
                 <ReactBootstrapSlider
                        value={this.state.pplcount}
                        slideStop={this.onCountSliderStop}
                        max={100}
                        min={1}
                         />
                    <br />

                    <br/>
                    <br/>
                    <span>Age Range:</span>
                     <br/>

                     <ReactBootstrapSlider
                        value={this.state.agerange}
                        slideStop={this.onAgeRangeSliderStop}
                        max={200}
                        min={1}
                         />
                     <br/>
                     <br/>

                    <button className="btn btn-success btn-block" onClick={this.onAddPeople}>Generate Random People</button>
                
             </div>
            </div>
          );
    }
}
 
export default AddMany;