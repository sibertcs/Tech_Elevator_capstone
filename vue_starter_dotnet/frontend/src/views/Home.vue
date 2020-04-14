<template>
  <header>
    <h1>Welcome {{this.user.sub}}!</h1>
    <br />
    <food-search></food-search>
    <entry-log></entry-log>
    <charts></charts>
  </header>
</template>

<script>

import FoodSearch from "@/components/FoodSearch.vue";
import EntryLog from "@/components/EntryLog.vue"
import Charts from "@/components/Charts.vue"

export default {
  name: "home",
  components: {
    FoodSearch,
    EntryLog,
    Charts
  },
  props:{
    user:Object
  }
};
</script>

<style>
</style>