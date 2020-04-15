<template>
  <div>
    <div>
      <input v-model="date" type="date" />
      <button v-on:click="filterByDate(date)">Select Date</button>
    </div>
  </div>
</template>

<script>
import auth from "@/auth";

export default {
  name: "progress-charts",
  methods: {
    filterByDate() {
      fetch(`https://localhost:44392/api/Chart/GetDataForWeek/${this.date}`, {
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
          this.$emit("chartDataReady", this.dailyMeals);
        })

        .catch(err => console.error(err));
    }
  }
};
</script>

<style>
</style>