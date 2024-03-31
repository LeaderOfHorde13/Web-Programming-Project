<template>
    <div class="recommendBox">
       <form>
          <h3>Search for Activities: </h3>
          <input v-model="search" placeholder="Enter text..."/>
          <button v-on:click.prevent="validate" @click="apiCall">Search!</button>
       </form> 
       <div class="data" >
          <li v-for="item of eventList">
            <ul>{{item.name}}</ul>
            <ul>{{item.place}}</ul>
            <ul>{{item.date}}</ul>
          </li>

       </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
  data(){
    return{
      search:"" ,
      event:{ 
        date: "",
        name: "",
        place: "",   
      },
      eventList:[]
    }
  },
  methods:{
    apiCall(){
      axios.get(`http://127.0.0.1:5000/?location=${this.search}`)
      .then(response=>{
        
        if(response.data != null){
          for(let item of response.data){
            //console.log(item);
            this.event.date = item.date;
            this.event.name = item.name;
            this.event.place = item.place;

            this.eventList.push(this.event);
          }
        }
      }).finally(()=>{
        console.log(this.eventList);
      })
    }
  }
}
</script>

<style>
  .recommendBox{
    width: 80%;
    height: 300px;
    margin: auto;
    margin-top: 30px;
    margin-bottom: 30px;
    /* background-color: #f7f7f7; */
  }
  .recommendBox h3 {
    padding: 5px 0;
  }
  .recommendBox input {
    padding: 7px 0px;
    margin: 3px 0px;
    border-radius: 5px;
  }
  .recommendBox button {
    padding: 10px 7px;
    margin-top: 3px;
    border-radius: 5px;
  }
</style>