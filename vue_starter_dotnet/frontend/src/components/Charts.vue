<template>
  <div>
    <canvas id="calorie-chart" >Chart</canvas>
  </div>
</template>

<script>
import Chart from "chart.js";
import calorieChartData from "../chart-data.js";

export default {
  name: "charts",
  data() {
    return {
     calorieChartData
    };
  },
  methods: {
    createChart(chartId, chartData) {
      const ctx = document.getElementById(chartId);
      const myChart = new Chart(ctx, {
        type: chartData.type,
        data: chartData.data,
        options: chartData.options
      });
        return myChart;
    }
    
  },
  mounted() {

      this.calorieChartData.data.datasets[0].data=[25,5,10,15];
    this.createChart("calorie-chart", this.calorieChartData);
  }
};
</script>

<style>
</style>