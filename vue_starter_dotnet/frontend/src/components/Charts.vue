<template>
  <div>
    <canvas id="daily-calorie-chart">Chart</canvas>
  </div>
</template>

<script>
import Chart from "chart.js";
import calorieData from "../chart-data.js";

export default {
  name: "charts",
  data() {
    return {
      calorieData,
      breakfastCalories: 0,
      lunchCalories: 0,
      dinnerCalories: 0,
      snackCalories: 0
    };
  },
  props: {
    chartData: Array
  },
  created() {
    this.chartData.forEach(item => {
      if (item.mealType === "Breakfast") {
        this.breakfastCalories += item.totalCalories * 1;
      } else if (item.mealType === "Lunch") {
        this.lunchCalories += item.totalCalories * 1;
      } else if (item.mealType === "Dinner") {
        this.dinnerCalories += item.totalCalories * 1;
      } else if (item.mealType === "Snack") {
        this.snackCalories += item.totalCalories * 1;
      }
    });
  },
  methods: {
    displayDataToChart() {
      this.chartData.forEach(item => {
        if (item.mealType === "Breakfast") {
          this.breakfastCalories += item.totalCalories * 1;
        } else if (item.mealType === "Lunch") {
          this.lunchCalories += item.totalCalories * 1;
        } else if (item.mealType === "Dinner") {
          this.dinnerCalories += item.totalCalories * 1;
        } else if (item.mealType === "Snack") {
          this.snackCalories += item.totalCalories * 1;
        }
      });
    },
    createChart(chartId, chartData) {
      const ctx = document.getElementById(chartId);
      const myChart = new Chart(ctx, {
        type: chartData.type,
        data: chartData.data,
        options: chartData.options
      });
      this.displayDataToChart();
      return myChart;
    }
  },
  mounted() {
    this.calorieData.data.datasets[0].data = [
      this.breakfastCalories,
      this.lunchCalories,
      this.dinnerCalories,
      this.snackCalories
    ];
    this.createChart("daily-calorie-chart", this.calorieData);
    this.displayDataToChart();
  }
};
</script>

<style>
</style>