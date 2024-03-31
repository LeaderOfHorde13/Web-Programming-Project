<template>
    <div v-if="info.contentType=='post'">
        <div class="up">
          <div class="username" style="color: saddlebrown; font-weight: 800;">
            <router-link :to="/profile/ + this.info.ownerId" tag="button" style="background-color: inherit; text-decoration: none; color: inherit;">
              @{{info.ownerUsername}}
            </router-link>
          </div>
          <div class="date">
            {{ info.creatingDate }}
          </div>
        </div>
        <div class="contentText">
            <p>
              {{ info.text }}
            </p>
        </div>
        <div class="actionBar">
            <div class="counts">
              <p>{{likeCounter}} Likes</p>
              <p>{{commentCounter}} Comments</p>
              <p>{{shareCounter}} Sharing</p>
            </div>

            <div class="buttons" v-if="statistics != null">
              <button v-if="(statistics.isLiked == false)" @click="likeContent">Like</button>
              <button v-else @click="removeLikeContent">Remove Like</button>

              <button @click="commentContent">Comment</button>
              
              <button v-if="(statistics.isShared == false)" @click="shareContent">Share</button>
              <button v-else @click="removeSharingContent">Remove Sharing</button>
            </div>
            <div class="buttons" v-if="statistics == null">
              <button @click="likeContent">Like</button>
              <button @click="commentContent">Comment</button>              
              <button @click="shareContent">Share</button>
            </div>
        </div>
    </div>

    <div v-if="info.contentType=='event'">
        <div class="up">
              <div class="username" style="color: saddlebrown; font-weight: 800;">
                <router-link :to="/profile/ + this.info.ownerId" tag="button" style="background-color: inherit; text-decoration: none; color: inherit;">
                  @{{info.ownerUsername}}
                </router-link>
              </div>
              <div class="date">
                {{ info.creatingDate }}
              </div>
        </div>
        <div class="contentText">
              <p>
                {{ info.text }}
              </p>
        </div>
        <div class="eventAddress">
            <p>
              <p style="color: red; font-weight: 800;">Address :</p>
              {{ info.address }}
            </p>
        </div>
        <div class="duration">
            <div class="starting-time">
                <p><span style="color: blue; font-weight: 800;">Starting Date: </span>{{info.startingDate}}</p>
            </div>
            <div class="ending-time">
                <p><span style="color: blue; font-weight: 800;">Ending Date: </span>{{info.endingDate}}</p>
            </div>
        </div>
        <div class="actionBar">
            <div class="counts">
              <p>{{likeCounter}} Likes</p>
              <p>{{participantCounter}} Participates</p>
              <p>{{commentCounter}} Comments</p>
              <p>{{shareCounter}} Sharing</p>
            </div>
            <div class="buttons" v-if="statistics != null">
              <button v-if="(statistics.isLiked == false)" @click="likeContent">Like</button>
              <button v-else @click="removeLikeContent">Remove Like</button>
              
              <button v-if="(statistics.isParticipate == false)" @click="attendContent">Attend</button>
              <button v-else @click="removeAttendContent">Cancel Attend</button>

              <button @click="commentContent">Comment</button>
              
              <button v-if="(statistics.isShared == false)" @click="shareContent">Share</button>
              <button v-else @click="removeSharingContent">Remove Sharing</button>
            </div>
            <div class="buttons" v-if="statistics == null">
              <button @click="likeContent">Like</button>
              <button @click="attendContent">Attend</button>
              <button @click="commentContent">Comment</button>              
              <button @click="shareContent">Share</button>
            </div>
        </div>  
    </div>
    
</template>

