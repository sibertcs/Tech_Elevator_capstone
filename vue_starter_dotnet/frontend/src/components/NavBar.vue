<template>
  <div id="app">
    <div id="nav">
      <button v-if="!isLoggedIn">
        <router-link to="/">Login</router-link>
      </button>
      <button v-if="isLoggedIn" v-on:click.prevent="logout">Logout</button>
      <button>
        <router-link to="/register">Register</router-link>
      </button>
      <button>
        <router-link to="/home">Home</router-link>
      </button>
      <button>
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
</style>