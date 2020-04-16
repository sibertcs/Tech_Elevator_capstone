<template>
   <div id="app">
    <div id="nav" class="navbar navbar-dark bg-dark justify-content-center fixed-top">
      <button class="btn btn-outline-info" v-if="!isLoggedIn">
        <router-link style="color:#17a2b8" to="/">Login</router-link>
      </button>
      <button class="btn btn-outline-info" v-if="isLoggedIn" v-on:click.prevent="logout">Logout</button>
      <button class="btn btn-outline-info">
        <router-link style="color:#17a2b8" to="/register">Register</router-link>
      </button>
      <button class="btn btn-outline-info">
        <router-link style="color:#17a2b8" to="/home">Home</router-link>
      </button>
      <button class="btn btn-outline-info">
        <router-link style="color:#17a2b8" to="/profile">View Profile</router-link>
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
color: #17a2b8;
}

#nav{
  text-align:center;
  color:#17a2b8;

}
</style>