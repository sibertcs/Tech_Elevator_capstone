<template>
   <div id="app">
    <div id="nav" class="navbar justify-content-center fixed-top" style="background-color: #e3f1f1;">
      <button class="btn btn-outline-info" color:teal v-if="!isLoggedIn">
        <router-link to="/">Login</router-link>
      </button>
      <button class="btn btn-outline-info" v-if="isLoggedIn" v-on:click.prevent="logout">Logout</button>
      <button class="btn btn-outline-info">
        <router-link to="/register">Register</router-link>
      </button>
      <button class="btn btn-outline-info">
        <router-link to="/home">Home</router-link>
      </button>
      <button class="btn btn-outline-info">
        <router-link to="/profile">View Profile</router-link>
      </button>
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
      user: null,
      isHidden: false
    };
  },
  methods: {
    getUser() {
      this.user = auth.getUser();
      this.isLoggedIn =true;
    },
    logout() {
      auth.logout();
      this.isLoggedIn = false;
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
  /* width:100%; */
  /* position: relative; */
}
#nav{
  text-align:center;
}
</style>