<script>
import axios from 'axios';
export default{
    data(){
        return{
            statistics:{
              id:"" ,
              ownerId:"",
              contentId:"",
              guestsId:"",
              guestUsername:"",
              message:"",
              isChecked:"",
              isLiked:"",
              isShared:"",
              isComment:"",
              isParticipate:"",
              comment:""
            },
            userId:"",
            likeCounter : "",
            commentCounter : "",
            participantCounter : "",
            shareCounter : "",
        }
    },
    props:["info"],
    created(){
      this.userId = localStorage.getItem("userId");

      axios.get("https://localhost:44386/api/ContentStatistics/" + this.userId)
      .then(response=>{
              if(response.data != null)
              {
                for(let item of response.data){
                  if(item.contentId == this.info.id){
                    this.statistics = item;
                  }
                }
              }
            });
      
            this.likeCounter = this.info.likeCounter;
            this.commentCounter = this.info.commentCounter;
            this.participantCounter = this.info.participantCounter;
            this.shareCounter = this.info.shareCounter;
    },
    methods:{
      likeContent(){
        this.statistics.isLiked = true;
        if(this.statistics.id == ""){
          this.statistics={
            ownerId:this.info.ownerId,
            contentId:this.info.id,
            guestsId: this.userId,
            guestUsername:localStorage.getItem("username"),
            message:localStorage.getItem("username") + " liked your content",
            isChecked:false,
            isLiked:true,
            isShared:false,
            isComment:false,
            isParticipate:false,
            comment:""
          }

          axios.post("https://localhost:44386/api/ContentStatistics/", this.statistics);
          axios.put("https://localhost:44386/api/Contents/increase-like/" + this.info.id);
          this.likeCounter += 1;
        }else if(this.statistics.id != "" && this.statistics.id != 0){
          axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
          axios.put("https://localhost:44386/api/Contents/increase-like/" + this.info.id);
          this.likeCounter += 1;
        } 
      
      },
      removeLikeContent(){
        this.statistics.isLiked = false;
        axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
        axios.put("https://localhost:44386/api/Contents/discrease-like/" + this.info.id);
        this.likeCounter -= 1;
      },
      attendContent(){
        this.statistics.isParticipate = true;
        if(this.statistics.id == ""){
          this.statistics={
            ownerId:this.info.ownerId,
            contentId:this.info.id,
            guestsId: this.userId,
            guestUsername:localStorage.getItem("username"),
            message:localStorage.getItem("username") + " attended your content",
            isChecked:false,
            isLiked:false,
            isShared:false,
            isComment:false,
            isParticipate:true,
            comment:""
          }

          // this.statistics.ownerId = this.content.ownerId;
          // this.statistics.contentId = this.content.id;
          // this.statistics.guestsId = this.userId;
          // this.statistics.guestUsername = localStorage.getItem("username");
          // this.statistics.message = localStorage.getItem("username") + " shared your content";
          // this.statistics.isChecked = false;

          axios.post("https://localhost:44386/api/ContentStatistics/", this.statistics);
          axios.put("https://localhost:44386/api/Contents/increase-join/" + this.info.id);
          this.participantCounter += 1;
        }else if(this.statistics.id != "" && this.statistics.id != 0){
          axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
          axios.put("https://localhost:44386/api/Contents/increase-join/" + this.info.id);
          this.participantCounter += 1;
        } 
      },
      removeAttendContent(){
        this.statistics.isParticipate = false;
        axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
        axios.put("https://localhost:44386/api/Contents/discrease-join/" + this.info.id);
        this.participantCounter -= 1;
      },
      commentContent(){
        this.$router.push("/content/"+this.info.id);
      },
      shareContent(){
        this.statistics.isShared = true;
        if(this.statistics.id == ""){
          this.statistics={
            ownerId:this.info.ownerId,
            contentId:this.info.id,
            guestsId: this.userId,
            guestUsername:localStorage.getItem("username"),
            message:localStorage.getItem("username") + " shared your content",
            isChecked:false,
            isLiked:false,
            isShared:true,
            isComment:false,
            isParticipate:false,
            comment:""
          }

          // this.statistics.ownerId = this.content.ownerId;
          // this.statistics.contentId = this.content.id;
          // this.statistics.guestsId = this.userId;
          // this.statistics.guestUsername = localStorage.getItem("username");
          // this.statistics.message = localStorage.getItem("username") + " shared your content";
          // this.statistics.isChecked = false;
          
          axios.post("https://localhost:44386/api/ContentStatistics/", this.statistics);
          axios.put("https://localhost:44386/api/Contents/increase-share/" + this.info.id);
          this.shareCounter += 1;
        }else if(this.statistics.id != "" && this.statistics.id != 0){
          axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
          axios.put("https://localhost:44386/api/Contents/increase-share/" + this.info.id);
          this.shareCounter += 1;
        }
      },
      removeSharingContent(){
        this.statistics.isShared = false;
        axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
        axios.put("https://localhost:44386/api/Contents/discrease-share/" + this.info.id);
        this.shareCounter -= 1;
      },
    },

}
</script>

<style>
  .up{
    display: flex;
    justify-content: space-between;
    margin-top: 15px;
  }

  .up .date{
    height: 25px;
    width: 120px;
    background-color: #f7f7f7;
    border: 2px solid gray;
    border-bottom: none;
    text-align: center;
    padding-top: 3px;
    align-self: flex-end;
  }

  .username{
    height: 35px;
    width: 150px;
    background-color: #f7f7f7;
    border: 2px solid gray;
    border-bottom: none;
    text-align: center;
    padding-top: 6px;
  }

  .contentText{
    /* height: 190px; */
    height: auto;
    width: 100%;
    background-color: #f7f7f7;
    border: 2px solid gray;
    border-bottom: none;
    text-align: justify;
    padding: 6px;
  }

  .eventAddress{
    height: auto;
    width: 100%;
    background-color: #f7f7f7;
    border: 2px solid gray;
    padding-bottom: 5px;
    text-align: justify;
    padding: 6px;
  }

  .eventAddress p{
    background-color: inherit;
  }
  .counts{
    height: 35px;
    width: 100%;
    background-color: #f7f7f7;
    border: 2px solid gray;
    border-top: none;
    border-bottom: none;
    padding-top: 6px;
  }

  .contentText p{
    background-color: inherit;
    margin-bottom: 5px;
  }

  .buttons{
    height: 45px;
    width: 100%;
    background-color: #f7f7f7;
    border: 2px solid gray;
    border-top: none;
    display: flex;
    justify-content: space-around;
    align-items: center;
  }

  


  /*Event Duration*/
  .duration{
    background-color: inherit;
  }

  .duration p{
    background-color: #f7f7f7;
    border-left: 2px solid gray;
    border-right: 2px solid gray;
    padding-left: 5px;
    padding-bottom: 5px;
  }
  /*Event Duration*/


  /*content-post & content-event*/
  .actionBar{
    border-top: 2px solid gray;
  }

  .counts p{
    display: inline;
    font-size: 18px;
    margin-left: 10px;
    margin-right: 20px;
    background-color: inherit;
    color: #5c5c5c;
  }

  .buttons button{
    border: none;
    width: 120px;
    height: 30px;
    background-color: inherit;
    border: 2px solid gray;
  }
  /*content-post & content-event*/

  .route{
    font-family: inherit;
    background-color: inherit;
    border: none;
    color: inherit;
    font-weight: 800;
    font-size: inherit;
  }
</style>