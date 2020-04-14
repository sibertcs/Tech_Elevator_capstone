<template>
  <header>
    <h1>Welcome {{this.user.sub}}!</h1>
    <br />
    <food-search></food-search>
    <entry-log v-on:chartDataReady="saveChartData"></entry-log>
    <charts v-bind:chartData="chartData"></charts>
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
  methods:{
    saveChartData(data){
      this.chartData = data;
    }
  },
  data(){
    return{
      chartData: null
    }
  },
  props:{
    user:Object
  }
};
</script>

<style>
</style>