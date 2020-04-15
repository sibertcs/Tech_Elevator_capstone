<template>
<nav-bar></nav-bar>
</template>

<script>
import NavBar from "./components/NavBar.vue";


export default {
  name: "app",
  components: {
    NavBar
  },
 
  methods: {
   }
};
</script>

<style>
* {
  margin: 0;
  padding: 0;
}
body {
  background-color: #e3f1f1;
  font-family: "Roboto Condensed", sans-serif;
  padding-top: 25px;
}

#app {
  width: 80%;
  min-height: 100vh;
  height: 100%;
  background-color: lightgrey;
  margin: 10px auto;
  padding: 20px;
  /*box-shadow: 4px 4px rgb(0, 0, 0, 40%);*/
}
</style>