<template>
  <div>
    <div>
      <input class="btn btn-outline-info" id="entryLogDate" v-on:change="filterByDate(date)" v-model="date"  type="date"/>
      
    </div>
    <div v-for="food in meals" :key="food.mealID">
            <br>
      <h5>{{food.foodName}}</h5>
      <h6>Servings: {{food.servings}}</h6>
      <h6>Meal Type: {{food.mealType}}</h6>
      <h6>Calories: {{food.totalCalories}}</h6>
      <h6>Date: {{trimTime(food.consumptionDate)}}</h6>
      <button class="btn btn-outline-info" v-on:click="removeEntry(food.mealID)">Remove Entry</button>
      <button class="btn btn-outline-info" v-if="isHidden" v-on:click="isHidden = false">Edit Entry</button>
      <button v-if="!isHidden" v-on:click="isHidden = true">Hide Form</button>
      <form v-if="!isHidden" v-on:submit.prevent="editEntry(food)">
        <select v-model="food.mealType">
          <span>Select meal type:</span>
          <option selected disabled value>Please select one</option>
          <option>Breakfast</option>
          <option>Lunch</option>
          <option>Dinner</option>
          <option>Snack</option>
        </select>
        <select v-model="food.servings">
          <span>Select meal type:</span>
          <option selected disabled value>Please select one</option>
          
          <option>1</option>
          
          <option>2</option>
          
          <option>3</option>
          
          <option>4</option>
          
          <option>5</option>
        </select>
        <button type="submit">Edit Entry</button>
      </form>
    </div>
  </div>
</template> 

<script>
import auth from "@/auth";

export default {
  name: "entry-log",
  data() {
    return {
      meals: Array,
      isHidden: true,
      date: new Date().toISOString().substr(0, 10),
      dailyMeals: Array
    };
  },
  methods: {
    filterByDate() {
      
      fetch(`https://localhost:44392/api/Meal/GetChartData/${this.date}`, {
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
    trimTime(date) {
       if(date==undefined) {
           return "";
           }
           else {
               return date.substring(0, 10);
           }
           
       
    },
    calculateTotalCalories(food) {
      food.totalCalories = food.servings * food.foodCalories;
    },
    removeEntry(Id) {
      fetch(`https://localhost:44392/api/Meal/RemoveEntry`, {
        method: "DELETE",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + auth.getToken()
        },
        body: JSON.stringify(Id)
      })
        .then(response => {
          if (response.ok) {
            alert("Entry successfully deleted");
            const changeMealToOnlyId = this.meals.map(meal => meal.mealID);
            const index = changeMealToOnlyId.indexOf(Id);

            this.meals.splice(index, 1);
            /* this.$router.push({
                    path: "/home", */
          }
        })

        .catch(err => console.error(err));
    },
    editEntry(food) {
      this.calculateTotalCalories(food);
      fetch(`https://localhost:44392/api/Meal/EditEntry`, {
        method: "PUT",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + auth.getToken()
        },
        body: JSON.stringify(food)
      })
        .then(response => {
          if (response.ok) {
            alert("Entry Updated");
            this.$router.push({
              path: "/home"
            });
          }
        })
        .then(err => console.error(err));
    }
  },
  created() { 
    fetch(`https://localhost:44392/api/Meal/GetChartData/${this.date}`, {
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
      })
      .catch(err => console.error(err));
  }
};
</script>

<style>
</style>