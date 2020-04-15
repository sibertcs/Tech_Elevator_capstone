<template>
  <header>
    <h1>Welcome {{this.user.sub}}!</h1>
    <br />
    <b-card-group column>
    <b-card class="food-search"><food-search></food-search></b-card>
    <b-card class="entry-log"><entry-log></entry-log></b-card>
    </b-card-group>
    <b-card class="charts"><charts></charts></b-card>
    
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
.food-search{
  color:blue;
  
}
.entry-log{
  
}
.charts{
  
}
</style>