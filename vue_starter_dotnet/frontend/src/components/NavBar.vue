<template>
   <div id="app">
    <div id="nav" class="navbar navbar-dark bg-dark justify-content-center fixed-top">
      <h4 style="font-family: Quantico; padding-right: 100px">Cal Tracker 2000</h4>
      

      <h5 v-if="this.user != undefined" style="padding-left: 500px; padding-right: 20px" >{{user.sub}}</h5>
      <button class="btn btn-outline-info" v-if="!isLoggedIn">
        <router-link style="color:#17a2b8" to="/">Login</router-link><i style="padding:4px" class="fas fa-plug"></i>
      </button>
      <button v-if="!isLoggedIn" class="btn btn-outline-info">
        <router-link style="color:#17a2b8" to="/register">Register</router-link><i style="padding:4px" class="far fa-registered"></i>
      </button>
      <button v-if="isLoggedIn" class="btn btn-outline-info" style="margin-right: 10px"><i style="padding:4px" class="fas fa-home"></i>
        <router-link style="color:#17a2b8" to="/home">Home</router-link>
      </button>
      <button v-if="isLoggedIn" class="btn btn-outline-info" style="margin-right: 10px"><i style="padding:4px" class="far fa-id-badge"></i>
        <router-link style="color:#17a2b8" to="/profile">View Profile</router-link>
      </button>
      <button class="btn btn-outline-info" v-if="isLoggedIn" v-on:click.prevent="logout"><i style="padding:4px" class="fas fa-sign-out-alt"></i>Logout</button>
    </div>
    <router-view v-on:loggedInUser="getUser" v-bind:user="user" />
  </div>
</template>

<script>
import auth from "../auth";

export default {
  name: "nav-bar",
  components: {},
  data() {
    return {
      user: Object,
      isHidden: false
    };
  },
  
  methods: {
    getUser() {
      this.user = auth.getUser();
      if(this.user != undefined){
        this.isLoggedIn =true;
      }     
    },
    logout() {
      auth.logout();
      this.isLoggedIn = false;
      this.user = undefined;
      this.$router.push("/");
    }
  },
  created() {
    this.getUser();
    
  }
};
</script>

<style>
#app{
color: #17a2b8;
}

#nav{
  text-align:center;
  color:#17a2b8;

}

</style>