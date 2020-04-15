<template>
  <div>
    <span>
      <button v-on:click="getWeeklyData" click="chartNumber = 1">Weekly</button>
      <button v-on:click="getMonthlyData" click="chartNumber = 2">Monthly</button>
      <button v-on:click="getYearlyData" click="chartNumber = 3">Yearly</button>
      <button v-on:click="getLifetimeData" click="chartNumber = 4">Lifetime</button>
    </span>
    <canvas v-show="chartNumber == 1" id="weekly-calorie-chart">Chart</canvas>
    <canvas v-show="chartNumber == 2" id="monthly-calorie-chart">Chart</canvas>
    <canvas v-show="chartNumber == 3" id="yearly-calorie-chart">Chart</canvas>
    <canvas v-show="chartNumber == 4" id="lifetime-calorie-chart">Chart</canvas>
  </div>
</template>

<script>
import auth from "@/auth";
import Chart from "chart.js";
/* import weeklyCalorieData from "../weekly-chart-data.js"; */
/* import monthlyCalorieData from "../weekly-chart-data.js";
import yearlyCalorieData from "../weekly-chart-data.js";
import lifetimeCalorieData from "../weekly-chart-data.js"; */

export default {
  name: "progress-charts",

  data() {
    return {
      chartNumber: 1,
      myChart: null,
      meals: Array
    };
  },
  methods: {
    getWeeklyData() {
      fetch(`https://localhost:44392/api/Chart/GetDataForWeek}`, {
        method: "GET",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + auth.getToken()
        }
      })
        .then(response => {
          return response.json();
        })
        .then(meals => {
          this.meals = null;
          this.meals = meals;
          this.dailyMeals = meals;
        })

        .catch(err => console.error(err));
    },
    
    updateDailyData() {
      
      

      this.dailyCalorieData.data.datasets[0].data = [
        this.breakfastCalories,
        this.lunchCalories,
        this.dinnerCalories,
        this.snackCalories
      ];
    },
    createChart(chartId, chartData) {
      this.updateDailyData();
      const ctx = document.getElementById(chartId);
      const NewChart = new Chart(ctx, {
        type: chartData.type,
        data: chartData.data,
        options: chartData.options
      });

      this.myChart = NewChart;
    },
    updateChart() {
      if (this.myChart == undefined || this.myChart == null) {
        this.createChart("weekly-calorie-chart", this.weeklyCalorieData);
      }
      this.updateDailyData();
      this.myChart.update();
    }
  }
};
</script>

<style>
</style>