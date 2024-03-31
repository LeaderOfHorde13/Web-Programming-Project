<template>
    <div class="profile">
        <div class="profileBox">
          <p>{{  fname  }}</p>
          <p>{{ uname }}</p>

          <div v-if="uname != username" style="background-color: inherit;">
            <div class="following" v-if="isFollow == true">
              <button class="followingBtn unfollow" @click="unfollow">Unfollow</button>
            </div>
            <div class="following" v-if="isFollow == false">
              <button class="followingBtn follow" @click="followUser">Follow</button>
            </div>
          </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
  data(){
    return{
      username:localStorage.getItem("username"),
      requesterId:"",
      responserId:"" ,
      isFollow:"",
      isData:"",
      dataId:"",
      responserUsername:"",
      follow: {
        id:"",
        requesterId: "",
        requesterUsername: "",
        responserId: "",
        responserUsername:"",
        isFollow:"" 
      }
    }
  },
  props:{fname:String ,uname:String},
  created(){
    this.requesterId = localStorage.getItem("userId");
    this.responserId = this.$route.params.id;
    if(this.requesterId != this.responserId && this.responserId != null)
    {
      axios.get(`https://localhost:44386/api/Follows/requester/${this.requesterId}/responser/${this.responserId}`)
      .then(response=>{
        console.log("req: " + this.requesterId + "->" + "res:" + " " + this.responserId );
        if(response.data != null){
          if(response.data.length == 0){
            this.isFollow = false;
          }
          if(response.data.length != 0){
            if(response.data[0].isFollow == false){
              this.isFollow = false;
            }
            else if(response.data[0].isFollow == true)
            {
              this.isFollow = true;
            }
          }
          
        }
      })
    }
    
  },
  methods:{
    unfollow(){
      axios.get(`https://localhost:44386/api/Follows/requester/${this.requesterId}/responser/${this.responserId}`)
      .then(response=>{
        if(response.data != null){
          if(response.data.length == 0){
            this.isData=false;
          }else{
            this.isData=true;
            this.follow.id=response.data[0].id;
            this.follow.responserUsername = response.data[0].responserUsername;
          }
        }
      }).finally(()=>{
        if(this.isData){ //put

          this.follow.requesterId = this.requesterId;
          this.follow.requesterUsername = this.username;
          this.follow.responserId = this.responserId;
          this.follow.isFollow = false;
          
          axios.put(`https://localhost:44386/api/Follows`, this.follow)
           .then(response=>{
             if(response.status == 200)
             {
               this.isFollow = false;
             }
           });
          
        }else{
          this.follow.requesterId = this.requesterId;
          this.follow.requesterUsername = this.username
          this.follow.responserId = this.responserId;
          this.follow.isFollow = false;

          axios.post(`https://localhost:44386/api/Follows`, this.follow)
          .then(response=>{
            if(response.status == 200){
              this.isFollow = false;
            }
          })
        }
        });
    },
    followUser(){
      axios.get(`https://localhost:44386/api/Follows/requester/${this.requesterId}/responser/${this.responserId}`)
      .then(response=>{
        if(response.data != null){
          if(response.data.length == 0){
            this.isData=false;
          }else{
            this.isData=true;
            this.follow.id=response.data[0].id;
            this.follow.responserUsername = response.data[0].responserUsername;
          }
        }
      }).finally(()=>{
        if(this.isData){ //put

          this.follow.requesterId = this.requesterId;
          this.follow.requesterUsername = this.username;
          this.follow.responserId = this.responserId;
          this.follow.isFollow = true;
          
          axios.put(`https://localhost:44386/api/Follows`, this.follow)
           .then(response=>{
             if(response.status == 200)
             {
               this.isFollow = true;
             }
           });
          
        }else{
          this.follow.requesterId = this.requesterId;
          this.follow.requesterUsername = this.username
          this.follow.responserId = this.responserId;
          axios.get(`https://localhost:44386/api/Users/${this.responserId}`)
          .then(response=>{
            if(response.data != null){
              this.follow.responserUsername = response.data[0].username;
            }
          }).finally(()=>{
            this.follow.isFollow = true;
            this.follow.id = 0;

              axios.post(`https://localhost:44386/api/Follows`, this.follow)
              .then(response=>{
                if(response.status == 200){
                  this.isFollow = true;
                }
              });
            });
          
        }
        });
    }
  }
}
</script>

<style>
/*Profile box*/
.profile{
    width: 23%;
  }

  .profileBox{
    width: 80%;
    height: 200px;
    margin: auto;
    margin-top: 30px;
    margin-bottom: 30px;
    background-color: #f7f7f7;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .profileBox p{
    margin-bottom: 10px;
    margin-top: 15px;
    font-size: 18px;
    font-weight: bold;
    color: #3f3f3f;
    background-color: inherit;
  }

  .following{
    background-color: #F7F7F7;
    width: 100px;
    height: 40px;
    text-align: center;
    margin-top: 20px;
  }

  .followingBtn{
      border: none;
      width: 100%;
      padding-top: 3px;
      margin: 0;
      height: 100%;
      color: #e9e6e6;
      font-size: 14px;
      font-weight: 700;
  }

  .follow{
    background-color: rgb(34, 128, 128);
  }

  .unfollow{
    background-color: rgb(185, 27, 27);
  }
  
/*Profile box*/
</style>