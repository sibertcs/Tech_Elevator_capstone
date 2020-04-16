<template>
  <div>
        <h4>Daily Calories: {{this.getDailyCalories}}</h4>
    <div>
      <input class="btn btn-outline-info" v-on:change="filterByDate()" v-model="date" type="date"/>
    </div>

    <canvas id="daily-calorie-chart">Chart</canvas>
    
  </div>
</template>

<script>
import auth from "@/auth";
import Chart from "chart.js";
import dailyCalorieData from "../chart-data.js";

export default {
  name: "daily-chart",
  data() {
    return {
      myChart: null,
      meals: Array,
      date: new Date().toISOString().substr(0, 10),
      dailyCalorieData,
      breakfastCalories: 0,
      lunchCalories: 0,
      dinnerCalories: 0,
      snackCalories: 0
    };
  },
  created(){
    this.filterByDate();
  },
  computed: {
    getDailyCalories(){
      return this.breakfastCalories + this.lunchCalories + this.dinnerCalories + this.snackCalories;
    }
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
          this.updateDailyChart();
        })

        .catch(err => console.error(err));
    },
    updateDailyData() {
      this.breakfastCalories=0;
        this.lunchCalories=0;
        this.dinnerCalories=0;
        this.snackCalories=0;
       
      this.meals.forEach(item => {
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
    updateDailyChart(){
      if(this.myChart==undefined || this.myChart==null){
        this.createChart("daily-calorie-chart", this.dailyCalorieData);
      }
      this.updateDailyData();
      this.myChart.update();
    }
  },
 /*  created (){
     this.updateDailyChart()
     alert("created")
  } */
  
  
};
</script>

<style>
</style>