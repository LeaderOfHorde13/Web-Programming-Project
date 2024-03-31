<template>
    <div class="container" v-for="item in infos">
        <user :userInfo="item"></user>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    data(){
        return{
            userInfo:{
                fullname:"",
                username:"" ,
                id:""
            },
            infos:[],
            data:"",
        }
    },
    created(){
        if(localStorage.getItem("isLogged") == "false")
        {
            this.$router.push("/");
        }
        if(localStorage.getItem("isLogged") == "true")
        {
            this.data = this.$route.path.replace("/search/","");

            axios.get(`https://localhost:44386/api/Users/uname/${this.data}`)
            .then(response=>{
                if(response.data != null){
                    for(let item of response.data){
                        this.userInfo.fullname = item.name + " " + item.surname;
                        this.userInfo.username = item.username;
                        this.userInfo.id = item.id;
                        this.infos.push(this.userInfo);
                    }
                }
            })
        }
    },
    watch:{
        $route (to,from){
            this.infos = [];
            this.data = to.path.replace("/search/","");
            axios.get(`https://localhost:44386/api/Users/uname/${this.data}`)
            .then(response=>{
                if(response.data != null){
                    for(let item of response.data){
                        this.userInfo.fullname = item.name + " " + item.surname;
                        this.userInfo.username = item.username;
                        this.userInfo.id = item.id;
                        this.infos.push(this.userInfo);
                    }
                }
            })
        }
    }

}
</script>

<style scoped>
    .container{
        width: 60%;
        display: flex;
        flex-direction: column;
        align-items: center;
        padding: 10px;
        justify-content: center;
        margin: auto;
    }
</style>
