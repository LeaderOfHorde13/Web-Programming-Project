<template>
    <div class="container">
        <profile-card :fname="userInfo.fullName" :uname="userInfo.username"></profile-card>
        
        <div class="contents"> 
            <div class="newContent" v-if="id == loggedUserId">
                <new-content></new-content>
            </div>
            <div class="contentContainer" v-for="item of contents">
                <content :info="item"></content>
            </div>  
        </div>
        <div class="friend-list">
            <friend-list :followerList="follows"></friend-list>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    data(){
        return{
            loggedUserId:"" ,
            id:"",
            responserId:"",
            userInfo:{
                fullName:"",
                username:"",
            },
            contents:[],
            content:{
                id:"",
                ownerId:"",
                ownerUsername:"",
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
            follows:[],
            followInfo:{
                requesterId: "",
                requesterUsername: "",
            }
            
        }
    },
    created(){
        if(localStorage.getItem("isLogged") == "false")
        {
            //this.$router.push("/");
        }
        if(localStorage.getItem("isLogged") == "true")
        {
            this.responserId = this.$route.params.id;
            this.id= this.$route.params.id;
            this.loggedUserId = localStorage.getItem("userId");

            axios.get(`https://localhost:44386/api/Users/${this.id}`)
            .then(response=>{
                if(response.data != null)
                {
                    this.userInfo.fullName = response.data[0].name + " " + response.data[0].surname;
                    this.userInfo.username = response.data[0].username;
                }
            });

            axios.get("https://localhost:44386/api/Contents/")
            .then(response=>{
                if(response.data != null)
                {
                    for(let item of response.data)
                    {
                        if(item.ownerId == this.id)
                        {
                            this.content = item;
                            this.contents.push(this.content);
                        } 
                    }
                }
            });

            axios.get(`https://localhost:44386/api/Follows/${this.responserId}`)
            .then(response=>{
                if(response.data != null)
                {
                    for(let item of response.data){
                        if(item.isFollow == true){
                            console.log(item.requesterUsername);
                            this.followInfo.requesterId = item.requesterId;
                            this.followInfo.requesterUsername = item.requesterUsername;
                            this.follows.push(this.followInfo);
                            console.log(this.follows);
                        }
                    }
                }
            })
            
        }
    }
}
</script>

<style>

</style>