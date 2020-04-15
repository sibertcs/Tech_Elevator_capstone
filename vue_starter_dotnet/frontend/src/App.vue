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
  /*box-shadow: 4px 4px rgb(0, 0, 0, 40%);*/
}
</style>