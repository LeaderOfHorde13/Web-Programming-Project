<template>
    <div class="userBox">
        <span class="user-NameSurname">{{userInfo.fullname}}</span>
        <span class="user-Username">{{ userInfo.username }}</span>
        <button class="visitUser" @click="$router.push(`/profile/${userInfo.id}`)">Visit</button>
    </div>
</template>    

<script>
export default{
    props:["userInfo"] 
}
</script>

<style>
    .userBox{
        display: flex;
        justify-content: space-evenly;
        align-items: center;
        background-color: #f7f7f7;
        margin-bottom: 10px;
        width: 100%;
        padding: 6px;
    }

    .user-NameSurname{
        padding: 6px;
        font-style: italic;
        font-weight: bold;
        font-size: 20px;
    }

    .user-Username{
        padding: 6px;
        font-weight: bold;
        font-size: 18px;
    }

    .visitUser{
        border: none;
        padding: 6px;
        width: 100px;
        background-color: inherit;
        border: 2px solid gray;
    }

    .visitUser:hover{
        background-color: gray;
        color: #f7f7f7;
    }
</style>