<template>
  <div>
    <div>
      <input v-model="date" type="date" />
      <button v-on:click="filterByDate(date)">Select Date</button>
    </div>
    <canvas id="daily-calorie-chart">Chart</canvas>
  </div>
</template>

<script>
import auth from "@/auth";
import Chart from "chart.js";
import calorieData from "../chart-data.js";

export default {
  name: "daily-chart",
  data() {
    return {
      date: Date,
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
    
  },
  methods: {

    filterByDate() {
      
      fetch(`https://localhost:44392/api/Chart/GetDataForDay/${this.date}`, {
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
        this.$emit('chartDataReady', this.dailyMeals)
      })

        .catch(err => console.error(err));
    },
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