<template>
  <header>
    <h1>Welcome {{this.user.sub}}!</h1>
    <br />
    <food-search></food-search>
    <display-entries></display-entries>
  </header>
</template>

<script>

import FoodSearch from "@/components/FoodSearch.vue";
import DisplayEntries from "@/components/DisplayEntries.vue"

export default {
  name: "home",
  components: {
    FoodSearch,
    DisplayEntries
  },
  props:{
    user:Object
  }
};
</script>

<style>
</style>