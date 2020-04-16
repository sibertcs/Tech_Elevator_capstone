<template>
  <div>
    <span>
      <button v-on:click="getWeeklyData">Weekly</button>
      <button v-on:click="getMonthlyData">Monthly</button>
      <button v-on:click="getYearlyData">Yearly</button>
      <!-- <button v-on:click="getLifetimeData">Lifetime</button> -->
    </span>
    <canvas  id="weekly-calorie-chart">Chart</canvas>
    <canvas  id="monthly-calorie-chart">Chart</canvas>
    <canvas  id="yearly-calorie-chart">Chart</canvas>
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
      date: new Date(),
      daysWeek: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'],
      daysOfWeek: Object
    };
  },
  methods: {
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
          this.$emit("weeklyChart")
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
          ],
          this.weeklyCalorieData.data.labels = [
          '6 days ago','5 days ago','4 days ago',
          '3 days ago','2 days ago','1 day ago',
          'Today'
          ];
          break;
        case 2:
          this.monthlyCalorieData.data.datasets[0].data = [
            this.meals[3], this.meals[2], this.meals[1], this.meals[0]
          ],
          this.monthlyCalorieData.data.labels = [
            '3 weeks ago', '2 weeks ago', '1 week ago', 'This week'
          ]
          break;
        case 3:
          this.yearlyCalorieData.data.datasets[0].data = [
            this.meals[11], this.meals[10], this.meals[9], this.meals[8],
            this.meals[7], this.meals[6], this.meals[5], this.meals[4],
            this.meals[3], this.meals[2], this.meals[1], this.meals[0]
          ],
          this.yearlyCalorieData.data.labels = [
            '11 months ago', '10 months ago', '9 months ago', '8 months ago',
            '7 months ago', '6 months ago', '5 months ago', '4 months ago',
            '3 months ago', '2 months ago', '1 month ago', 'This month'
          ]
          break;
      }
      
      
        
      
      
    },
    createChart(chartId, chartData) {
      this.updateData();
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
        if(this.chartNumber === 1){
          this.createChart("weekly-calorie-chart", this.weeklyCalorieData);
        }
        else if (this.chartNumber === 2){
          this.createChart("monthly-calorie-chart", this.monthlyCalorieData)
        }
        else if (this.chartNumber === 3){
          this.createChart("yearly-calorie-chart", this.yearlyCalorieData)
        }     
      }
      this.updateData();
      this.myChart.update();
    }
  }
};
</script>

<style>
</style>