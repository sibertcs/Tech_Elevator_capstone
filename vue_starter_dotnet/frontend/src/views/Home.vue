<template>
  <header>
    
    <b-card-group column class="bcardgroup" style="padding:10px">
      <b-card title="Search for Foods..." style="height: 400px; overflow-y:auto; color: #17a2b8" class="cards food-search bg-light">
        <food-search></food-search>
      </b-card>
      <b-card title="Items Consumed..." style="height: 400px; overflow-y:auto; color: #17a2b8" class="cards entry-log bg-light">
        <entry-log v-on:chartDataReady="saveChartData"></entry-log>
      </b-card>
      <b-card class=" cards bg-light">
        <daily-chart title="Daily Calories..." style="color: #17a2b8" v-bind:chartData="chartData"></daily-chart>
      </b-card>
    </b-card-group>
   
      
      <b-card style="width:50%" class="cards mx-auto">
        <progress-charts :key="chartKey"></progress-charts>
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
      chartData: null,
      chartKey: 0
    };
  },
  props: {
    user: Object
  }
};
</script>



<style>
.cards{
  margin:10px;
 -webkit-border-radius: 10px 10px 10px 10px;
  border-radius: 10px 10px 10px 10px;
  background: #fff;
  padding: 30px;
  width: 90%;
  max-width: 450px;
  position: relative;
  padding: 0px;
  -webkit-box-shadow: 0 30px 60px 0 rgba(5, 62, 71, 0.3);
  box-shadow: 0 30px 60px 0 rgba(5, 62, 71, 0.3);
  text-align: center;
}
  

.progressCharts{
  margin:0 auto;
  float: none;
  margin-bottom:10px;
}
.food-search {
  color: teal;
}

.bcardgroup {
  width: 100%;
}

.welcome {
  text-align: center;
  color: teal;
}

.fs {
  color: teal;
}

.entry-log {
  color: teal;
}
</style>