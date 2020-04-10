<template>
  <header>
    <h1>Welcome {{user.sub}}!</h1>
    <br>
        <food-search></food-search>
  </header>
</template>

<script>

import FoodSearch from "@/components/FoodSearch.vue";


export default {
  name: "home",
  
  components: {
    FoodSearch,
    
    
  },
  props:{
    user:Object
  }
  
   
  
 
};
</script>

<style>
</style>