<template>
  <div id="app">
    <div id="nav">
      <button>
        <router-link v-on:loggedIn="getUser" to="/">Login</router-link>
      </button>
      <button>
        <router-link to="/register">Register</router-link>
      </button>
      <button>
        <router-link to="/home">Home</router-link>
      </button>
      <button>
        <router-link to="/profile">View Profile</router-link>
      </button>
      <button v-on:click.prevent="logout">Logout</button>
    </div>
    <router-view v-bind:user="user" v-on:loggedInUser="getUser" />
  </div>
</template>
<script>
import auth from "./auth";

export default {
  name: "app",
  components: {},
  data() {
    return {
      user: null
    };
  },
  methods: {
    getUser() {
      this.user = auth.getUser();
      
    },
    logout() {
      auth.logout();
      this.$router.push("/");
    }
  },
  created() {
    this.getUser();
    
  }
};
</script>

<style>
* {
  margin: 0;
  padding: 0;
}
body {
  background-color: #4eadea;
  font-family: "Roboto Condensed", sans-serif;
}
#app {
  width: 50%;
  min-height: 100vh;
  height: 100%;
  background-color: #fff;
  margin: 10px auto;
  padding: 20px;
  box-shadow: 4px 4px rgb(0, 0, 0, 40%);
}
</style>