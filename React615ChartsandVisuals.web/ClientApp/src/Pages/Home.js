import React, { Component } from 'react';
import axios from 'axios';
import { PieChart } from "react-minimal-pie-chart";

class Home extends Component {
  state = {  
    people:[],
    agecategory: [],
    piedata: [],
    showchart: false
    
  }

  componentDidMount =async()=> {
   this.refreshPeople();
  }

  refreshPeople =async()=> {
    const {data} = await axios.get('/api/people/getpeople');
    this.setState({people: data});
    const {data: agecategory} = await axios.get('/api/people/agecategory');
    this.setState({agecategory});
  }

getRandomColor =() =>  {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++ ) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

buildChartData = () => {
   const piedata = [];
   this.state.agecategory && this.state.agecategory.map(c => 
          {
            piedata.push({ 'title': c.ageBracket, 'value': c.peopleCount, 'color':  this.getRandomColor() });          
          })  
  
  /* const piedata = 
  [
    { title: "One", value: 100, color: "#E38627" },
    { title: "Two", value: 15, color: "#C13C37" },
    { title: "Three", value: 20, color: "#6A2135" }
  ]; */
     return piedata;
    }

onToggleChart=()=> {
    this.setState({showchart: !this.state.showchart});
}

  render() { 
          const piedata = this.buildChartData();
          console.log(piedata);
          const text = this.state.showchart ? 'Hide' : 'Show'
          
  return (  
      <>
      <h3 style={{textAlign: 'center'}}>People</h3>     
     <button className="btn btn-warning" onClick= {this.onToggleChart}>{text} Pie Chart</button>  

      {this.state.showchart &&  
       <div style={{ height: 200 }}>
           <PieChart     
            animate={true}
            data={piedata}
          />     
      </div>  
       }

      <table className="table table-bordered table-hover table-striped" style={{marginTop: 30}}>
        <thead>
          <tr>
            <th>First Name</th>            
            <th>Last Name</th>           
            <th>DOB</th>           
            <th>Age</th>         
         </tr>
        </thead>
        <tbody>
          {this.state.people.map( p=> 
            <tr key={p.id}>
              <td>{p.firstName}</td>
              <td>{p.lastName}</td>
              <td>{ new Date(p.dob).toLocaleDateString()}</td>
              <td>{p.age}</td>           
            </tr>

          )}
          
        </tbody>
      </table>
      </>
    );
  }
}
 
export default Home;