<template>
  <div v-if="path != '/'">
    <navigation-bar></navigation-bar>
    <main>
      <router-view ></router-view>
    </main>
  </div>
  <div v-else>
    <login></login>
  </div>
      
    
  
</template>

<script>
import axios from 'axios';
export default{
    data(){
        return{
            urlPath:"" ,
            userId:"",
            user:{
              name:"",
              surname:"",
              username:"",
              birthdate:"",
              gender:"",
              creatingDate:"",
              bioText:""
            }
        }
    },
    created(){
      if(localStorage.getItem("isLogged")=="true")
      {
        this.urlPath = this.$route.fullPath;
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
      }
      
    },
    computed:{
      path(){
        return this.urlPath = this.$route.fullPath;
      }
    }
}
</script>

<style>
  *{
    background-color: #c2c2c2;
    box-sizing: border-box;
  }
  
  button:hover{
    cursor: pointer;
  }

  main{
    background-color: #c2c2c2;
  }
</style>