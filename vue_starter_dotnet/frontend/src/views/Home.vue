<template>
  <header>
    <h1 class="welcome">Welcome {{this.user.sub}}!</h1>
    <b-card-group column class="bcardgroup">
      <b-card class="food-search bg-light">
        <food-search></food-search>
      </b-card>
      <b-card class="entry-log bg-light">
        <entry-log v-on:chartDataReady="saveChartData"></entry-log>  
      </b-card>    
      <b-card class="charts">
        <daily-chart v-bind:chartData="chartData"></daily-chart>
      </b-card>
    </b-card-group>
    <b-card>
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
  color:teal;
}

.entry-log {
  color:teal;
}
</style>