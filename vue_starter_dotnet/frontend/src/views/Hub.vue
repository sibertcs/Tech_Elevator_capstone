<template>
  <header>
    <h1>Welcome {{user.sub}}!</h1>
    <br>
        <food-search></food-search>
  </header>
</template>

<script>
import auth from "../auth";
import FoodSearch from "@/components/FoodSearch.vue";

export default {
  name: "hub",
  components: {
    FoodSearch,
    
  },
  data() {
    return {
      user: this.getUser()
    };
  },
  methods: {
    getUser() {
      return auth.getUser();
    }
  }
};
</script>

<style>
</style>