<template>
    <div class="singleContentContainer">
        <div v-if="content.contentType=='post'">
            <div class="up">
                <div class="username" style="color: saddlebrown; font-weight: 800;">@{{ content.ownerUsername }}</div>
                <div class="date">{{ content.creatingDate }}</div>
            </div>
            <div class="contentText">
                <p>
                    {{ content.text }}
                </p>
            </div>
            <div class="actionBar">
                <div class="counts">
                    <p>{{ likeCounter }} Likes</p>
                    <p>{{ commentCounter }} Comments</p>
                    <p>{{ shareCounter }} Sharing</p>
                </div>
                <div class="buttons" v-if="statistics != null">
                    <button v-if="(statistics.isLiked == false)" @click="likeContent">Like</button>
                    <button v-else @click="removeLikeContent">Remove Like</button>
                    
                    <button v-if="(statistics.isShared == false)" @click="shareContent">Share</button>
                    <button v-else @click="removeSharingContent">Remove Sharing</button>
                </div>
                <div class="buttons" v-if="statistics == null">
                    <button @click="likeContent">Like</button>          
                    <button @click="shareContent">Share</button>
                </div>
            </div>
            <div class="comments" v-for="item of comments">
                <comment :comment="item"></comment>
            </div>
            <div class="makeAComment">
                <textarea v-model="newComment" id="userComment" name="userComment" rows="4" cols="80" style="width: 100%; height: 60%; background-color: inherit;  resize: none; font-size: 18px;" placeholder="Write something" ></textarea>
                <button @click="sendComment">Send</button>
            </div>
        </div>

        <div v-else="content.contentType=='event'">
            <div class="up">
                <div class="username">@{{ content.ownerUsername }}</div>
                <div class="date">{{ content.creatingDate }}</div>
            </div>
            <div class="contentText">
                <p>
                    {{ content.text }}
                </p>
            </div>
            <div class="eventAddress">
                <p>
                    <p style="color: red; font-weight: 800;">Address :</p>
                    {{ content.address }}
                </p>
            </div>
            <div class="duration">
                <div class="starting-time">
                    <p><span style="color: blue; font-weight: 800; background-color: inherit;">Starting Date: </span>{{content.startingDate}}</p>
                </div>
                <div class="ending-time">
                    <p><span style="color: blue; font-weight: 800; background-color: inherit;">Ending Date: </span>{{content.endingDate}}</p>
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
            <div class="comments" v-for="item of comments">
                <comment :comment="item"></comment>
            </div>
            <div class="makeAComment">
                <textarea v-model="newComment" id="userComment" name="userComment" rows="4" cols="80" style="width: 100%; height: 60%; background-color: inherit;  resize: none; font-size: 18px;" placeholder="Write something" ></textarea>
                <button @click="sendComment">Send</button>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    data(){
        return{
            id:"",
            userId:"",
            newComment:"",
            content:{
                id:"" ,
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
            statistics:{
              id:"",
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
            comments:[],
            comment:{
                id:"",
                username:"",
                usernameId:"",
                text:"",
                contentId:""
            },
            likeCounter : "",
            commentCounter : "",
            participantCounter : "",
            shareCounter : "",
            sendedComment:{
                id:0,
                username:localStorage.getItem("username"),
                usernameId:parseInt(localStorage.getItem("userId")),
                text:"",
                contentId:this.$route.params.id
            },
        }
    },
    created(){
        this.id = this.$route.params.id;
        this.userId = localStorage.getItem("userId");

        if(localStorage.getItem("isLogged") == "false")
        {
            this.$router.push("/");
        }
        if(localStorage.getItem("isLogged") == "true")
        {
            axios.get("https://localhost:44386/api/ContentStatistics/" + this.userId)
            .then(response=>{
                    if(response.data != null)
                    {
                        for(let item of response.data)
                        {
                            if(item.contentId == this.id)
                            {
                                this.statistics = item;                             
                            }
                        }
                    }     
            });
            axios.get(`https://localhost:44386/api/Contents/${this.id}`)
            .then(response=>{
                if(response.data != null){
                    for(let item of response.data){
                        this.content = item;

                        this.likeCounter = item.likeCounter;
                        this.commentCounter = item.commentCounter;
                        this.participantCounter = item.participantCounter;
                        this.shareCounter = item.shareCounter;
                    }
                }
            });
            axios.get(`https://localhost:44386/api/ContentStatistics/comments/${this.id}`)
            .then(response=>{
                if(response.data != null)
                {
                    for(let item of response.data)
                    {
                        this.comment = item;
                        this.comments.push(this.comment);
                    }
                }
            });
        }
    },
    methods:{
        likeContent(){
          this.statistics.isLiked = true;
          if(this.statistics.id == ""){
            this.statistics={
                ownerId:this.content.ownerId,
                contentId:this.id,
                guestsId: this.userId,
                guestUsername:localStorage.getItem("username"),
                message:localStorage.getItem("username") + " liked your content",
                isChecked:false,
                sLiked:true,
                isShared:false,
                isComment:false,
                isParticipate:false,
                comment:""
            }

                // this.statistics.ownerId = this.content.ownerId;
                // this.statistics.contentId = this.content.id;
                // this.statistics.guestsId = this.userId;
                // this.statistics.guestUsername = localStorage.getItem("username");
                // this.statistics.message = localStorage.getItem("username") + " liked your content";
                // this.statistics.isChecked = false;

            axios.post("https://localhost:44386/api/ContentStatistics/", this.statistics);
            axios.put("https://localhost:44386/api/Contents/increase-like/" + this.id);
            this.likeCounter += 1;
          }else if(this.statistics.id != "" && this.statistics.id != 0){
            this.statistics.isChecked = false;
            axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
            axios.put("https://localhost:44386/api/Contents/increase-like/" + this.id);
            this.likeCounter += 1;
          } 
        },
        removeLikeContent(){
            this.statistics.isLiked = false;
            axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
            axios.put("https://localhost:44386/api/Contents/discrease-like/" + this.id);
            this.likeCounter -= 1;
        },
        attendContent(){
            this.statistics.isParticipate = true;
            if(this.statistics.id == ""){
                this.statistics={
                    ownerId:this.content.ownerId,
                    contentId:this.id,
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
                // this.statistics.message = localStorage.getItem("username") + " attended your content";
                // this.statistics.isChecked = false;

                axios.post("https://localhost:44386/api/ContentStatistics/", this.statistics);
                axios.put("https://localhost:44386/api/Contents/increase-join/" + this.id);
                this.participantCounter += 1;
            }else if(this.statistics.id != "" && this.statistics.id != 0){
                this.statistics.isChecked = false;
                axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
                axios.put("https://localhost:44386/api/Contents/increase-join/" + this.id);
                this.participantCounter += 1;
            }
        },
        removeAttendContent(){
            this.statistics.isParticipate = false;
            axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
            axios.put("https://localhost:44386/api/Contents/discrease-join/" + this.id);
            this.participantCounter -= 1;
        },
        shareContent(){
          this.statistics.isShared = true;
          if(this.statistics.id == ""){
            this.statistics={
                ownerId:this.content.ownerId,
                contentId:this.content.id,
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
            axios.put("https://localhost:44386/api/Contents/increase-share/" + this.id);
            this.shareCounter += 1;
          }else if(this.statistics.id != "" && this.statistics.id != 0){
            this.statistics.isChecked = false;
            axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
            axios.put("https://localhost:44386/api/Contents/increase-share/" + this.id);
            this.shareCounter += 1;
          }
        },
        removeSharingContent(){
            this.statistics.isShared = false;
            axios.put("https://localhost:44386/api/ContentStatistics/", this.statistics);
            axios.put("https://localhost:44386/api/Contents/discrease-share/" + this.id);
            this.shareCounter -= 1;
        },
        sendComment(){
            this.sendedComment.text = this.newComment;
            axios.post("https://localhost:44386/api/ContentStatistics/comments", this.sendedComment)
            .then(response=>{
                this.comments=[];
                this.newComment = "";
                this.commentCounter += 1;
                axios.put(`https://localhost:44386/api/Contents/increase-comment/${this.$route.params.id}`);
            }).finally(response=>{
                axios.get(`https://localhost:44386/api/ContentStatistics/comments/${this.id}`)
                .then(response2=>{
                    if(response2.data != null)
                    {
                        for(let item of response2.data)
                        {
                            this.comment = item;
                            this.comments.push(this.comment);
                        }
                    }
                });
            });
            
            
            
        },
    },
    }
</script>

<style>
  .singleContentContainer{
    width: 60%;
    display: flex;
    justify-content: flex-start;
    margin-left: 7%;
    box-sizing: border-box;
    
  }

  .comments{
    height: auto;
    border: 2px solid gray;
    border-top: none;
    border-bottom: none;
    border-top: none;
    display: flex;
    flex-direction: column;
    background-color: #f7f7f7;
    padding: 30px;
  }

  .makeAComment{
    padding: 5px;
    height: 130px;
    background-color: #f7f7f7;
    border: 2px solid gray;
    border-top: none;
    display: flex;
    flex-direction: column;
  }

  .makeAComment textarea{
    background-color: red;
    border: 2px solid gray;
    padding: 5px;
  }

  .makeAComment button{
    margin-top: 5px;
    width: 83px;
    height: 27px;
    border: none;
    background-color: #5c5c5c;
    color: #f7f7f7;
    align-self: flex-end;
  }
  
</style>