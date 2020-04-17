<template>
  <header>
    <div id="container" style="position: relative">
      <div id="div1" style="position: absolute; width: 100%">
    <b-card-group column class="bcardgroup mx-auto" style="padding:10px">
      <b-card title="What did you eat?" style="color: #17a2b8; max-width: 450px" class="cards food-search bg-light">
        <food-search></food-search>
      </b-card>
    <!--   <b-card title="Items Consumed..." style="justify-align: center; overflow-y:auto; color: #17a2b8" class="cards entry-log bg-light"> -->
     
      <b-card title="Food Log" style="overflow-y:auto; color: #17a2b8; max-height: 350px; max-width: 300px" class="cards entry-log bg-light">
        <entry-log v-on:chartDataReady="saveChartData"></entry-log>
      </b-card>
      <b-card style="max-height: 350px; max-width: 350px;" class=" cards bg-light">
        <daily-chart title="Daily Calories" style="color: #17a2b8; width:100%; height: 100%" v-bind:chartData="chartData"></daily-chart>
      </b-card>
    </b-card-group>
      </div>
      <div id="div2" style="position: absolute; width: 100%; margin-top: 375px; margin-left: 168px">
      <b-card style="max-height: 350px; max-width: 600px" class="cards mx-auto">
        <progress-charts :key="chartKey"></progress-charts>
      </b-card>
      </div>
    </div>
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
  height:575px;
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
  text-align: left;
}

.progressCharts{
  margin:0 auto;
  float: none;
  margin-bottom:10px;
}
.food-search {
  color: teal;
  /* text-align: center; */
}

.bcardgroup {
  width: 100%;
  height: 700px;
}

/* .welcome {
  text-align: center;
  color: teal;
} */

.fs {
  color: teal;
}

.entry-log {
  color: teal;
  /* text-align: center; */
}

/* .bg-light {
  text-align: center;
} */

</style>