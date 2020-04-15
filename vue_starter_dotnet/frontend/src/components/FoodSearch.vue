<template>
<div>
  
  <form v-on:submit.prevent="getFoods">
    <input v-on:change="getFoods" type="text" v-model="search" placeholder="Search for foods.."/>
    <button type="submit">Search</button>
  </form>
  <div>
    <form v-for="food in meals" :key="food.fdcid" v-on:submit.prevent="saveFood(food)">
      <h5>Name: {{food.foodName}}</h5>
      <h6>Calories: {{food.foodCalories}}</h6>
      <select v-model="food.mealType">
        <span>Select meal type:</span>
        <option selected disabled value="">Please select one</option>
        <option>Breakfast</option>
        <option>Lunch</option>
        <option>Dinner</option>
        <option>Snack</option>
      </select>
      <select v-model="food.servings">
        <span>Select meal type:</span>
        <option selected disabled value="">Please select one</option>
        
        <option>1</option>
        
        <option>2</option>
        
        <option>3</option>
        
        <option>4</option>
        
        <option>5</option>
      </select>
      <input type="date" min="1900-01-01" v-model="food.consumptionDate">
      <!-- <input type="time" v-model="food.consumptionTime"> -->
      <button type="submit">Add Food</button>
    </form>
  </div>
  </div>
</template>

<script>       
import auth from "@/auth";
export default {
    name:"food-search",
    data(){
      return {
        meals: Array,
        meal: {
          FDCID: "",
          foodName: "",
          consumptionDate: "",
          servings: "",
          mealType: "",
          foodCalories: "",
          totalCalories: "",
        },
        search: ""
      }     
  },
  methods: {
    calculateTotalCalories(food){
      food.totalCalories = food.servings * food.foodCalories
    },
    getFoods(){ 
      fetch(`https://localhost:44392/api/Meal/foodSearch/${this.search}`,{
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
      .then (meals => {
        this.meals = null;
        this.meals = meals;
      })
      .catch(err => console.error(err));
    },
    saveFood(food) {
      this.calculateTotalCalories(food);
      fetch(`${process.env.VUE_APP_REMOTE_API_MEAL}/AddMeal`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + auth.getToken()
        },
        body: JSON.stringify(food)
      })
        .then(response => {
          if (response.ok) {
            alert("Food added");
            
          }
        })
        .then(err => console.error(err));
    }

  }
  
}

</script>

<style>

</style>