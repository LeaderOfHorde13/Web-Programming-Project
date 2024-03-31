<template>
    <div class="friendshipBox">
        <p style="background-color: inherit; font-weight: 800; font-size: 22px; color: red; text-align: center; margin-bottom: 15px;">Friend List</p>
        <div class="friend" v-for="item of followerList">
            <button class="userRouteBtn"  @click="rootProfile(item.requesterId)">{{item.requesterUsername}}</button>
            
          </div>
    </div>
</template>

<script>
export default{
  data(){
    return{

    }
  },
  created(){
    console.log(this.followerList);
  },
  methods:{
    rootProfile(id){
      window.location.reload();
      this.$router.push("/profile/"+id);
    }
  },
  props:["followerList"]
}
</script>

<style>
    .friendshipBox{
    width: 80%;
    height: 300px;
    margin: auto;
    margin-top: 30px;
    margin-bottom: 30px;
    background-color: #f7f7f7;
    display: flex;
    flex-direction: column;
    padding: 10px;
  }

  .friend-list{
    width: 23%;
  }

  .friend{
    background-color: inherit;
    margin-bottom: 5px;
  }
  span{
    background-color: inherit;
  }

  .userRouteBtn{
    border: none;
    background-color: inherit;
    color: blue;
    font-size: 14px;
  }

</style>