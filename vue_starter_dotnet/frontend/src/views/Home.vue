<template>
  <header>
    <h1>Welcome {{this.user.sub}}!</h1>
    <br />
    
    <b-card-group column>
      <b-card class="food-search">
        <food-search></food-search>
      </b-card>
      <b-card class="entry-log">
        <entry-log></entry-log>
      </b-card>
       <b-card class="charts">
      <daily-chart v-bind:chartData="chartData"></daily-chart>
    </b-card>
    </b-card-group>
   
    <b-card>
    <progress-charts></progress-charts>
    </b-card> 
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
  methods: {
    saveChartData(data) {
      this.chartData = data;
    }
  },
  data() {
    return {
      chartData: null
    };
  },
  props: {
    user: Object
  }
};
</script>

<style>
.food-search {
  color: blue;
}

</style>