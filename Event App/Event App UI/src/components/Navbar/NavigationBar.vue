<template>
    <nav>
        <div class="logo"></div>
        <div class="search">
            <div class="searchBox">
                <input v-model="searchInfo" type="text" placeholder="Search something..." style="width: 100%; height: 100%; background-color: inherit; border: none; font-size: 19px;">
            </div>
            <div class="searchBtn">
                <button @click="search" style="height: 100%; width: 100%; border: none; background-color: inherit; font-size: 19px;">
                    Search
                </button>
            </div>
        </div>
        <div class="notifications">
            <div class="notification friendship">F</div>
            <div class="notification event">E</div>
            <div class="notification post">P</div>
        </div>
        <div class="userInfo" style="display: flex; justify-content: center; align-items: center;">
            <p style="background-color: inherit;font-size: 19px;">{{user.name + " " +user.surname}}</p>
        </div>
        <div @click="logout" class="logout" style="display: flex;justify-content: center;align-items: center;">
            <p style="background-color: inherit;font-size: 19px;">Logout</p>
        </div>
    </nav>
</template>

<script>
import axios from 'axios';
export default{
    data(){
        return{
            userId:localStorage.getItem("userId"),
            user:{
                name:"",
                surname:"" ,
                username:"",
                birthdate:"",
                gender:"",
                creatingDate:"",
                bioText:""
            },
            searchInfo:"",
        }
    },
    methods:{
        logout(){
            localStorage.removeItem("token");
            localStorage.removeItem("userId");
            localStorage.removeItem("username");
            localStorage.setItem("isLogged",false);
            this.$router.push("/");
        },
        search(){
            this.$router.push(`/search/${this.searchInfo}`);
        }
    },
    created(){
        axios.get("https://localhost:44386/api/Users/"+this.userId)
        .then(response=>{
            this.user.name = response.data[0].name;
            this.user.surname = response.data[0].surname;
            this.user.username = response.data[0].username;
            this.user.birthdate = response.data[0].birthDate;
            this.user.gender = response.data[0].gender;
            this.user.creatingDate = response.data[0].creatingDate;
            this.user.bioText = response.data[0].bioText;
        })
    }
}
</script>

<style>
    *{
        margin: 0px;
        padding: 0px;
        box-sizing: border-box;
        /* background-color: #c2c2c2; */
    }

    nav{
        height: 67px;
        background-color: #3BCF4A;
        align-items: center;
        justify-content: space-between;
        display: flex;
        position: sticky;
        top: 0;
        z-index: 100;
    }
    .logo{
        width: 130px;
        height: 51px;
        margin-left: 15px;
        margin-right: 30px;
        text-align: center;
        background-color: #f7f7f7;
    }

    .search{
        display: flex;
        width: 450px;
        height: 43px;
        margin-left: 30px;
        background-color: #3BCF4A;

        /* margin-right: 425px; */
    }

    .search .searchBox{
        background-color: #f7f7f7;
        width: 519px;
        height: 100%;
        align-self: flex-start;
        margin-left: 0px;
        margin-right: 15px;
    }

    .searchBtn{
        background-color: #f7f7f7;
        width: 109px;
        height: 27px;
        align-self: center;
        /* margin-left: 15px; */
        margin-right: 0px;
    }

    .notifications{
        display: flex;
        width: 208px;
        height: 51px;
        align-items: center;
        justify-content: flex-end;
        margin-left: 40px;
        background-color: #3BCF4A;

    }

    .notification{
        width: 35px;
        height: 35px;
        background-color: #f7f7f7;
        border-radius: 50%;

        margin-right: 10px;
    }

    .userInfo{
        width: 150px;
        height: 37px;
        margin-left: 25px;
        margin-right: 20px;
        background-color: #f7f7f7;
    }

    .logout{
        width: 110px;
        height: 51px;
        margin-left: 20px;
        margin-right: 15px;
        background-color: #f7f7f7;
    }

    .logout:hover{
        cursor: pointer;
    }


</style>