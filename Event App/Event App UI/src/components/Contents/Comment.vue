<template>
        <div class="commentSender" style="color: saddlebrown; font-weight: 800;" >
          @{{comment.username}}
        </div>
        <div class="commentText" >{{comment.text}}</div>
</template>

<script>
export default{
  props:["comment"] ,
  data(){
    return{
      date: new Date(),

    }
  }
}
</script>

<style>
    .comment{
    background-color: #f7f7f7;
    margin-bottom: 5px;
  }

  .commentSender{
    height: 35px;
    width: 150px;
    background-color: inherit;
    border: 2px solid gray;
    border-bottom: none;
    padding: 6px;
    text-align: center;
  }

  .commentText{
    background-color: inherit;
    width: 450px;
    border: 2px solid gray;
    padding: 6px;
  }
</style>