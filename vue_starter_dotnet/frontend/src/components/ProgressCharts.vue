<template>
  <div>
    <span>
      <button v-on:click="getWeeklyData">Weekly</button>
      <button v-on:click="getMonthlyData">Monthly</button>
      <button v-on:click="getYearlyData">Yearly</button>
      <!-- <button v-on:click="getLifetimeData">Lifetime</button> -->
    </span>
    <canvas id="chartData"></canvas>
<!--     <canvas  id="weekly-calorie-chart">Chart</canvas>
    <canvas  id="monthly-calorie-chart">Chart</canvas>
    <canvas  id="yearly-calorie-chart">Chart</canvas> -->
    <!--<canvas v-show="chartNumber == 4" id="lifetime-calorie-chart">Chart</canvas> -->
  </div>
</template>

<script>
import auth from "@/auth";
import Chart from "chart.js";
import weeklyCalorieData from "../weekly-chart-data.js"; 
import monthlyCalorieData from "../monthly-chart-data.js";
import yearlyCalorieData from "../yearly-chart-data.js";
/*import lifetimeCalorieData from "../weekly-chart-data.js"; */

export default {
  name: "progress-charts",

  data() {
    return {
      chartNumber: "1",
      myChart: null,
      meals: Array,
      weeklyCalorieData,
      monthlyCalorieData,
      yearlyCalorieData,
      date: new Date().toISOString().substr(0, 10),
      daysWeek: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'],
      daysOfWeek: Object,
      dailyChartLabels: [],
      monthlyChartLabels: [],
      yearlyChartLabels: []
    };
  },
  created(){
    this.getWeeklyData();
    this.populateDailyChartLabels();
    this.populateMonthlyChartLabels();
    this.populateYearlyChartLabels();
  },
  methods: {
    populateDailyChartLabels(){
      let todaysDate = new Date();
      for (let i = 7; i > 0; i--){
        let dateTracker = new Date();
        dateTracker.setDate(todaysDate.getDate()-i);
        dateTracker = dateTracker.toISOString().substring(5, 10);
        this.dailyChartLabels.push(dateTracker);
      }
    },
    populateMonthlyChartLabels(){
      let todaysDate = new Date();
      for (let i = 28; i > 0; i-=7){
        let dateTracker1 = new Date();
        let dateTracker2 = new Date();
        dateTracker1.setDate(todaysDate.getDate()-i);
        dateTracker2.setDate(todaysDate.getDate()-(i-7));
        dateTracker1 = dateTracker1.toISOString().substring(5, 10);
        dateTracker2 = dateTracker2.toISOString().substring(5, 10);
        let dateSpan = dateTracker1 + "  through  " + dateTracker2;
        this.monthlyChartLabels.push(dateSpan);
      }
    },
    populateYearlyChartLabels(){
      let todaysDate = new Date();
      let todaysMonth = (todaysDate.getMonth() + 1);
      let todaysYear = (todaysDate.getFullYear())
      for (let i = 0; i <= 11; i++){
        if (todaysMonth == 0){
          todaysMonth = 12;
          todaysYear -= 1;
        }
        let dataPoint = todaysMonth + " / " + todaysYear;
        this.yearlyChartLabels.push(dataPoint)
        todaysMonth--;
      }
      this.yearlyChartLabels.reverse();
    },
    getWeeklyData() {
      this.chartNumber = 1;
      fetch(`https://localhost:44392/api/Chart/GetDataForWeek`, {
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
          this.updateChart();
        })

        .catch(err => console.error(err));
    },
    getMonthlyData() {
      this.chartNumber = 2;
      fetch(`https://localhost:44392/api/Chart/GetDataForMonth`, {
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
          this.updateChart();
        })

        .catch(err => console.error(err));
    },
    getYearlyData() {
      this.chartNumber = 3;
      fetch(`https://localhost:44392/api/Chart/GetDataForYear`, {
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
          this.updateChart();
        })

        .catch(err => console.error(err));
    },
    updateData() {
      switch(this.chartNumber) {
        case 1:
          this.weeklyCalorieData.data.datasets[0].data = [
          this.meals[6], this.meals[5], this.meals[4],
          this.meals[3], this.meals[2], this.meals[1],
          this.meals[0]
          ];
          this.weeklyCalorieData.data.labels = this.dailyChartLabels;
          break;
        case 2:
          this.monthlyCalorieData.data.datasets[0].data = [
            this.meals[3], this.meals[2], this.meals[1], this.meals[0]
          ],
          this.monthlyCalorieData.data.labels = this.monthlyChartLabels;
          break;
        case 3:
          this.yearlyCalorieData.data.datasets[0].data = [
            this.meals[11], this.meals[10], this.meals[9], this.meals[8],
            this.meals[7], this.meals[6], this.meals[5], this.meals[4],
            this.meals[3], this.meals[2], this.meals[1], this.meals[0]
          ],
          this.yearlyCalorieData.data.labels = this.yearlyChartLabels;
          break;
      }
      
      
        
      
      
    },
    createChart(chartId, chartData) {
      this.updateData();
      const ctx = document.getElementById("chartData");
      const NewChart = new Chart(ctx, {
        type: chartData.type,
        data: chartData.data,
        options: chartData.options
      });

      this.myChart = NewChart;
    },
    updateChart() {
      
        if(this.chartNumber === 1){
          this.createChart("weekly-calorie-chart", this.weeklyCalorieData);
        }
        else if (this.chartNumber === 2){
          this.createChart("monthly-calorie-chart", this.monthlyCalorieData)
        }
        else if (this.chartNumber === 3){
          this.createChart("yearly-calorie-chart", this.yearlyCalorieData)
        }     
      
      this.updateData();
      this.myChart.update();
    }
  }
};
</script>

<style>
</style>