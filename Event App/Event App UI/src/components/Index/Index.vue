<template>
    <div class="container">
        <profile-card :fname="user.name + user.surname"
                      :uname="user.username">
        </profile-card>  
        
        <div class="contents"> 
            <div class="newContent" >
            <new-content :ownerID="userId"></new-content>
            </div>
            <div class="contentContainer" v-for="item of contents">
            <content :info="item"></content>
            </div>  
        </div>

        <div class="event-recommend">
            <event-recommend-card></event-recommend-card>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
  data(){
    return{
      userId:"",
      contents:[],
      content:{
        id:"",
        ownerId:"",
        ownerUsername:"" ,
        contentType:"",
        text:"",
        creatingDate:"",
        likeCounter:0,
        commentCounter:0,
        shareCounter:0,
        startingDate:"",
        endingDate:"",
        address:"",
        participantCounter:0
      },
      user:{
        name:"",
        surname:"",
        username:"",
        birthdate:"",
        gender:"",
        creatingDate:"",
        bioText:""
      },

    }
  },
  created(){
    if(localStorage.getItem("isLogged")=="true")
    {
      this.$router.push("/index");
      this.userId = localStorage.getItem("userId");

      axios.get("https://localhost:44386/api/Users/"+this.userId)
        .then(response=>{
          this.user.name = response.data[0].name;
          this.user.surname = response.data[0].surname;
          this.user.username = response.data[0].username;
          this.user.birthdate = response.data[0].birthDate;
          this.user.gender = response.data[0].gender;
          this.user.creatingDate = response.data[0].creatingDate;
          this.user.bioText = response.data[0].bioText;
        });

      axios.get("https://localhost:44386/api/Contents/")
      .then(response=>{
        if(response.data != null)
        {
          for(let item of response.data)
          {
          this.content = item;
          this.contents.push(this.content);
          }
        }
      });

      

    }
    if(localStorage.getItem("isLogged") == "false")
    {
      this.$router.push("/");
    }
  },
  
}
</script>

<style>
    .container{
    display: flex;
  }

.event-recommend{
    width: 23%;
  }

  .contents{
    width: 54%;
    /* border: 1px solid yellow; */
  }

  .contents .contentContainer{
    height: auto;
    width: 80%;
    margin: auto;
    margin-top: 30px;
    margin-bottom: 25px;
    display: flex;
    flex-direction: column;
  }
</style>