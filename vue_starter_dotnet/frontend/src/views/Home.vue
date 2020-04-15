<template>
  <header>
    <h1>Welcome {{this.user.sub}}!</h1>
    <br />
    <food-search></food-search>
    <entry-log v-on:chartDataReady="saveChartData"></entry-log>
    <daily-chart v-bind:chartData="chartData"></daily-chart>
    <progress-charts></progress-charts>
  </header>
</template>

<script>

import FoodSearch from "@/components/FoodSearch.vue";
import EntryLog from "@/components/EntryLog.vue";
import DailyChart from "@/components/DailyChart.vue";
import ProgressCharts from "@/components/ProgressCharts.vue";

export default {
  name: "home",
  components: {
    FoodSearch,
    EntryLog,
    DailyChart,
    ProgressCharts
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